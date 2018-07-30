using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.Entities;
using WijayanthaHardware.Models;

namespace WijayanthaHardware.Services
{
    public class PaintService : RepositoryBase
    {
        public async Task<List<PaintSubCategoryBo>> GetPaintSubCategories(int? paintCategoryId)
        {
            using (var context = CreateContext())
            {
                var result = await context.PaintSubCategory.Where(w => w.Status == (int)RecordStatusEnum.Active && w.PaintCategoryId == paintCategoryId)
                    .Select(s => new PaintSubCategoryBo
                    {
                        PaintSubCategoryId = s.PaintSubCategoryId,
                        Value = s.Value
                    }).OrderBy(o => o.Value).ToListAsync();
                return result;
            }
        }

        public async Task<List<PaintColourViewModel>> GetPaintColoursAsync(string query)
        {
            using (var context = CreateContext())
            {
                var list = await context.PaintColour.Where(w => w.Status == (int)RecordStatusEnum.Active && (w.Colour.Contains(query) || w.ColourCode.Contains(query)))
                    .Select(s => new PaintColourViewModel
                    {
                        PaintColourId = s.PaintColourId,
                        Colour = s.Colour + " [" + s.ColourCode + "]"
                    }).ToListAsync();
                return list;
            }
        }

        public async Task<List<PaintViewModel>> GetpaintByColourIdAsync(int? PaintCategoryId, int? PaintSubCategoryId, int paintColourId)
        {
            using (var context = CreateContext())
            {
                var list = await context.PaintMaster.Include(i => i.PaintVolume)
                    .Where(w => (paintColourId != 0 ? w.PaintColour.PaintColourId == paintColourId && w.Status == (int)RecordStatusEnum.Active : w.Status == (int)RecordStatusEnum.Active) && w.PaintCategoryId == PaintCategoryId && w.PaintSubCategoryId == PaintSubCategoryId)
                    .Select(s => new PaintViewModel
                    {
                        PaintId = s.PaintMasterId,
                        PaintColour = s.PaintColour.Colour + " [" + s.PaintColour.ColourCode + "]",
                        Volume = s.PaintVolume.Value,
                        Price = s.Price,
                        AvailableQuantity = s.Quantity
                    }).OrderBy(o => o.PaintColour).ToListAsync();
                return list;
            }
        }

        public async Task<bool> AddNewPaintCategoryAsync(PaintViewModel paintViewModel)
        {
            using (var context = CreateContext())
            {
                var result = await context.PaintCategory.AnyAsync(f => f.Value.ToLower() == paintViewModel.Value.ToLower() && f.Status == (int)RecordStatusEnum.Active);
                if (!result)
                {
                    var newCategory = new PaintCategory
                    {
                        Value = paintViewModel.Value,
                        Description = paintViewModel.Description,
                        Status = (int)RecordStatusEnum.Active
                    };
                    context.PaintCategory.Add(newCategory);
                    await context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

        public async Task<bool> AddNewsubCategoryAsync(PaintViewModel paintViewModel)
        {
            using (var context = CreateContext())
            {
                var result = await context.PaintSubCategory.AnyAsync(f => f.Value.ToLower() == paintViewModel.Value.ToLower() && f.PaintCategoryId == paintViewModel.PaintCategoryId && f.Status == (int)RecordStatusEnum.Active);
                if (!result)
                {
                    var newSubCategory = new PaintSubCategory
                    {
                        Value = paintViewModel.Value,
                        Description = paintViewModel.Description,
                        PaintCategoryId = paintViewModel.PaintCategoryId,
                        Status = (int)RecordStatusEnum.Active
                    };
                    context.PaintSubCategory.Add(newSubCategory);
                    await context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

        public async Task<bool> AddNewpaintsAsync(List<PaintViewModel> newPaintDetails)
        {
            try
            {
                using (var context = CreateContext())
                {
                    var firstRecord = newPaintDetails.First();
                    var isVolumeAvailable = newPaintDetails.Select(s => s.VolumeId).ToList();
                    var IsPaintAvailable = await context.PaintMaster.AnyAsync(a => a.PaintCategoryId == firstRecord.PaintCategoryId &&
                     a.PaintSubCategoryId == firstRecord.PaintSubCategoryId && a.PaintColourId == firstRecord.ColourId &&
                     isVolumeAvailable.Contains(a.PaintVolumeId));
                    if (IsPaintAvailable) return true;
                }
                

                //var connectionString = context.Database.Connection.ConnectionString;
                using (var bulkCopy = new SqlBulkCopy(CreateContext().Database.Connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                {
                    bulkCopy.ColumnMappings.Add("PaintColourId", "PaintColourId");
                    bulkCopy.ColumnMappings.Add("PaintCategoryId", "PaintCategoryId");
                    bulkCopy.ColumnMappings.Add("PaintVolumeId", "PaintVolumeId");
                    bulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                    bulkCopy.ColumnMappings.Add("Price", "Price");
                    bulkCopy.ColumnMappings.Add("PaintSubCategoryId", "PaintSubCategoryId");
                    bulkCopy.ColumnMappings.Add("Status", "Status");
                    bulkCopy.ColumnMappings.Add("CostCode", "CostCode");


                    bulkCopy.BatchSize = newPaintDetails.Count();
                    bulkCopy.DestinationTableName = "[Inventory].[PaintMaster]";
                    await bulkCopy.WriteToServerAsync(GetTableRows(newPaintDetails));
                    return false;
                }

            }
            catch (Exception ex)
            {
                var errormsg = ex.StackTrace;
                return false;
            }
        }

        private DataTable GetTableRows(List<PaintViewModel> newPaintDetails)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("PaintColourId", typeof(int));
            dataTable.Columns.Add("PaintCategoryId", typeof(int));
            dataTable.Columns.Add("PaintVolumeId", typeof(int));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("Price", typeof(double));
            dataTable.Columns.Add("PaintSubCategoryId", typeof(int));
            dataTable.Columns.Add("Status", typeof(int));
            dataTable.Columns.Add("CostCode", typeof(string));

            foreach (var newpaint in newPaintDetails)
            {
                dataTable.Rows.Add(newpaint.ColourId, newpaint.PaintCategoryId, newpaint.VolumeId, newpaint.Quantity, newpaint.Price, newpaint.PaintSubCategoryId, (int)RecordStatusEnum.Active, newpaint.CostCode);
            }
            return dataTable;
        }
    }
}
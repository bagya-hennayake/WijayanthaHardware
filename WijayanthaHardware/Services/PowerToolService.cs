using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.Mappers;
using WijayanthaHardware.Models;

namespace WijayanthaHardware.Services
{
    public class PowerToolService : RepositoryBase
    {
        public async Task<List<PowerToolsubCatergoryBo>> GetPowerToolsSubCategory(int? powerToolCategory)
        {
            using (var context = CreateContext())
            {
                var result = await context.PowerToolSubCatogery.Where(w => w.Status == (int)RecordStatusEnum.Active && w.PowerToolCategoryId == powerToolCategory)
                    .Select(s => new PowerToolsubCatergoryBo
                    {
                        PowerToolSubCategoryId = s.PowerToolSubCatogeryId,
                        Value = s.Value
                    }).OrderBy(o => o.Value).ToListAsync();
                return result;
            }
        }

        public async Task<PowerToolsViewModel> GetPowerToolSubCategoryDetailAsync(int? powerToolSubCategoryId, int? powerToolCategory)

        {
            using (var context = CreateContext())
            {
                var result = await context.PowerToolMaster.Include(i => i.PowerToolSubCatogery).Include(i => i.PowerToolCategory).FirstOrDefaultAsync(a => a.PowerToolCategoryId == powerToolCategory && a.PowerToolSubCatogeryId == powerToolSubCategoryId && a.Status == (int)RecordStatusEnum.Active);
                return PowerToolMapper.BuildPowerToolsViewModel(result);
            }
        }



        public async Task<PowerToolsViewModel> EditPowerTool(int PowerToolMasterId)
        {
            using (var context = CreateContext())
            {
                var result = await context.PowerToolMaster.Include(i => i.PowerToolCategory).Include(i => i.PowerToolSubCatogery)
                    .FirstOrDefaultAsync(f => f.Status == (int)RecordStatusEnum.Active && f.PowerToolMasterId == PowerToolMasterId);

                return new PowerToolsViewModel()
                {
                    PowerToolId = result.PowerToolMasterId,
                    PowerToolSubCategoryId = result.PowerToolMasterId,
                    ToolName = result.PowerToolSubCatogery.Description,
                    ToolPrice = result.Price,
                    ToolBrand = result.PowerToolCategory.Description,
                    WarrantyPeriod = result.WarrantyPeriod,
                    CostCode = result.CostCode,
                    AvailableQuantity = result.Quantity,
                    Details = result.Detail,
                    PowerToolMasterId = result.PowerToolMasterId,
                };
            }
        }

        public async Task UpdatePaintAsync(PowerToolsViewModel ptViewModel)
        {
            using (var context = CreateContext())
            {
                var result = context.PowerToolMaster.FirstOrDefault(f => f.PowerToolMasterId == ptViewModel.PowerToolMasterId && f.Status == (int)RecordStatusEnum.Active);
                result.Price = ptViewModel.ToolPrice;
                result.Quantity = ptViewModel.AvailableQuantity;
                await context.SaveChangesAsync();
            }
        }
    }
}
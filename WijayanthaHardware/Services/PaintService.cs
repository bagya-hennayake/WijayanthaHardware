using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
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
                var list = await context.PaintColour.Where(w=>w.Colour.Contains(query)).Select(s => new PaintColourViewModel
                {
                    PaintColourId = s.PaintColourId,
                    Colour = s.Colour
                }).ToListAsync();
                return list;
            }
        }
    }
}
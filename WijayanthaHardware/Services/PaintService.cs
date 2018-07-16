using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;

namespace WijayanthaHardware.Services
{
    public class PaintService : RepositoryBase
    {
        public async Task<List<PaintSubCategoryBo>> GetPaintSubCategory(int? paintCat)
        {
            using (var context = CreateContext())
            {
                var result = await context.PaintSubCategory.Where(w => w.Status == (int)RecordStatusEnum.Active && w.PaintCategoryId == paintCat)
                    .Select(s => new PaintSubCategoryBo
                    {
                        PaintSubCategoryId = s.PaintSubCategoryId,
                        Value = s.Value
                    }).OrderBy(o => o.Value).ToListAsync();
                return result;
            }



        }

    }
}
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

        public async Task<PowerToolsViewModel> GetPowerToolSubCategoryDetailAsync(int? powerToolSubCategoryId)

        {
            using (var context = CreateContext())
            {
                var result = await context.PowerToolMaster.Include(i => i.PowerToolSubCatogery).Include(i => i.PowerToolCategory).Where(a => a.PowerToolCategoryId == powerToolSubCategoryId)
                    .Select(s => new PowerToolsViewModel
                    {
                        ToolName = s.PowerToolSubCatogery.Value,
                        ToolPrice = s.Price,
                        CostCode = s.CostCode,
                        ToolBrand = s.PowerToolCategory.Value,
                        WarrantyPeriod = s.WarrantyPeriod,
                        AvailableQuantity = s.Quantity
                    }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;

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
    }
}
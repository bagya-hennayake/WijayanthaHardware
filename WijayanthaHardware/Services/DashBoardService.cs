using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WijayanthaHardware.Common;
using WijayanthaHardware.Models;
using System;

namespace WijayanthaHardware.Services
{
    public class DashBoardService : RepositoryBase
    {
        public async Task<List<DashboardViewModel>> GetDashBoardPaintChartDataAsync()
        {
            try
            {
                var dashboardViewModel = new List<DashboardViewModel>();
                using (var context = CreateContext())
                {
                    var uiniqueProductIds = await context.PaintMaster.Where(w => w.Status == (int)RecordStatusEnum.Active).Select(s => s.PaintCategoryId).Distinct().ToListAsync();

                    foreach (var distinctid in uiniqueProductIds)
                    {
                        var result = await context.PaintSubCategory.Include(i => i.PaintCategory).Where(w => w.PaintCategoryId == distinctid && w.Status == (int)RecordStatusEnum.Active).ToListAsync();
                        var vm = new DashboardViewModel
                        {
                            PaintName = result.FirstOrDefault().PaintCategory.Value,
                            PaintAvailabiltyCount = result.Count(),
                            Type = "paint"
                        };
                        dashboardViewModel.Add(vm);
                    }

                    var uniquePowerToolIds = await context.PowerToolMaster.Where(w => w.Status == (int)RecordStatusEnum.Active).Select(s => s.PowerToolCategoryId).Distinct().ToListAsync();//can u continue from hrere? oksame code as this
                    foreach (var distinctid in uniquePowerToolIds)
                    {                                                               // u wrote tool category first ryt? i deleted it?yep//sorry, my mistaitke it's ok
                        var result = await context.PowerToolSubCatogery.Include(i => i.ToolCategory).Where(w => w.PowerToolCategoryId == distinctid && w.Status == (int)RecordStatusEnum.Active).ToListAsync();
                        var vm = new DashboardViewModel
                        {
                            ToolName = result.FirstOrDefault().ToolCategory.Value,
                            PowerToolAvailabilityCount = result.Count(),
                            Type = "powertool"
                        };
                        dashboardViewModel.Add(vm);//why we use the paintviewmodel for both powertool ant paint
                                                   //gppd question, we must have made a new modle for dashboard, since we dont have a new modle we are using the paintview modle, and we cannot pass 2 objects to the view
                                                   //shall we create a new view modle?ok
                                                   //u create
                                                   //I it dont kw how to do
                                                   //creiate a class in the models folder
                    }
                }
                return dashboardViewModel;
            }
            catch (Exception ex)
            {
                var aa = ex.StackTrace;
                return new List<DashboardViewModel>();
            }
        }
    }
}
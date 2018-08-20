using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.Models;
using WijayanthaHardware.Services;

namespace WijayanthaHardware.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DashBoardService _dashBoardService;

        public HomeController(DashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }

        public async Task<ActionResult> DashBoard()
        {
            var result = await _dashBoardService.GetDashBoardPaintChartDataAsync();
            return View(result);
        }
        //public async Task<ActionResult> DashBoard()// u cant define the same function(public async Task<ActionResult> DashBoard()) name twice unless it is been over ridden or over loaded
        //{
        //    var result = await _dashBoardService.GetDashBoardPowerToolChartDataAsync();
        //    return View(result);
        //}
        public ActionResult Sales()
        {
            return View();
        }


    }
}
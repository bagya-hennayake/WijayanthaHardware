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
        private readonly LookUpServices _lookUpServices;

        public HomeController(DashBoardService dashBoardService, LookUpServices lookUpServices)
        {
            _dashBoardService = dashBoardService;
            _lookUpServices = lookUpServices;
        }

        public async Task<ActionResult> DashBoard()
        {
            var result = await _dashBoardService.GetDashBoardChartDataAsync();
            return View(result);
        }

        public ActionResult Sales()
        {
            var paints = _lookUpServices.GetLookUp(LookUpTypeEnum.PaintCategory);
            var powertools = _lookUpServices.GetLookUp(LookUpTypeEnum.PowerToolCategory);
            var SalesModel = new SalesModelsalesModel
            {
                PaintCatergoryList = new SelectList(paints, "LookUpId", "Value"),
                PaintSubategoryList = new SelectList(new List<LookUpBO>(), "LookUpId", "Value"),
                PowerToolSelectList = new SelectList(powertools, "LookUpId", "Value"),
                PowerToolSubSelectList = new SelectList(new List<LookUpBO>(), "LookUpId", "Value")
            };
            return View(SalesModel);
        }
    }
}
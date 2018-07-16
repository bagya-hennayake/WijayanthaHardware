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
    public class PowerToolsController : Controller
    {
        private readonly LookUpServices _lookUpServices;
        private readonly PaintService _paintService;

        public PowerToolsController(LookUpServices lookUpServices, PaintService paintService)
        {
            _lookUpServices = lookUpServices;
            _paintService = paintService;
        }

        public ActionResult Index()
        {
            var lookUpCategory = _lookUpServices.GetLookUp(LookUpTypeEnum.PaintCategory);
            var powerToolViewModel = new PowerToolsViewModel
            {
                PowerToolSelectList = new SelectList(lookUpCategory, "LookUpId", "Value"),
                PowerToolSubSelectList = new SelectList(new List<LookUpBO>(), "LookUpId", "Value")
            };
            return View(powerToolViewModel);
        }

        public async Task<ActionResult> GetPaintSubCategories(int? paintCat)
        {
            var result = await _paintService.GetPaintSubCategory(paintCat);
            return Content("hello");
        }
    }
}
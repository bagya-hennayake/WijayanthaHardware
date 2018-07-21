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
        private readonly PowerToolService _powerToolService;

        public PowerToolsController(LookUpServices lookUpServices, PowerToolService powerToolService)
        {
            _lookUpServices = lookUpServices;
            _powerToolService = powerToolService;
        }

        public ActionResult Index()
        {
            var lookUpCategory = _lookUpServices.GetLookUp(LookUpTypeEnum.PowerToolCategory);
            var powerToolViewModel = new PowerToolsViewModel
            {
                PowerToolSelectList = new SelectList(lookUpCategory, "LookUpId", "Value"),
                PowerToolSubSelectList = new SelectList(new List<LookUpBO>(), "LookUpId", "Value")
            };
            return View(powerToolViewModel);
        }

        public async Task<ActionResult> GetPowerToolSubCategories(int? powerToolCategory)
        {
            var result = await _powerToolService.GetPowerToolsSubCategory(powerToolCategory);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetPowerToolSubCategoryDetail(int? powerToolSubCatId)
        {
           var result = await _powerToolService.GetPowerToolSubCategoryDetailAsync(powerToolSubCatId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
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
    public class PaintsController : Controller
    {
        private readonly PaintService _paintService;
        private readonly LookUpServices _lookUpServices;

        public PaintsController(PaintService paintService, LookUpServices lookUpServices)
        {
            _paintService = paintService;
            _lookUpServices = lookUpServices;
        }
        // GET: Paints
        public ActionResult Index()
        {
            var result = _lookUpServices.GetLookUp(LookUpTypeEnum.PaintCategory);
            var paintViewModel = new PaintViewModel
            {
                PaintCatergoryList = new SelectList(result, "LookUpId", "Value"),
                PaintSubategoryList = new SelectList(new List<LookUpBO>(), "LookUpId", "Value")
            };
            return View(paintViewModel);
        }

        public async Task<ActionResult> GetPaintSubCategory(int? paintCategoryId)
        {
            var result = await _paintService.GetPaintSubCategories(paintCategoryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
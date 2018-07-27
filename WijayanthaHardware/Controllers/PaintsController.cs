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
    public class PaintsController : Controller
    {
        private readonly PaintService _paintService;
        private readonly LookUpServices _lookUpServices;

        public PaintsController(PaintService paintService, LookUpServices lookUpServices)
        {
            _paintService = paintService;
            _lookUpServices = lookUpServices;
        }

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


        public async Task<ActionResult> GetPaintColourLookup(string query, int? PaintCategoryId, int? PaintSubCategoryId)
        {
            var result = await _paintService.GetPaintColoursAsync(query, PaintCategoryId, PaintSubCategoryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> GetListOfPaintsByColour(int? PaintCategoryId, int? PaintSubCategoryId, int paintColourId)
        {
            var result = await _paintService.GetpaintByColourIdAsync(PaintCategoryId, PaintSubCategoryId, paintColourId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewPaintCategory(PaintViewModel paintViewModel)
        {
            var isSuccess = await _paintService.AddNewPaintCategoryAsync(paintViewModel);
            return isSuccess ? Json(new { status = TransactionStatusEnum.success.ToString(), title = "Success", message = "Paint Category has been saved successfully" }, JsonRequestBehavior.AllowGet)
                : Json(new { status = TransactionStatusEnum.error.ToString(), title = "Failed", message = "This Paint Category is already available" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddPaint()
        {
            return View();
        } 
    }
}
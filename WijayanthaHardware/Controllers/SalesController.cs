using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.Models;
using WijayanthaHardware.Services;

namespace WijayanthaHardware.Controllers
{
    public class SalesController : Controller
    {

        private readonly PaintService _paintService;
        private readonly LookUpServices _lookUpServices;

        public SalesController(PaintService paintService, LookUpServices lookUpServices)
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


        public async Task<ActionResult> GetPaintColourLookup(string query)
        {
            var result = await _paintService.GetPaintColoursAsync(query);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetListOfPaintsByColour(int? PaintCategoryId, int? PaintSubCategoryId, int paintColourId)
        {
            var result = await _paintService.GetpaintByColourIdAsync(PaintCategoryId, PaintSubCategoryId, paintColourId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
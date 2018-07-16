using System;
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
        public PowerToolsController(LookUpServices lookUpServices)
        {
            _lookUpServices = lookUpServices;
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

        public ActionResult GetPaintSubCategories(int? departmentId)
        {

            return Content("hello");
        }
    }
}
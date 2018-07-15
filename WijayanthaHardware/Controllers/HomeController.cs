using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WijayanthaHardware.Common;
using WijayanthaHardware.Models;
using WijayanthaHardware.Services;

namespace WijayanthaHardware.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly LookUpServices _lookUpServices;

        public HomeController(LookUpServices lookUpServices)
        {
            _lookUpServices = lookUpServices;
        }
        // GET: Home
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult PowerTools()
        {
            var lookUpCategory = _lookUpServices.GetLookUp(LookUpTypeEnum.PaintCategory);
            var powerToolViewModel = new PowerToolsViewModel
            {
                PowerToolSelectList = new SelectList(lookUpCategory, "LookUpId", "Value"),
                PowerToolId = lookUpCategory.First().LookUpId,
            };
            return View(powerToolViewModel);
        }
    }
}
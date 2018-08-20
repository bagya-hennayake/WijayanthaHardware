/*
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
    public class SalesController : Controller
    {
        private readonly SalesService _salesService;
        private readonly LookUpServices _lookUpServices;

        public SalesController(SalesService salesService, LookUpServices lookUpServices)
        {
            _salesService = salesService;
            _lookUpServices = lookUpServices;
        }

        public ActionResult Index()
        {
            var result = _lookUpServices.GetLookUp(LookUpTypeEnum.PaintCategory);
            var salesViewModel = new SalesVeiwModel
            {
                Sales = new SelectList(result, "LookUpId", "Value"),
                PaintSubategoryList = new SelectList(new List<LookUpBO>(), "LookUpId", "Value")
            };
            return View(salesViewModel);
        }
    }
}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WijayanthaHardware.DBContext;
using WijayanthaHardware.Entities;

namespace WijayanthaHardware.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {


            //var paintCategory = new PaintCategoryDef()
            //{
            //    Description="Paint Premium",
            //    Value= "Premium"
            //};

            //var wijayanathaDb = new WijayanathaDb();
            //wijayanathaDb.PaintCategory.Add(paintCategory);

            //wijayanathaDb.SaveChanges();


            
            return View();
        }
    }
}
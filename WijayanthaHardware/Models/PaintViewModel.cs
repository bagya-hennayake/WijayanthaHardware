using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WijayanthaHardware.Models
{
    public class PaintViewModel
    {
        [Display(Name = "Paint Category")]
        public int PaintCategoryId { get; set; }
        public SelectList PaintCatergoryList { get; set; }
        [Display(Name = "Paint")]
        public int PaintSubCategoryId { get; set; }
        public SelectList PaintSubategoryList { get; set; }
    }
}
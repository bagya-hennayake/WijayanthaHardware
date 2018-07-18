using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WijayanthaHardware.Models
{
    public class PowerToolsViewModel
    {
        [Display(Name = "Tool Category")]
        public int PowerToolId { get; set; }
        public SelectList PowerToolSelectList { get; set; }
        [Display(Name = "Tool")]
        public int? PowerToolSubCategoryId { get; set; }
        public SelectList PowerToolSubSelectList { get; set; }
    }
}
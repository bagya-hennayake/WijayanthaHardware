using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WijayanthaHardware.Models
{
    public class SalesVeiwModel
    {
        [Display(Name = "Sales")]
        public int SalesID { get; set; }
        public SelectList SelsPowerToolSelectList { get; set; }
        [Display(Name = "Tool")]
        public int? PowerToolSubCategoryId { get; set; }
        public SelectList PowerToolSubSelectList { get; set; }
        public string ToolName { get; set; }
        public double ToolPrice { get; set; }
        public string ToolBrand { get; set; }
        public string WarrantyPeriod { get; set; }
        public string CostCode { get; set; }
        public int AvailableQuantity { get; set; }
        public string Details { get; set; }
        public SelectList Sales { get; internal set; }
        public string SaleValue { get; set; }
        public object PaintMasterId { get; internal set; }
        public int PaintColourId { get; internal set; }
        public object Price { get; internal set; }
    }
}
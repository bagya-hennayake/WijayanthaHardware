using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WijayanthaHardware.Models
{
    public class SalesModelsalesModel

    {
        [Display(Name = "Paint Category")]
        public int PaintCategoryId { get; set; }
        public SelectList PaintCatergoryList { get; set; }
        [Display(Name = "Paint")]
        public int PaintSubCategoryId { get; set; }
        public SelectList PaintSubategoryList { get; set; }

        //[Display(Name = "Colour")]
        //public string PaintColour { get; set; }
        //public SelectList ColourList { get; set; }

        public string PaintColour { get; set; }
        public string Volume { get; set; }
        public int AvailableQuantity { get; set; }
        public double Price { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int PaintId { get; set; }
        public string CostCode { get; set; }
        [Display(Name = "Volume")]
       
   
        public int VolumeId { get; set; }
        public int Quantity { get; set; }

        public string Colour { get; set; }
        public int PaintMasterId { get; set; }
        //////////////////////////////////////////////////////////////////////////////////
        [Display(Name = "Tool Category")]
        public int PowerToolId { get; set; }
        public SelectList PowerToolSelectList { get; set; }
        [Display(Name = "Tool")]
        public int? PowerToolSubCategoryId { get; set; }
        public SelectList PowerToolSubSelectList { get; set; }
        public string ToolName { get; set; }
        public double ToolPrice { get; set; }
        public string ToolBrand { get; set; }
        public string WarrantyPeriod { get; set; }
        //public string CostCode { get; set; }
        //public int AvailableQuantity { get; set; }
        public string Details { get; set; }

    }
}
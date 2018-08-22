using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{

    [Table("Sales", Schema = "Sales")]
    public class Sales

    { [key]
        public int SalesId { get; set; }
        public DateTime  SalesDate { get; set; }
        public DateTime SalesTimes { get; set; }
        public string SalesAmount { get; set; }
        public int SalesPId { get; set; }
        public int SalesPWId { get; set; }
    }
}
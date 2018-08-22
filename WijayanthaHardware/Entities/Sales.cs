using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("Sales", Schema = "Master")]
    public class Sales
    {[key]
        public int SalesId { get; set; }
        public string SalesDescription { get; set; }

        public DateTime SaleDate { get; set; }
        public string SaleValue { get; set; }
    }
}
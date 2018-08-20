using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("Supplier", Schema = "Master")]
    public class Supplier
    {
        [key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string TelephoneNumber { get; set; }
    }

}

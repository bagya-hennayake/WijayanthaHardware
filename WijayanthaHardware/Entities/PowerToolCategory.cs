using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PowerToolCategory", Schema = "LookUp")]
    public class PowerToolCategory

    {
        [key]
        public int PowerToolCategoryId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}
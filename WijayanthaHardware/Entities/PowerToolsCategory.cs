using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PowerToolsCategory", Schema = "LookUp")]
    public class PowerToolsCategory
    {
        [Key]
        public int PowerToolCategoryId { get; set; }

       
    }
}
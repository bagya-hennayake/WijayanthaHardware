using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{ [Table("PowerToolSubCatogery",Schema ="LookUp")]
    public class PowerToolSubCatogery
    {
        [Key]
        public int PowerToolSubCatogeryId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        
    }
}
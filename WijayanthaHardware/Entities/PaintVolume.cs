using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PaintVolume", Schema = "LookUp")]
    public class PaintVolume
    {
        [Key]
        public int VolumeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
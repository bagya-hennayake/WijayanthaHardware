using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PaintMaster", Schema = "Inventory")]
    public class PaintMaster
    {
        [Key]
        public int PaintMasterId { get; set; }

        public PaintColour PaintColour { get; set; }
        public int PaintColourId { get; set; }

        public PaintVolume PaintVolume { get; set; }
        public int VolumeId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
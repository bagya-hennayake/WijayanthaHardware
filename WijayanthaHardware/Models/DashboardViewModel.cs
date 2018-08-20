using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Models
{
    public class DashboardViewModel
    {
        //define a properrty for holding the paint count, so define i6t
        public int PaintAvailabiltyCount { get; set; }
        public string PaintName { get; set; }

        //liken the above two lines, d3efine properties for powertool below
        // use short hand notation, type "prop" and press tab twice
        public int PowerToolAvailabilityCount { get; set; }
        public string ToolName { get; set; }
        public string Type { get; set; }
        //ok good, now will use this as the dash board view modle

        //public List<PaintViewModel> PaintViewModels { get; set; }
        //public List<PowerToolsViewModel> PowerToolViewModel { get; set; }
    }
}
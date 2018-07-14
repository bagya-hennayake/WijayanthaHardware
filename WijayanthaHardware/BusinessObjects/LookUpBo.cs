using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.BusinessObjects
{
    public class LookUpBO
    {
        public int LookUpId { get; set; }
        public string LookUpValue { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
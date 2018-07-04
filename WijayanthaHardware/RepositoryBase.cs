using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WijayanthaHardware.DBContext;

namespace WijayanthaHardware
{
    public class RepositoryBase
    {
        private readonly WijayanathaDb _wijayanathaDb;

        public RepositoryBase(WijayanathaDb wijayanathaDb)
        {
            _wijayanathaDb = wijayanathaDb;
        }

        public WijayanathaDb CreateContext()
        {
            return _wijayanathaDb;
        }
    }
}
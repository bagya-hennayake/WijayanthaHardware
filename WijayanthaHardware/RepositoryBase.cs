using WijayanthaHardware.DBContext;

namespace WijayanthaHardware
{
    public abstract class RepositoryBase
    {
        private WijayanathaDb _wijayanathaDb;

        public WijayanathaDb CreateContext()
        {
            return _wijayanathaDb ?? new WijayanathaDb();
        }
    }
}
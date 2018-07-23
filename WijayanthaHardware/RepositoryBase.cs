using WijayanthaHardware.DBContext;

namespace WijayanthaHardware
{
    public abstract class RepositoryBase
    {
        public WijayanathaDb CreateContext()
        {
            return new WijayanathaDb();
        }
    }
}
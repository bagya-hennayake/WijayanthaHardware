using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.DBContext;

namespace WijayanthaHardware.Services
{
    public class LoginService : RepositoryBase
    {
        public LoginService(WijayanathaDb wijayanathaDb) : base(wijayanathaDb) { }

        public async Task<bool> AuthenticateUser(LoginBO loginBo)
        {
            using (var context = CreateContext())
            {
                return await context.User.AsNoTracking().Where(w => w.Username == loginBo.Username && w.Password == loginBo.UserPassword && w.Status == (int)RecordStatusEnum.Active).AnyAsync();
            }

        }
    }
}
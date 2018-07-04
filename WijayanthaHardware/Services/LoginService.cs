using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.DBContext;

namespace WijayanthaHardware.Services
{
    public class LoginService : RepositoryBase
    {
        public LoginService(WijayanathaDb wijayanathaDb) : base(wijayanathaDb) { }

        public bool AuthenticateUser(LoginBO loginBo)
        {
            using (var context = CreateContext())
            {
                return context.User.AsNoTracking().Where(w => w.Username == loginBo.Username && w.Password == loginBo.UserPassword && w.Status == (int)RecordStatusEnum.Active).Any();
            }

        }
    }
}
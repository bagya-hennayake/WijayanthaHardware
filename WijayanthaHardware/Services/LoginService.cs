using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using WijayanthaHardware.BusinessObjects;
using WijayanthaHardware.Common;
using WijayanthaHardware.DBContext;

namespace WijayanthaHardware.Services
{
    public class LoginService : RepositoryBase
    {
        public async Task<bool> AuthenticateUser(LoginBO loginBo)
        {
            using (var context = CreateContext())
            {
                return await context.User.AsNoTracking().Where(w => w.Username == loginBo.Username && w.Password == loginBo.UserPassword && w.Status == (int)RecordStatusEnum.Active).AnyAsync();
            }

        }
        public void SetFormsAuthentication(HttpContextBase httpContextBase, LoginBO loginBO)
        {


            var ticket = new FormsAuthenticationTicket(
                loginBO.Username,
                false,
                10000
                );
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            httpContextBase.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { Expires = DateTime.Now.AddYears(1) });
        }
    }


}
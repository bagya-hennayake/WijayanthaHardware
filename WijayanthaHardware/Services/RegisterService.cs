using System.Threading.Tasks;
using System.Data.Entity;
using WijayanthaHardware.DBContext;
using WijayanthaHardware.Common;
using WijayanthaHardware.Models;
using WijayanthaHardware.Entities;

namespace WijayanthaHardware.Services
{
    public class RegisterService : RepositoryBase
    {
        public RegisterService(WijayanathaDb wijayanathaDb) : base(wijayanathaDb)
        {
        }
        public async Task<bool> CheckIfUserNameExists(string Username)
        {
            using (var context = CreateContext())
            {
                var userNameExists = await context.User.AsNoTracking().AnyAsync(a => a.Username == Username && a.Status == (int)RecordStatusEnum.Active);
                return userNameExists;

            }
        }

        public async Task RegisterNewUserAsync(RegisterViewModel registerViewModel)
        {
            using (var context = CreateContext())
            {
                var NewUserInfo = new User()
                {
                    Username = registerViewModel.Username,
                    Password = registerViewModel.UserPassword,
                    Status = (int)RecordStatusEnum.Active
                };

                context.User.Add(NewUserInfo);
                await context.SaveChangesAsync();
            }
        }

    }
}
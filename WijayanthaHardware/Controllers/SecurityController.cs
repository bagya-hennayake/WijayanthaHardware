using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using WijayanthaHardware.Common;
using WijayanthaHardware.Models;
using WijayanthaHardware.Services;

namespace WijayanthaHardware.Controllers
{
    [Authorize]
    public class SecurityController : Controller
    {
        private readonly LoginService _loginService;
        private readonly RegisterService _registerService;

        public SecurityController(LoginService loginService, RegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            var loginBo = loginViewModel.Mapper(loginViewModel);
            var result = await _loginService.AuthenticateUser(loginBo);
            if (result)
            {
                _loginService.SetFormsAuthentication(this.HttpContext, loginBo);
                return Json(new { status = "redirect", redirectURL = loginViewModel.ReturnUrl ?? "/Home/DashBoard" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = TransactionStatusEnum.error.ToString(), title = "Login Failed", message = "Invalid username or password" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            registerViewModel.UserPassword = FormsAuthentication. HashPasswordForStoringInConfigFile(registerViewModel.UserPassword, "SHA1");
            await _registerService.RegisterNewUserAsync(registerViewModel);
            return RedirectToAction("DashBoard", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<JsonResult> DoesUsernameExist(string Username)
        {
            var doesUserExist = await _registerService.CheckIfUserNameExists(Username);
            return Json(!doesUserExist);
        }
    }
}
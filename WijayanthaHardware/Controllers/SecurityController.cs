using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
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
            ViewBag.returnURL = ReturnUrl;
            return View(new LoginViewModel());
        }


        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            registerViewModel.UserPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(registerViewModel.UserPassword, "SHA1");
            await _registerService.RegisterNewUserAsync(registerViewModel);
            return RedirectToAction("DashBoard", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel, string ReturnUrl)
        {
            var loginBo = loginViewModel.Mapper(loginViewModel);
            var result = await _loginService.AuthenticateUser(loginBo);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(loginBo.Username, false);
                FormsAuthentication.RedirectFromLoginPage(loginBo.Username, false);
                if (Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("DashBoard", "Home");
            }
            return View("Login", loginViewModel);
            //return Json(new { status = TransactionStatusEnum.error, message = "Invalid username or password" }, JsonRequestBehavior.AllowGet);
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
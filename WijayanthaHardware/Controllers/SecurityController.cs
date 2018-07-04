using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WijayanthaHardware.Models;
using WijayanthaHardware.Services;

namespace WijayanthaHardware.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly LoginService _loginService;

        public SecurityController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.returnURL = ReturnUrl;
            return View(new LoginViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel, string ReturnUrl)
        {
            var loginBo = loginViewModel.Mapper(loginViewModel);
            var result = _loginService.AuthenticateUser(loginBo);
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
        }
    }
}
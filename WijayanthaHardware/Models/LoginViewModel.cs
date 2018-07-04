using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using WijayanthaHardware.BusinessObjects;

namespace WijayanthaHardware.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }



        public LoginBO Mapper(LoginViewModel loginViewModel)
        {
            loginViewModel.UserPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(loginViewModel.UserPassword, "SHA1");
            return new LoginBO
            {
                Username = loginViewModel.Username,
                UserPassword = loginViewModel.UserPassword
            };
        }
    }
}
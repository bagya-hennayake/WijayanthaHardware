using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WijayanthaHardware.Models
{
    public class RegisterViewModel
    {
        [Remote("DoesUsernameExist", "Security", HttpMethod = "POST", ErrorMessage = "This username is already taken.")]
        [Required(ErrorMessage = "Please enter a username to register")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("UserPassword",ErrorMessage ="Passwords doesn't match")]
        public string ConfirmUserPassword { get; set; }
    }
}
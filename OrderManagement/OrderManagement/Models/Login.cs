using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderManagement.Models
{
    public class Login
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an email address")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "Please match the requested format. Ex. Jhon@gmail.com")]
        public string email_address { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }

    public class LoginResponse
    {
        public Guid user_id { get; set; }
        public string email_address { get; set; }
        public string user_role { get; set; }
    }
}
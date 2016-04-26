using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pleaseAnswer.Models
{
    public class LoginModel
    {
        [Display(Name = "学号")]
        [Required(ErrorMessage = "必填")]
        public string StuNumber { set; get; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "必填")]
        public string Password { set; get; }
    }
}
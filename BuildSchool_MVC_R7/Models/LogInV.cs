﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class LogInV
    {
        [Required(ErrorMessage = "請輸入帳號 Account Number")]
        [Display(Name = "帳號 Account Number")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入密碼 Password")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼 Password")]
        public string Password { get; set; }
    }
}
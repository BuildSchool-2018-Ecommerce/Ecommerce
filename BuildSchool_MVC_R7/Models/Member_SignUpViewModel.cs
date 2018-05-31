using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class Member_SignUpViewModel
    {
        [Required(ErrorMessage = "請輸入帳號 Account Number")]
        [MaxLength(50, ErrorMessage = "長度過長")]
        [Display(Name = "帳號 Account Number")]
        public string MemberID { get; set; }

        [Required(ErrorMessage = "請輸入密碼 Password")]
        [MinLength(8, ErrorMessage = "長度過短")]
        [MaxLength(50, ErrorMessage = "長度過長")]
        [Display(Name = "密碼 Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "請輸入姓名 Name")]
        [MaxLength(50, ErrorMessage = "長度過長")]
        [Display(Name = "姓名 Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請輸入電子郵件 E-Mail")]
        [MaxLength(50, ErrorMessage = "長度過長")]
        [Display(Name = "電子郵件 E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入手機號碼 Phone")]
        [MaxLength(24, ErrorMessage = "長度過長")]
        [Display(Name = "手機號碼 Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "請輸入地址 Address")]
        [MaxLength(60, ErrorMessage = "長度過長")]
        [Display(Name = "地址 Address")]
        public string Address { get; set; }
    }
}
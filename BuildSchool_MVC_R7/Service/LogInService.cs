using BuildSchool_MVC_R7.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool.PasswordValidationTool.Client;
using System.Text;

namespace BuildSchool_MVC_R7.Service
{
    public class LogInService
    {
        public HttpCookie LogIn(string account, string password)
        {
            var service = ContainerManager.Container.GetInstance<IPasswordValidationService>();
            var memberrepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var member = memberrepository.FindById(account);
            if (member != null)
            {
                byte[] userPwdData = Encoding.UTF8.GetBytes(password);
                byte[] saltData = Encoding.UTF8.GetBytes(member.MemberGUID.ToString());
                if (service.ValidatePassword(member.Password, userPwdData, saltData))
                {
                    var hc = new HttpCookie("R7CompanyMember", member.MemberID)
                    {
                        Expires = DateTime.Now.AddHours(6),
                        HttpOnly = true
                    };
                    return hc;
                }
            }      
            return null;
        }
    }
}
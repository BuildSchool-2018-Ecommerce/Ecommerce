using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool.PasswordValidationTool.Client;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace BuildSchool_MVC_R7.Service
{
    public class MemberService
    {
        public bool SignUp(Members model)
        {
            var service = ContainerManager.Container.GetInstance<IPasswordValidationService>();
            var memberrepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var member = memberrepository.FindById(model.MemberID);
            if (member == null)
            {
                byte[] userPwdData = Encoding.UTF8.GetBytes(model.Password);
                var token = Guid.NewGuid();
                model.MemberGUID = token;
                byte[] saltData = Encoding.UTF8.GetBytes(token.ToString());
                byte[] storedPwdHashed = service.HashPassword(userPwdData, saltData);
                string pass = Encoding.UTF8.GetString(storedPwdHashed);
                model.Password = pass;
                memberrepository.Create(model);
                return true;
            }
            return false;
        }
    }
}
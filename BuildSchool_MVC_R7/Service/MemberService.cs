using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool_MVC_R7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class MemberService
    {
        public MemberViewModel GetMembers()
        {
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var memberViewModel = new MemberViewModel()
            {
                Members = memberRepository.GetAll().ToList()
            };
            return memberViewModel;
        }

        public MemberViewModel GetMemberById(string memberId)
        {
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var memberViewModel = new MemberViewModel()
            {
                Member = memberRepository.FindById(memberId)
            };
            return memberViewModel;
        }
    }
}
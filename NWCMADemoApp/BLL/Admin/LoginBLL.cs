using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Admin;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.BLL.Admin
{
    public class LoginBLL
    {
        LoginDAL loginDal = new LoginDAL();

        public bool IsCodePasswordExist(LoginModel loginModel)
        {
            return loginDal.IsCodePasswordExist(loginModel);
        }

        public LoginModel GetLoginTypeAndName(LoginModel loginModel)
        {
            return loginDal.GetLoginTypeAndName(loginModel);
        }
    }
}
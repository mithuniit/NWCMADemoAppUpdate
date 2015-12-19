using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NWCMADemoApp.BLL.Admin;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.Pages.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        LoginBLL loginBll = new LoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            LoginModel loginModel = new LoginModel();
            loginModel.Code = codeTextBox.Text;
            loginModel.Password = passwoedTextBox.Text;

            if (!loginBll.IsCodePasswordExist(loginModel))
            {
                failStatusLabel.InnerText = "Enter correct information";
            }
            else
            {
               
               Session["loginInformation"] = loginBll.GetLoginTypeAndName(loginModel);
                Response.Redirect("~/Pages/Admin/AdminHome.aspx");
                
              
            }
        }
    }
}
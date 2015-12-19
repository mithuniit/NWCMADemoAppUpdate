using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NWCMADemoApp.Pages.MasterPages
{
    public partial class MasterPageAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void logOutButton_OnServerClick(object sender, EventArgs e)
        {
            Session.RemoveAll();
        
            Response.Redirect("~/Pages/Admin/AdminHome.aspx");
        }
    }
}
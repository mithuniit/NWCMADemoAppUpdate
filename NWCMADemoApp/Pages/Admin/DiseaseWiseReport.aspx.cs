using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NWCMADemoApp.BLL.Admin;

namespace NWCMADemoApp.Pages.Admin
{
    public partial class DiseaseWiseReport : System.Web.UI.Page
    {
        DiseaseEntryBLL diseaseEntryBll = new DiseaseEntryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDiseaseInDropDownlist();
                ListItem liDisease = new ListItem("Select disease","-1");
                diseaseDropdownList.Items.Insert(0,liDisease);
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            date1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            date2.Text = Calendar3.SelectedDate.ToShortDateString();
        }

        public void GetAllDiseaseInDropDownlist()
        {
            diseaseDropdownList.DataSource = diseaseEntryBll.GetAllDisease();
            diseaseDropdownList.DataTextField = "Name";
            diseaseDropdownList.DataValueField = "ID";
            diseaseDropdownList.DataBind();
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
             
        }

    }
}
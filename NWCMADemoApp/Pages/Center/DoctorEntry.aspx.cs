using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NWCMADemoApp.BLL.Center;
using NWCMADemoApp.Models.AdminModel;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.Pages.Center
{
    public partial class DoctorEntry : System.Web.UI.Page
    {
        DoctorEntryBLL doctorEntryBll = new DoctorEntryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllDoctorInGridView();
        }

        protected void saveDoctorButton_Click(object sender, EventArgs e)
        {
            // Get the center id from session
            LoginModel loginModel = new LoginModel();
            loginModel = (LoginModel)Session["loginInformation"];

            DoctorModel doctorModel = new DoctorModel();
            doctorModel.Name = doctorNameTextBox.Text;
            doctorModel.Degree = degreeTextBox.Text;
            doctorModel.Specialization = specializationTextBox.Text;
            doctorModel.CenterId = loginModel.ID;
            if (doctorEntryBll.SaveDoctor(doctorModel) > 0)
            {
                failStatusLabel.InnerText = "";
                successStatusLabel.InnerText = "Doctor name saved";
                GetAllDoctorInGridView();

            }
            else
            {
                successStatusLabel.InnerText = "";
                failStatusLabel.InnerText = "Doctor name not saved";

            }
        }

        public void GetAllDoctorInGridView()
        {
            doctorGridView.DataSource = doctorEntryBll.GetAllDoctor();
            doctorGridView.DataBind();
        }

        protected void doctorGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            doctorGridView.PageIndex = e.NewPageIndex;
            GetAllDoctorInGridView();
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NWCMADemoApp.BLL.Center;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.Pages.Center
{
    public partial class TreatmentHistory : System.Web.UI.Page
    {
        PatientHistoryBLL patientHistoryBll = new PatientHistoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void showDetailsButton_Click(object sender, EventArgs e)
        {
            int voterId =  Convert.ToInt32(voterIdTextBox.Text);
            List<PatientInformationModel> patientHistoryModels = new List<PatientInformationModel>();
            patientHistoryModels = patientHistoryBll.GetAllHistory(voterId);

            foreach (PatientInformationModel myHistory in patientHistoryModels)
            {
                patientNameTextBox.Text =  myHistory.Name;
                addressTextBox.Text = myHistory.Address;
                string serviceDate = myHistory.ServiceDate;

                TextBox centerNameTextBox = new TextBox();
                TextBox dateTextBox = new TextBox();
                TextBox doctorTextBox = new TextBox();
                TextBox observationTextBox = new TextBox();
                centerNameTextBox.Text = myHistory.CenterName;
                dateTextBox.Text = myHistory.Doctor;
                observationTextBox.Text = myHistory.Observation;
                PlaceHolder PlaceHolder1 = new PlaceHolder();
                PlaceHolder1.Controls.Add(centerNameTextBox);
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                
                //Controls.Add(centerNameTextBox);
            //    form1.Controls.Add(dateTextBox);
            //    form1.Controls.Add(doctorTextBox);
            //    form1.Controls.Add(observationTextBox);
            }
            


        }
    }
}
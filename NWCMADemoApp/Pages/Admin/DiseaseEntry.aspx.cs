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
    public partial class DiseaseEntry : System.Web.UI.Page
    {
        DiseaseEntryBLL diseaseEntryBll = new DiseaseEntryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllDiseaseInGridView();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            DiseaseModel diseaseModel = new DiseaseModel();
            diseaseModel.Name = diseaseTextBox.Text;
            diseaseModel.Description = descriptionTextBox.Text;
            diseaseModel.Procedure = procedureTextBox.Text;

            if (diseaseEntryBll.IsDiseaseExist(diseaseModel))
            {
                successSpan.InnerText = "";
               failSpan.InnerText = "Disease name already exist";
                
            }
            else
            {
                if (diseaseEntryBll.SaveDisease(diseaseModel) > 0)
                {
                    failSpan.InnerText = "";
                    successSpan.InnerText = "Disease name saved";
                    
                    GetAllDiseaseInGridView();
                }
                else
                {
                    successSpan.InnerText = "";
                    failSpan.InnerText = "Disease name not saved";

                }
            }

        }


        public void GetAllDiseaseInGridView()
        {
            diseaseGridView.DataSource = diseaseEntryBll.GetAllDisease();
            diseaseGridView.DataBind();
        }
    }
}
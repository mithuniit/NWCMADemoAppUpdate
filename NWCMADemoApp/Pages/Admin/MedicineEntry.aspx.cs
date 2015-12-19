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
    public partial class MedicineEntry : System.Web.UI.Page
    {
        MedicineEntryBLL medicineEntryBll = new MedicineEntryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllMedicineInGridView();
        }



        public void GetAllMedicineInGridView()
        {
            medicineGridView.DataSource = medicineEntryBll.GetAllMedicine();
            medicineGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            MedicineModel medicineModel = new MedicineModel();
            medicineModel.Name = medicineNameTextBox.Text;

            if (medicineEntryBll.IsMedicineExist(medicineModel))
            {
                successStatusLabel.InnerText = "";
                failStatusLabel.InnerText = "Medicine already exist";
            }
            else
            {
                if (medicineEntryBll.SaveMedicine(medicineModel) > 0)
                {
                    failStatusLabel.InnerText = "";
                    successStatusLabel.InnerText = "Medicine saved";
                    ClearAllField();
                    GetAllMedicineInGridView();
                }
                else
                {
                    successStatusLabel.InnerText = "";
                    failStatusLabel.InnerText = "Medicine not saved";

                }
            }

        }

        public void ClearAllField()
        {
            medicineNameTextBox.Text = "";
        }
    }
}
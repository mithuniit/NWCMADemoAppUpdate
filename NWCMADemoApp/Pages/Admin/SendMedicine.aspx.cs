using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NWCMADemoApp.BLL.Admin;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.Pages.Admin
{
    public partial class SendMedicine : System.Web.UI.Page
    {
        CreateCenterBLL createCenterBll = new CreateCenterBLL();
        SendMedicineBLL sendMedicineBll = new SendMedicineBLL();
        DataTable dataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetAllDistrictInDropdown();
                ListItem listItem = new ListItem("Select district", "-1");
                districtDropDownList.Items.Insert(0, listItem);

               ListItem listItem1 = new ListItem("Select thana", "-1");
               thanaDropDownList.Items.Insert(0, listItem1);
               thanaDropDownList.Enabled = false;
                // GetAllThanaInDropdown();

                //GetAllCenterInDropdown();
                ListItem listItemCenter = new ListItem("Select center", "-1");
                centerNameDropDownList.Items.Insert(0, listItemCenter);
                centerNameDropDownList.Enabled = false;

                GetAllMedicineInDropdown();
                ListItem listItemMedicine = new ListItem("Select medicine", "-1");
                medicineDropDownList.Items.Insert(0, listItemMedicine);

                PopulateGridView();
            }

        }




        public void GetAllDistrictInDropdown()
        {
            districtDropDownList.DataSource = createCenterBll.GetAllDistrict();
            districtDropDownList.DataTextField = "Name";
            districtDropDownList.DataValueField = "ID";
            districtDropDownList.DataBind();
        }

        public void GetAllThanaInDropdown(DistrictModel districtModel)
        {
            thanaDropDownList.DataSource = createCenterBll.GetAllThana(districtModel);
            thanaDropDownList.DataTextField = "Name";
            thanaDropDownList.DataValueField = "ID";
            thanaDropDownList.DataBind();
        }

        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictModel districtModel = new DistrictModel();
            districtModel.ID = Convert.ToInt32(districtDropDownList.SelectedValue);
            GetAllThanaInDropdown(districtModel);
            thanaDropDownList.Enabled = true;
           ListItem listItem1 = new ListItem("Select thana", "-1");
           thanaDropDownList.Items.Insert(0, listItem1);
        }


        public void GetAllCenterInDropdown()
        {
            ThanaModel thanaModel = new ThanaModel();
            thanaModel.ID = Convert.ToInt32(thanaDropDownList.SelectedValue);
            centerNameDropDownList.DataSource = sendMedicineBll.GetAllCenterName(thanaModel);
            centerNameDropDownList.DataTextField = "Name";
            centerNameDropDownList.DataValueField = "ID";
            centerNameDropDownList.DataBind();
        }

        protected void thanaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
                  GetAllCenterInDropdown();
                  ListItem listItemCenter = new ListItem("Select center", "-1");
                  centerNameDropDownList.Items.Insert(0, listItemCenter);
            centerNameDropDownList.Enabled = true;
        }

        //Medicine

        public void GetAllMedicineInDropdown()
        {
            medicineDropDownList.DataSource = sendMedicineBll.GetAllMedicineName();
            medicineDropDownList.DataTextField = "Name";
            medicineDropDownList.DataValueField = "ID";
            medicineDropDownList.DataBind();
        }

        public void PopulateGridView()
        {
            dataTable.Columns.Add("Name",typeof(string));
            dataTable.Columns.Add("Quantity", typeof (string));
            Session["initialGridViewData"] = dataTable;
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (quantityTextBox.Text == string.Empty || medicineDropDownList.SelectedValue == "-1" || centerNameDropDownList.SelectedValue == "-1")
            {
                failStatusLabel.InnerText = "Please enter the information";
            }
            else
            {
                failStatusLabel.InnerText = "";
                if (Session["initialGridViewData"] == null)
                {
                    PopulateGridView();
                }
                else
                {
                    dataTable = (DataTable)Session["initialGridViewData"];

                    var data = 0;
                    foreach (DataRow row in (dataTable.AsEnumerable().Where(q => q.Field<string>("Name") == medicineDropDownList.SelectedItem.Text)))
                        data++;

                    if (data <= 0)
                        dataTable.Rows.Add(medicineDropDownList.SelectedItem.Text, quantityTextBox.Text);
                    else
                    {
                        foreach (
                            DataRow row in
                                (dataTable.AsEnumerable()
                                    .Where(q => q.Field<string>("Name") == medicineDropDownList.SelectedItem.Text)))
                        {
                            row["quantity"] = Convert.ToInt32(row["quantity"]) + Convert.ToInt32(quantityTextBox.Text);
                        }
                        //dataTable.Rows.Add(medicineDropDownList.SelectedItem.Text, quntity);
                    }
                     
                    dataTable.AcceptChanges();
                    Session["initialGridViewData"] = dataTable;
                    addMedicineGridView.DataSource = dataTable;
                    addMedicineGridView.DataBind();
                }
 
            }
           
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            
                if (districtDropDownList.SelectedValue == "-1" || thanaDropDownList.SelectedValue == "-1" || centerNameDropDownList.SelectedValue == "-1" || medicineDropDownList.SelectedValue == "-1")
                {
                    sendMedicineFailStatusLabel.InnerText = "Please select information from dropdownlist";
                    sendMedicineSuccessStatusLabel.InnerText = "";
                }
                else
                {

                    SendMedicineModel sendMedicineModel = new SendMedicineModel();
                    foreach (GridViewRow row in addMedicineGridView.Rows)
                    {
                        TextBox txtBox = (TextBox)row.FindControl("TextBox");
                        string medicineName = row.Cells[0].Text;
                        sendMedicineModel.MedicineId = sendMedicineBll.GetSelectedMedicineId(medicineName);
                        sendMedicineModel.Quantity = Convert.ToInt32(row.Cells[1].Text);
                        sendMedicineModel.CenterId = Convert.ToInt32(centerNameDropDownList.SelectedValue);
                        sendMedicineModel.ThanaId = Convert.ToInt32(thanaDropDownList.SelectedValue);
                        sendMedicineModel.DistrictId = Convert.ToInt32(districtDropDownList.SelectedValue);


                        if (sendMedicineBll.IsMedicineQuantityExist(sendMedicineModel))
                        {
                            if (sendMedicineBll.UpdateSendMedicine(sendMedicineModel) > 0)
                            {
                                sendMedicineSuccessStatusLabel.InnerText = "Medicine quantity updated successfully.";
                                sendMedicineFailStatusLabel.InnerText = "";

                                Session["initialGridViewData"] = null;
                                addMedicineGridView.DataSource = null;
                                addMedicineGridView.DataBind();
                            }
                            else
                            {
                                sendMedicineSuccessStatusLabel.InnerText = "";
                                sendMedicineFailStatusLabel.InnerText = "Medicine quantity not updated.";
                            }
                        }
                        else
                        {
                            if (sendMedicineBll.SaveSendMedicine(sendMedicineModel) > 0)
                            {

                                sendMedicineSuccessStatusLabel.InnerText = "Medicine quantity saved successfully.";
                                sendMedicineFailStatusLabel.InnerText = "";
                                Session["initialGridViewData"] = null;
                                addMedicineGridView.DataSource = null;
                                addMedicineGridView.DataBind();
                            }
                            else
                            {
                                sendMedicineSuccessStatusLabel.InnerText = "";
                                sendMedicineFailStatusLabel.InnerText = "Medicine quantity not saved";
                            }
                        }

                    }





                
            }
            

           
        }

       



    }
}
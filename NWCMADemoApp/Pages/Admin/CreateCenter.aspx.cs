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
    public partial class CreateCenter : System.Web.UI.Page
    {
        CreateCenterBLL createCenterBll = new CreateCenterBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDistrictInDropdown();
                ListItem listItem = new ListItem("Select district","-1");
                districtDropDownList.Items.Insert(0,listItem);

                ListItem listItem1 = new ListItem("Select thana", "-1");
                thaneDropDownList.Items.Insert(0, listItem1);
                thaneDropDownList.Enabled = false;
                // GetAllThanaInDropdown();
            }
        }




        protected void saveButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int code = rnd.Next(1000, 2000); // creates a number between 1 and 12



            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var password = new String(stringChars);






            int loginType = 2;
            CenterModel centerModel = new CenterModel();
            centerModel.Name = centerNameTextBox.Text;
            centerModel.Code = code.ToString();
            centerModel.Password = password;
            centerModel.DistrictID = Convert.ToInt32(districtDropDownList.SelectedValue);
            centerModel.ThanaId = Convert.ToInt32(thaneDropDownList.SelectedValue);
            centerModel.LoginType = loginType;

            
                if (createCenterBll.IsCenterExist(centerModel))
                {
                    successStatusLabel.InnerText = "";
                    failStatusLabel.InnerText = "Center name already exist";

                }
                else
                {
                    if (createCenterBll.SaveCenter(centerModel) > 0)
                    {

                        //Response.Write("<script>");
                        //Response.Write("window.open('CreatedCenterInformation.aspx','_blank')");
                        //Response.Write("</script>");

                        Response.Redirect("CreatedCenterInformation.aspx");

                    }
                    else
                    {
                        failStatusLabel.InnerText = "Disease name not saved";
                    }
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
            thaneDropDownList.DataSource = createCenterBll.GetAllThana(districtModel);
            thaneDropDownList.DataTextField = "Name";
            thaneDropDownList.DataValueField = "ID";
            thaneDropDownList.DataBind();
        }

        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictModel districtModel = new DistrictModel();
            districtModel.ID = Convert.ToInt32(districtDropDownList.SelectedValue);
            GetAllThanaInDropdown(districtModel);
            thaneDropDownList.Enabled = true;
            ListItem listItem1 = new ListItem("Select thana", "-1");
            thaneDropDownList.Items.Insert(0, listItem1);
        }
    }
}
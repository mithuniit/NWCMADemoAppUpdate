using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NWCMADemoApp.BLL.Center;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.Pages.Center
{
    public partial class MedicineStockReport : System.Web.UI.Page
    {
        MedicineStockBLL medicineStockBll = new MedicineStockBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllStockReportInGridView();
        }

        private void GetAllStockReportInGridView()
        {
            LoginModel loginModel = new LoginModel();
            loginModel = (LoginModel)Session["loginInformation"];
            int centerId = loginModel.ID;
            medicineStockGridView.DataSource = medicineStockBll.GetAllStockReportByCenter(centerId);
            medicineStockGridView.DataBind();
        }
    }
}
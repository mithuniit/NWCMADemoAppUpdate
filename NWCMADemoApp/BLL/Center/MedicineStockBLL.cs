using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Center;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.BLL.Center
{
    public class MedicineStockBLL
    {
        MedicineStockDAL medicineStockDal= new MedicineStockDAL();

        public List<MedicineStockModel> GetAllStockReportByCenter(int centerId)
        {
            return medicineStockDal.GetAllStockInformation(centerId);
        }

    }
}
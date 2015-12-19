using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Admin;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.BLL.Admin
{
    public class SendMedicineBLL
    {
        SendMedicineDAL sendMedicineDal = new SendMedicineDAL();


        public List<CenterModel> GetAllCenterName(ThanaModel thanaModel)
        {
            return sendMedicineDal.GetAllCenter(thanaModel);
        }

        public List<MedicineModel> GetAllMedicineName()
        {
            return sendMedicineDal.GetAllMedicine();
        }

        public int GetSelectedMedicineId(string medicineName)
        {
            return sendMedicineDal.GetSelectedMedicineId(medicineName);
        }

        public int SaveSendMedicine(SendMedicineModel sendMedicineModel)
        {
            return sendMedicineDal.SaveSendMedicine(sendMedicineModel);
        }
        public int UpdateSendMedicine(SendMedicineModel sendMedicineModel)
        {
            return sendMedicineDal.UpdateSendMedicine(sendMedicineModel);
        }
        public bool IsMedicineQuantityExist(SendMedicineModel sendMedicineModel)
        {
            return sendMedicineDal.IsMedicineQuantityExist(sendMedicineModel);
        }

    }
}
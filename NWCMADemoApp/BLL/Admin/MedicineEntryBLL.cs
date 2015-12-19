using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Admin;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.BLL.Admin
{
    public class MedicineEntryBLL
    {
        MedicineEntryDAL medicineEntryDal = new MedicineEntryDAL();

        public int SaveMedicine(MedicineModel medicineModel)
        {
            return medicineEntryDal.SaveMedicine(medicineModel);
        }

        public bool IsMedicineExist(MedicineModel medicineModel)
        {
            return medicineEntryDal.IsMedicineExist(medicineModel);
        }

        public List<MedicineModel> GetAllMedicine()
        {
            return medicineEntryDal.GetAllMedicine();
        }
    }
}
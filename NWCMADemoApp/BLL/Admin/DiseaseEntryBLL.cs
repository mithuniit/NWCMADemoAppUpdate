using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Admin;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.BLL.Admin
{
    public class DiseaseEntryBLL
    {
        DiseaseEntryDAL diseaseEntryDal = new DiseaseEntryDAL();

        public int SaveDisease(DiseaseModel diseaseModel)
        {
            return diseaseEntryDal.SaveDisease(diseaseModel);
        }

        public bool IsDiseaseExist(DiseaseModel diseaseModel)
        {
            return diseaseEntryDal.IsDiseaseExist(diseaseModel);
        }

        public List<DiseaseModel> GetAllDisease()
        {
            return diseaseEntryDal.GetAllDisease();
        }
    }
}
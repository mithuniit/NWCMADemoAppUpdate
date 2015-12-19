using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Admin;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.BLL.Admin
{
    public class CreateCenterBLL
    {
        CreateCenterDAL createCenterDal = new CreateCenterDAL();

        public List<DistrictModel> GetAllDistrict()
        {
            return createCenterDal.GetAllDistrict();
        }


        public List<ThanaModel> GetAllThana(DistrictModel districtModel)
        {
            return createCenterDal.GetAllThana(districtModel);
        }




        //dfrd dfgrsgre




        public int SaveCenter(CenterModel centerModel)
        {
            return createCenterDal.SaveCenter(centerModel);
        }

        public bool IsCenterExist(CenterModel centerModel)
        {
            return createCenterDal.IsCenterExist(centerModel);
        }

        public List<CenterModel> GetAllCenter()
        {
            return createCenterDal.GetAllCenter();
        }
    }
}
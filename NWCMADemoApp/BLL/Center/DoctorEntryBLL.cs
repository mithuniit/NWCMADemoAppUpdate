using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Center;
using NWCMADemoApp.Models.AdminModel;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.BLL.Center
{
    public class DoctorEntryBLL
    {
        DoctorEntryDAL doctorEntryDal = new DoctorEntryDAL();

        public List<CenterModel> GetAllCenter()
        {
            return doctorEntryDal.GetAllCenter();
        }
        public int SaveDoctor(DoctorModel doctorModel)
        {
            return doctorEntryDal.SaveDoctor(doctorModel);
        }
        public List<DoctorModel> GetAllDoctor()
        {
            return doctorEntryDal.GetAllDoctor();
        }
    }
}
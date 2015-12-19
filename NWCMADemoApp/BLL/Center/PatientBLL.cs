using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Center;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.BLL.Center
{
    public class PatientBll
    {
        PatientDal patientDal= new PatientDal();

        public int NumberOfService(string voterId)
        {
            return patientDal.NumberOfService(voterId);
        }

        public int PatientEntry(PatientModel patient)
        {
            return patientDal.PatientEntry(patient);
        }
    }
}
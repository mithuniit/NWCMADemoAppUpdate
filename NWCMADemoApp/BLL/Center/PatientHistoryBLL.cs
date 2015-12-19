using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Center;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.BLL.Center
{
    public class PatientHistoryBLL
    {
        PatientHistoryDAL patientHistoryDal = new PatientHistoryDAL();

        public List<PatientInformationModel> GetAllHistory(int voterID)
        {
            return patientHistoryDal.GetAllHistory(voterID);
        }

        public int PatientHistoryEntry(PatientHistoryModel patientHistory)
        {
            return patientHistoryDal.PatientHistoryEntry(patientHistory);
        }
    }
}
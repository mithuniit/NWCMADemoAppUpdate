using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWCMADemoApp.DAL.Center;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.BLL.Center
{
    public class DoseBLL
    {
        DoseDAL doseDal = new DoseDAL();


        public List<DoseModel> GetAllDose()
        {
            return doseDal.GetAllDose();
        }
    }
}
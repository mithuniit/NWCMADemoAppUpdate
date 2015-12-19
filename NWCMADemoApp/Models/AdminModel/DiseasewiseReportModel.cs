using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWCMADemoApp.Models.AdminModel
{
    public class DiseasewiseReportModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalPatient { get; set; }
        public int TotalPopulation { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWCMADemoApp.Models.AdminModel
{
    public class DiseaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Procedure { get; set; }
    }
}
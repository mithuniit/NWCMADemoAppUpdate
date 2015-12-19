using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWCMADemoApp.Models.CenterModel
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }

        public string Specialization { get; set; }
        public int CenterId { get; set; }
    }
}
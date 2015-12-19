using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWCMADemoApp.Models.CenterModel
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string VoterId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

    }
}
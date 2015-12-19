using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWCMADemoApp.Models.CenterModel
{
    public class TreatmentModel
    {
        public int  Id { get; set; }
        public int DiseaseId { get; set; }
        public int MedicineId { get; set; }
        public int  DoseId { get; set; }
        public int IndicationId { get; set; }
        public int Quantiry { get; set; }
        public string Note { get; set; }
        public int TreatmentHistoryId { get; set; }
    }
}
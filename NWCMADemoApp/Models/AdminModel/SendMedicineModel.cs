using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWCMADemoApp.Models.AdminModel
{
    public class SendMedicineModel
    {
        public int ID { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public int CenterId { get; set; }
        public int ThanaId { get; set; }
        public int DistrictId { get; set; }

    }
}
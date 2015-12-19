namespace NWCMADemoApp.Models.CenterModel
{
    public class PatientInformationModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CenterName { get; set; }
        public string ServiceDate { get; set; }
        public string Doctor { get; set; }
        public string Observation { get; set; }
        public string DiseaseName { get; set; }
        public string MedicineName { get; set; }
        public string Dose { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
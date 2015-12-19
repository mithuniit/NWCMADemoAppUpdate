using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using NWCMADemoApp.BLL.Admin;
using NWCMADemoApp.BLL.Center;
using NWCMADemoApp.Models.AdminModel;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.Pages.Center
{
    public partial class Treatment : System.Web.UI.Page
    {
        DoctorEntryBLL doctorEntryBll = new DoctorEntryBLL();
        MedicineEntryBLL medicineEntryBll = new MedicineEntryBLL();
        DiseaseEntryBLL diseaseEntryBll = new DiseaseEntryBLL();
        PatientHistoryBLL patientHistoryBll = new PatientHistoryBLL();
        TreatmentBll treatmentBll = new TreatmentBll();
        DoseBLL doseBll = new DoseBLL();
        PatientBll patientBll = new PatientBll();
        DataTable dataTable = new DataTable();
        private PatientModel patient=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDoctorInDropDownlist();
                ListItem liDoctor = new ListItem("Select doctor","-1");
                doctorDropDownList.Items.Insert(0,liDoctor);

                GetAllMedicineInDropDownlist();
                ListItem liMedicine = new ListItem("Select medicine", "-1");
                medicineDropDownList.Items.Insert(0, liMedicine);

                GetAllDiseaseInDropDownlist();
                ListItem liDisease = new ListItem("Select disease", "-1");
                diseaseDropdownList.Items.Insert(0, liDisease);

                GetAllDoseInDropDownlist();
                ListItem liDose = new ListItem("Select dose", "-1");
                doseDropdownList.Items.Insert(0, liDose);

            }
        }

        protected void showDetailsButton_Click(object sender, EventArgs e)
        {
            string idTextBoxValue = voterIdTextBox.Text;
            WebClient myWebClient = new WebClient();
            var jsonData = myWebClient.DownloadString("http://nerdcastlebd.com/web_service/voterdb/index.php/voters/all/format/json");
            JObject jObject = JObject.Parse(jsonData);

            foreach (JObject resultJObject in jObject["voters"])
            {

                string id = resultJObject["id"].ToString();
                
                if (idTextBoxValue == id)
                {
                    string name = resultJObject["name"].ToString();
                    string address = resultJObject["address"].ToString();
                    string dateOfBirth = (string)resultJObject["date_of_birth"];

                    int now = DateTime.Now.Year;
                    string[] result = dateOfBirth.Split('-');
                    int myDate = int.Parse(result[0].ToString());
                    int age = now - myDate;

                    patient= new PatientModel();
                    patient.VoterId = id;
                    patient.Name = name;
                    patient.Address = address;
                    patient.Age = age;

                    voterIdTextBox.Text = id;
                    patientNameTextBox.Text = name;
                    addressTextBox.Text = address;
                    ageTextBox.Text = age.ToString();
                    serviceNumberTextBox.Text=GetNumberOfSevice(id).ToString();
                    break;
                }
            }
        }

        public void GetAllDoctorInDropDownlist()
        {
            doctorDropDownList.DataSource = doctorEntryBll.GetAllDoctor();
            doctorDropDownList.DataTextField = "Name";
            doctorDropDownList.DataValueField = "ID";
            doctorDropDownList.DataBind();
        }

        public void GetAllMedicineInDropDownlist()
        {
            medicineDropDownList.DataSource = medicineEntryBll.GetAllMedicine();
            medicineDropDownList.DataTextField = "Name";
            medicineDropDownList.DataValueField = "ID";
            medicineDropDownList.DataBind();
        }
        public void GetAllDiseaseInDropDownlist()
        {
            diseaseDropdownList.DataSource = diseaseEntryBll.GetAllDisease();
            diseaseDropdownList.DataTextField = "Name";
            diseaseDropdownList.DataValueField = "ID";
            diseaseDropdownList.DataBind();
        }

        public void GetAllDoseInDropDownlist()
        {
            doseDropdownList.DataSource = doseBll.GetAllDose();
            doseDropdownList.DataTextField = "Dose";
            doseDropdownList.DataValueField = "ID";
            doseDropdownList.DataBind();
        }

        public int GetNumberOfSevice(string voterId)
        {
            return patientBll.NumberOfService(voterId);
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (Session["treatmentGridViewData"] == null)
            {
                PopulateGridView();
                InsertDataIntoGridView();
            }
            else
            {
                InsertDataIntoGridView();
            }
        }

        private void InsertDataIntoGridView()
        {
            dataTable = (DataTable) Session["treatmentGridViewData"];

            dataTable.Rows.Add(diseaseDropdownList.SelectedItem.Text, medicineDropDownList.SelectedItem.Text,
                doseDropdownList.SelectedItem.Text, medicineIndication.SelectedItem.Text, quantityTextBox.Text, noteTextBox.Text);
            dataTable.AcceptChanges();
            Session["treatmentGridViewData"] = dataTable;
            addMedicineGridView.DataSource = dataTable;
            addMedicineGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (patient==null)
            {
                if (observationTextBox.Text!="")
                {
                    if (Convert.ToInt32(doctorDropDownList.SelectedValue)>0)
                    {
                        if (Session["treatmentGridViewData"] != null)
                        {
                            int patientId = 2; //patientBll.PatientEntry(patient);
                            PatientHistoryModel patientHistory = new PatientHistoryModel();
                            patientHistory.PatientId = patientId;
                            patientHistory.Observation = observationTextBox.Text;
                            patientHistory.DateOfServices = Calendar1.SelectedDate.ToString();
                            patientHistory.DoctorId = Convert.ToInt32(doctorDropDownList.SelectedValue);
                            LoginModel loginModel = (LoginModel) Session["loginInformation"];
                            patientHistory.CenterId = loginModel.ID;
                            int treatmentHistoryId = patientHistoryBll.PatientHistoryEntry(patientHistory);
                            TreatmentModel treatment = new TreatmentModel();
                            treatment.TreatmentHistoryId = treatmentHistoryId;
                            treatment.DiseaseId = Convert.ToInt32(diseaseDropdownList.SelectedValue);
                            treatment.DoseId = Convert.ToInt32(doseDropdownList.SelectedValue);
                            treatment.IndicationId = Convert.ToInt32(medicineIndication.SelectedValue);
                            treatment.MedicineId = Convert.ToInt32(medicineDropDownList.SelectedValue);
                            treatment.Note = noteTextBox.Text;
                            treatment.Quantiry = Convert.ToInt32(quantityTextBox.Text);
                            if (treatmentBll.TreatementEntry(treatment))
                            {
                                
                            }
                        }
                        else
                        {
                            // you must have to add one data
                        }
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    //observation can not be empty
                }
            }
            else
            {
                //patient can not be empty
            }
        }

        public void PopulateGridView()
        {
            dataTable.Columns.Add("Disease", typeof(string));
            dataTable.Columns.Add("Medicine", typeof(string));
            dataTable.Columns.Add("Dose", typeof(string));
            dataTable.Columns.Add("Before/After", typeof(string));
            dataTable.Columns.Add("Quntity Given", typeof(string));
            dataTable.Columns.Add("Note", typeof(string));
            Session["treatmentGridViewData"] = dataTable;
        }

    }
}
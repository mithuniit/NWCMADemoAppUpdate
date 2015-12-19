using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.DAL.Center
{
    public class PatientHistoryDAL
    {
        
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public PatientHistoryDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }


        public List<PatientInformationModel> GetAllHistory(int voterID)
        {
            List<PatientInformationModel> patientHistoryModels = new List<PatientInformationModel>();
            string query = String.Format("SpGetAllPatientHistoryByVoterId");
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@voterId", voterID);

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
               PatientInformationModel patientInformationModel = new PatientInformationModel();
                patientInformationModel.Name = rdr[0].ToString();
                patientInformationModel.Address = rdr[1].ToString();
                patientInformationModel.CenterName = rdr[2].ToString();
                patientInformationModel.ServiceDate = rdr[3].ToString();
                patientInformationModel.Doctor = rdr[4].ToString();
                patientInformationModel.Observation = rdr[5].ToString();
                patientInformationModel.DiseaseName = rdr[6].ToString();
                patientInformationModel.MedicineName = rdr[7].ToString();
                patientInformationModel.Dose = rdr[8].ToString();
                patientInformationModel.Quantity = Convert.ToInt32(rdr[9].ToString());
                patientInformationModel.Note = rdr[10].ToString();
                patientHistoryModels.Add(patientInformationModel);
            }
            sqlConnection.Close();
            return patientHistoryModels;

        }

        public int PatientHistoryEntry(PatientHistoryModel patientHistory)
        {
            string query = String.Format("Insert into tblPatientHistory OUTPUT INSERTED.ID values(@serviceDate,@doctorId,@centerId,@observation,@patientId)");
            SqlParameter nameParameter = new SqlParameter("@serviceDate", patientHistory.DateOfServices);
            sqlCommand.Parameters.Add(nameParameter);

            SqlParameter degreeParameter = new SqlParameter("@doctorId", patientHistory.DoctorId);
            sqlCommand.Parameters.Add(degreeParameter);

            SqlParameter specializationParameter = new SqlParameter("@centerId", patientHistory.CenterId);
            sqlCommand.Parameters.Add(specializationParameter);

            SqlParameter centerIdParameter = new SqlParameter("@observation", patientHistory.Observation);
            sqlCommand.Parameters.Add(centerIdParameter);

            SqlParameter patientIdParameter = new SqlParameter("@patientId", patientHistory.PatientId);
            sqlCommand.Parameters.Add(patientIdParameter);

            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int treatmentHistoryId = (int) sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            return treatmentHistoryId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.AdminModel;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.DAL.Center
{
    public class PatientDal
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public PatientDal()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public int NumberOfService(string voterId)
        {
            string query = string.Format("select * from tblPatient where voterId = "+voterId);
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            int numberOfServieces = 0;
            while (rdr.Read())
            {
                numberOfServieces++;
            }
            sqlConnection.Close();
            return numberOfServieces;
        }

        public int PatientEntry(PatientModel patient)
        {
            string query = String.Format("Insert into tblDoctor values(@voterId,@name,@address,@age); select SCOPE_IDENTITY; ");
            SqlParameter nameParameter = new SqlParameter("@voterId", patient.VoterId);
            sqlCommand.Parameters.Add(nameParameter);

            SqlParameter degreeParameter = new SqlParameter("@name", patient.Name);
            sqlCommand.Parameters.Add(degreeParameter);

            SqlParameter specializationParameter = new SqlParameter("@address", patient.Address);
            sqlCommand.Parameters.Add(specializationParameter);
            SqlParameter centerIdParameter = new SqlParameter("@age", patient.Age);
            sqlCommand.Parameters.Add(centerIdParameter);

            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int patientId = (int) sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            return patientId;
        }
    }
}
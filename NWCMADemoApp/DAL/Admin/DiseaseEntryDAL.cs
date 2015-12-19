using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.DAL.Admin
{
    public class DiseaseEntryDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public DiseaseEntryDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public int SaveDisease(DiseaseModel diseaseModel)
        {
          
            string query = String.Format("Insert into tblDisease values(@name,@description,@tProcedure)");
            SqlParameter nameParameter = new SqlParameter("@name",diseaseModel.Name);
            sqlCommand.Parameters.Add(nameParameter);

            SqlParameter descriptionParameter = new SqlParameter("@description", diseaseModel.Description);
            sqlCommand.Parameters.Add(descriptionParameter);

            SqlParameter procedureParameter = new SqlParameter("@tProcedure", diseaseModel.Procedure);
            sqlCommand.Parameters.Add(procedureParameter);



            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;

        }

        public bool IsDiseaseExist(DiseaseModel diseaseModel)
        {
            bool isDiseaseExist = false;
            string query = String.Format("Select * from tblDisease where name=@diseaseName");
            sqlCommand.CommandText = query;
            SqlParameter medicineNameParameter = new SqlParameter("@diseaseName", diseaseModel.Name);
            sqlCommand.Parameters.Add(medicineNameParameter);
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                isDiseaseExist = true;
            }
            sqlConnection.Close();
            return isDiseaseExist;

        }

        public List<DiseaseModel> GetAllDisease()
        {
            List<DiseaseModel> diseaseModels = new List<DiseaseModel>();

            string query = String.Format("Select * from tblDisease");
            sqlCommand.CommandText = query;
           
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                DiseaseModel diseaseModel = new DiseaseModel();
                diseaseModel.ID = (int) rdr[0];
                diseaseModel.Name = rdr[1].ToString();
                diseaseModel.Description = rdr[2].ToString();
                diseaseModel.Procedure = rdr[3].ToString();
                diseaseModels.Add(diseaseModel);
            }
            sqlConnection.Close();
            return diseaseModels;

        }
    }
}
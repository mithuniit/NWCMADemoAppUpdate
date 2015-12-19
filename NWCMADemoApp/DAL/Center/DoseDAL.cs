using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.DAL.Center
{
    public class DoseDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public DoseDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public List<DoseModel> GetAllDose()
        {
            int serialNumber = 1;
            List<DoseModel> doseModels = new List<DoseModel>();

            string query = String.Format("Select * from tblDose");
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                DoseModel doseModel = new DoseModel();
                doseModel.Id = Convert.ToInt32(rdr[0]);
                doseModel.Dose = rdr[1].ToString();

                doseModels.Add(doseModel);
                
            }
            sqlConnection.Close();
            return doseModels;

        }
    }
}
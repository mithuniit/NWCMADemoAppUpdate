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
    public class MedicineStockDAL
    {
        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;

        public MedicineStockDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public List<MedicineStockModel> GetAllStockInformation(int centerId)
        {
            List<MedicineStockModel> medicineStockModels = new List<MedicineStockModel>();
            string query = String.Format("SpGetMedicineNameAndQuantityByCenterId");
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@centerId", centerId);
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                MedicineStockModel medicineStockModel = new MedicineStockModel();
                medicineStockModel.MedicineName = rdr[0].ToString();
                medicineStockModel.PresentStock = Convert.ToInt32(rdr[1].ToString());
                medicineStockModels.Add(medicineStockModel);
            }
            sqlConnection.Close();
            return medicineStockModels;
        }
    }
}
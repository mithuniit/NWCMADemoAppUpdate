using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.DAL.Admin
{
    public class MedicineEntryDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public MedicineEntryDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public int SaveMedicine(MedicineModel medicineModel)
        {
          
            string query = String.Format("Insert into tblMedicine values(@name)");
            SqlParameter nameParameter = new SqlParameter("@name",medicineModel.Name);
            sqlCommand.Parameters.Add(nameParameter);
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;

        }

        public bool IsMedicineExist(MedicineModel medicineModel)
        {
            bool isMedicineExist = false;
            string query = String.Format("Select * from tblMedicine where name=@medicineName");
            sqlCommand.CommandText = query;
            SqlParameter medicineNameParameter = new SqlParameter("@medicineName",medicineModel.Name);
            sqlCommand.Parameters.Add(medicineNameParameter);
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                isMedicineExist = true;
            }
            sqlConnection.Close();
            return isMedicineExist;

        }

        public List<MedicineModel> GetAllMedicine()
        {
            List<MedicineModel> medicineModels = new List<MedicineModel>();
          
            string query = String.Format("Select * from tblMedicine");
            sqlCommand.CommandText = query;
           
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
               MedicineModel medicineModel = new MedicineModel();
                medicineModel.ID = (int) rdr[0];
                medicineModel.Name = rdr[1].ToString();
                medicineModels.Add(medicineModel);
            }
            sqlConnection.Close();
            return medicineModels;

        }
    }
}
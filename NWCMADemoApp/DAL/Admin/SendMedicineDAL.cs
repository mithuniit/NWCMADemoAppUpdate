using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.DAL.Admin
{
    public class SendMedicineDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public SendMedicineDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public List<CenterModel> GetAllCenter(ThanaModel thanaModel)
        {
            List<CenterModel> centerModels = new List<CenterModel>();
            string query = string.Format("select id,name from tblCenter where tId=@tId");
            sqlCommand.Parameters.AddWithValue("@tId", thanaModel.ID);
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                CenterModel centerModel = new CenterModel();
                centerModel.ID = Convert.ToInt32(rdr[0]);
                centerModel.Name = rdr[1].ToString();
                centerModels.Add(centerModel);
            }
            sqlConnection.Close();
            return centerModels;
        }
        //Medicine

        public int GetSelectedMedicineId(string medicineName)
        {

            int medicineId = 0;
            string query = String.Format(@"select id from tblMedicine where name='{0}'",medicineName);
            //sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@name", medicineModel.ID);
            

            //SqlParameter nameParameter = new SqlParameter("@mName", medicineName);
            //sqlCommand.Parameters.Add(nameParameter);
           
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                medicineId = Convert.ToInt32(rdr[0]);
            }
           
            sqlConnection.Close();
            return medicineId;
        }

        public List<MedicineModel> GetAllMedicine()
        {
            List<MedicineModel> medicineModels = new List<MedicineModel>();
            string query = string.Format("select * from tblMedicine");
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                MedicineModel medicineModel = new MedicineModel();
                medicineModel.ID = Convert.ToInt32(rdr[0]);
                medicineModel.Name = rdr[1].ToString();
                medicineModels.Add(medicineModel);
            }
            sqlConnection.Close();
            return medicineModels;
        }

        public int SaveSendMedicine(SendMedicineModel sendMedicineModel)
        {
            string Query = String.Format(@"Insert into tblProvidedMedicine values('{0}',
                 '{1}','{2}','{3}','{4}')",
             sendMedicineModel.MedicineId,sendMedicineModel.Quantity,sendMedicineModel.CenterId,sendMedicineModel.ThanaId,sendMedicineModel.DistrictId);
 
            sqlCommand.CommandText = Query;
            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            
            return rowsAffected;
        }

        public int UpdateSendMedicine(SendMedicineModel sendMedicineModel)
        {
            string Query = String.Format(@"Update tblProvidedMedicine set quantity='{0}'+quantity where
            medicineId='{1}' and centerId='{2}'",sendMedicineModel.Quantity,sendMedicineModel.MedicineId,sendMedicineModel.CenterId);

            
            sqlCommand.CommandText = Query;
            sqlConnection.Open();
            int rowsUpdated = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            
            return rowsUpdated;
        }

        public bool IsMedicineQuantityExist(SendMedicineModel sendMedicineModel)
        {
            bool isMedicineQuantityExist = false;
            string Query = String.Format(@"Select * from tblProvidedMedicine where medicineId='{0}' and centerId='{1}'",sendMedicineModel.MedicineId,sendMedicineModel.CenterId);
            //sqlCommand.Parameters.AddWithValue("@medicineId2", sendMedicineModel.MedicineId);
            //sqlCommand.Parameters.AddWithValue("@centerId2", sendMedicineModel.CenterId);
            sqlCommand.CommandText = Query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                isMedicineQuantityExist = true;
            }
            sqlConnection.Close();

            return isMedicineQuantityExist;
        }


    }
}
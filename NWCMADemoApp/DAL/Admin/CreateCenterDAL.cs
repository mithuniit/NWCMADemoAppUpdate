using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.DAL.Admin
{
    public class CreateCenterDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public CreateCenterDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public List<DistrictModel> GetAllDistrict()
        {
            List<DistrictModel> districtModels = new List<DistrictModel>();
            string query = string.Format("select * from tblDistrict");
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                DistrictModel districtModel = new DistrictModel();
                districtModel.ID = Convert.ToInt32(rdr[0]);
                districtModel.Name = rdr[1].ToString();
                districtModels.Add(districtModel);
            }
            sqlConnection.Close();
            return districtModels;
        }

        public List<ThanaModel> GetAllThana(DistrictModel districtModel)
        {
            List<ThanaModel> thanaModels = new List<ThanaModel>();
            string query = string.Format("select * from tblThana where dId=@dId");

            SqlParameter dIdParameter = new SqlParameter("@dId",districtModel.ID);
            sqlCommand.Parameters.Add(dIdParameter);
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                ThanaModel thanaModel = new ThanaModel();
                thanaModel.ID = Convert.ToInt32(rdr[0]);
                thanaModel.Name = rdr[1].ToString();
                thanaModels.Add(thanaModel);
            }
            sqlConnection.Close();
            return thanaModels;
        }

        //xdfcsd sdfsdfsd




        public int SaveCenter(CenterModel centerModel)
        {

            string query = String.Format("Insert into tblCenter values(@name,@cCode,@password,@tId,@dId,@type)");            

            SqlParameter nameParameter = new SqlParameter("@name", centerModel.Name);
            sqlCommand.Parameters.Add(nameParameter);

            SqlParameter codeParameter = new SqlParameter("@cCode", centerModel.Code);
            sqlCommand.Parameters.Add(codeParameter);

            SqlParameter passwordParameter = new SqlParameter("@password", centerModel.Password);
            sqlCommand.Parameters.Add(passwordParameter);

            SqlParameter thanaIdParameter = new SqlParameter("@tId", centerModel.ThanaId);
            sqlCommand.Parameters.Add(thanaIdParameter);
            SqlParameter dictrictIdParameter = new SqlParameter("@dId", centerModel.DistrictID);
            sqlCommand.Parameters.Add(dictrictIdParameter);
            SqlParameter loginTypeParameter = new SqlParameter("@type", centerModel.LoginType);
            sqlCommand.Parameters.Add(loginTypeParameter);


            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;

        }

        public bool IsCenterExist(CenterModel centerModel)
        {
            bool isCenterExist = false;
            string query = String.Format("Select * from tblCenter where name=@centerName and tId=@thanaId");
            sqlCommand.CommandText = query;
            SqlParameter centerNameParameter = new SqlParameter("@centerName", centerModel.Name);
            sqlCommand.Parameters.Add(centerNameParameter);

            SqlParameter thanaIdParameter = new SqlParameter("@thanaId", centerModel.ThanaId);
            sqlCommand.Parameters.Add(thanaIdParameter);

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                isCenterExist = true;
            }
            sqlConnection.Close();
            return isCenterExist;

        }

        public int GetLastIdentity()
        {
            string query = String.Format("Select IDENT_CURRENT('tblCenter')");
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int identityValue = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();
            return identityValue;
        }

        public List<CenterModel> GetAllCenter()
        {
            int serialNumber = 1;
            List<CenterModel> centerModels = new List<CenterModel>();
            int lastId =  GetLastIdentity();


            string query = String.Format("Select * from tblCenter where id=@id");

            SqlParameter lastIdParameter = new SqlParameter("@id",lastId);
            sqlCommand.Parameters.Add(lastIdParameter);
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                CenterModel centerModel = new CenterModel();
                centerModel.ID = serialNumber;
                centerModel.Name = rdr[1].ToString();
                centerModel.Code = rdr[2].ToString();
                centerModel.Password = rdr[3].ToString();
                centerModels.Add(centerModel);
                serialNumber++;
            }
            sqlConnection.Close();
            return centerModels;

        }


    }
}
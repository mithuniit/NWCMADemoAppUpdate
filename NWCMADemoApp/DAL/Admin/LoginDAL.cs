using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.AdminModel;

namespace NWCMADemoApp.DAL.Admin
{
    public class LoginDAL
    {

        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;

        public LoginDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

        }

        public bool IsCodePasswordExist(LoginModel loginModel)
        {
            bool isCodePasswordExist = false;
            

            string query = String.Format("Select * from tblLogin where code=@code and password=@password");
            SqlParameter codeParameter = new SqlParameter("@code",loginModel.Code);
            sqlCommand.Parameters.Add(codeParameter);

            SqlParameter passwordParameter = new SqlParameter("@password",loginModel.Password);
            sqlCommand.Parameters.Add(passwordParameter);

            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                isCodePasswordExist = true;
            }
            sqlConnection.Close();
          
            return isCodePasswordExist;
        }

        public LoginModel GetLoginTypeAndName(LoginModel loginModel)
        {
            LoginModel aLoginModel = new LoginModel();
            string query = string.Format("select id,type,name from tblLogin  where code=@loginCode and password=@loginPassword");
            
            SqlParameter codeParameter = new SqlParameter("@loginCode", loginModel.Code);
            sqlCommand.Parameters.Add(codeParameter);

            SqlParameter passwordParameter = new SqlParameter("@loginPassword", loginModel.Password);
            sqlCommand.Parameters.Add(passwordParameter);

            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                aLoginModel.ID = Convert.ToInt32(rdr[0]); 
                aLoginModel.LoginType = Convert.ToInt16(rdr[1]);
                aLoginModel.LoginName = rdr[2].ToString();

            }
            sqlConnection.Close();

            return aLoginModel;

        }


    }
}
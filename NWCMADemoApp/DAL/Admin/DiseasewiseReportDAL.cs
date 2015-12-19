using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NWCMADemoApp.DAL.Admin
{
    public class DiseasewiseReportDAL
    {
        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;

        public DiseasewiseReportDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }
    }
}
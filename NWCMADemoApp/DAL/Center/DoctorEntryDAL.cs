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
    public class DoctorEntryDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public DoctorEntryDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public int SaveDoctor(DoctorModel doctorModel)
        {

            string query = String.Format("Insert into tblDoctor values(@name,@degree,@specialization,@centerId)");
            SqlParameter nameParameter = new SqlParameter("@name", doctorModel.Name);
            sqlCommand.Parameters.Add(nameParameter);

            SqlParameter degreeParameter = new SqlParameter("@degree", doctorModel.Degree);
            sqlCommand.Parameters.Add(degreeParameter);

            SqlParameter specializationParameter = new SqlParameter("@specialization", doctorModel.Specialization);
            sqlCommand.Parameters.Add(specializationParameter);
            SqlParameter centerIdParameter = new SqlParameter("@centerId", doctorModel.CenterId);
            sqlCommand.Parameters.Add(centerIdParameter);



            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;

        }
        public List<CenterModel> GetAllCenter()
        {
            List<CenterModel> centerModels = new List<CenterModel>();
            string query = string.Format("select * from tblCenter");
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

        public List<DoctorModel> GetAllDoctor()
        {
            List<DoctorModel> doctorModels = new List<DoctorModel>();
            string query = String.Format("Select * from tblDoctor");
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                DoctorModel doctorModel = new DoctorModel();
                doctorModel.Id = (int) rdr[0];
                doctorModel.Name = rdr[1].ToString();
                doctorModel.Degree = rdr[2].ToString();
                doctorModel.Specialization = rdr[3].ToString();
                doctorModels.Add(doctorModel);
            }
            sqlConnection.Close();
            return doctorModels;
        }

    }
}
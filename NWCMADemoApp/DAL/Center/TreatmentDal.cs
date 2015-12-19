using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NWCMADemoApp.Models.CenterModel;

namespace NWCMADemoApp.DAL.Center
{
    public class TreatmentDal
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public TreatmentDal()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public bool TreatementEntry(TreatmentModel treatment)
        {
            string query = String.Format("Insert into tblTreatment values(@diseaseId,@medicineId,@doesId,@indicationId,@quantity,@note,@treatmentHistoryId)");
            sqlCommand.Parameters.Add("@diseaseId", treatment.DiseaseId);
            sqlCommand.Parameters.Add("@medicineId", treatment.MedicineId);
            sqlCommand.Parameters.Add("@doesId", treatment.DoseId);
            sqlCommand.Parameters.Add("@indicationId", treatment.IndicationId);
            sqlCommand.Parameters.Add("@quantity", treatment.Quantiry);
            sqlCommand.Parameters.Add("@note", treatment.Note);
            sqlCommand.Parameters.Add("@treatmentHistoryId", treatment.TreatmentHistoryId);
            
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected>0;
        }

    }
}
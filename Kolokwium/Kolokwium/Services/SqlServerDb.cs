using Kolokwium.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class SqlServerDb
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18801;Integrated Security=True";

        public void GetPrescription(int id)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                con.Open();
                com.Connection = con;
                var tran = con.BeginTransaction();

                try
                {

                    com.CommandText = "SELECT date, duedate, idpatient, iddoctor, dose, details, name, description, type from prescription inner join prescription on prescription.idprescription = prescription_medicament.idprescription inner join prescription_medicament on prescription_medicament.idmedicament = medicament.idmedicament where idprescription = @id ";
                    com.Parameters.AddWithValue("id", id);
                    


                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        tran.Rollback();
                        throw new Exception("Brak recepty!");
                    }
                    List<PrescriptionResponse> response = new List<PrescriptionResponse>();

                    response.Add(new PrescriptionResponse
                    {
                        IdPrescription = int.Parse(dr["IdPrescription"].ToString()),
                        Date = DateTime.Parse(dr["Date"].ToString()),
                        DueDate = DateTime.Parse(dr["DueDate"].ToString()),
                        IdPatient = int.Parse(dr["IdPatient"].ToString()),
                        IdDoctor = int.Parse(dr["IdDoctor"].ToString()),
                        Dose = int.Parse(dr["Dose"].ToString()),
                        Details = dr["Details"].ToString(),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Type = dr["Type"].ToString()
                    });                      
                    
                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }
        }
    }
}

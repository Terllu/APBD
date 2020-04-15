﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw5.DTOs.Requests;
using Cw5.Models;

namespace Cw5.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        public void EnrollStudent(EnrollStudentRequest request)
        {
            //DTOs - Data Transfer Objects
            //Request models
            //==mapowanie==
            //Modele biznesowe/encje (entity)
            //==mapowanie==
            //Response models

            var st = new Student();
            st.FirstName = request.FirstName;
            st.IndexNumber = request.IndexNumber;
            st.FirstName = request.FirstName;
            st.LastName = request.LastName;
            st.BirthDate = request.Birthdate;
            st.Studies = request.Studies;

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18801;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    //1. Czy studia istnieja?
                    com.CommandText = "select IdStudies from studies where name=@name";
                    com.Parameters.AddWithValue("name", request.Studies);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        tran.Rollback();
                        //return BadRequest("Studia nie istnieja");
                    }
                    int idstudies = (int)dr["IdStudies"];

                    //x. Dodanie studenta
                    com.CommandText = "INSERT INTO Student(IndexNumber, FirstName, LastName, BirthDate, Studies) VALUES (@IndexNumber, @FirstName, @LastName, @BirthDate, @Studies)";
                    com.Parameters.AddWithValue("IndexNumber", request.IndexNumber);
                    com.Parameters.AddWithValue("FirstName", request.FirstName);
                    com.Parameters.AddWithValue("LastName", request.LastName);
                    com.Parameters.AddWithValue("Birthdate", request.Birthdate);
                    com.Parameters.AddWithValue("Studies", request.Studies);
                    //...
                    com.ExecuteNonQuery();

                    tran.Commit();

                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }

        }

        public void PromoteStudents(EnrollPromotionRequest request)
        {
            var st = new Student();
            st.Studies = request.Studies;

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18801;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    com.CommandText = "select IdEnrollment from Enrollment where Enrollment.IdStudy = Studies.IdStudy AND Enrollment.Semester = @Student.Semester AND Studies.Name = @Studies ";
                    com.Parameters.AddWithValue("Semester", request.Semester);
                    com.Parameters.AddWithValue("studies", request.Studies);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        tran.Rollback();
                        //return BadRequest("Studia nie istnieja");
                    }
                    int idstudies = (int)dr["IdStudies"];

                    //x. Dodanie studenta
                    com.CommandText = "INSERT INTO Enrollment (IdEnrollment, Semester, IdStudy, StartDate) VALUES (@IdEnrollment, @Semester+1, @IdStudy, @StartDate";
                    com.Parameters.AddWithValue("Semester", request.Semester);
                    com.Parameters.AddWithValue("Studies", request.Studies);
                    //...
                    com.ExecuteNonQuery();

                    tran.Commit();

                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }

        }
    }
}

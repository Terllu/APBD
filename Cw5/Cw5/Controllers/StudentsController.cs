using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cw5.Models;
using Cw5.Services;

namespace Cw5.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18801;Integrated Security=True";

        private IStudentDbService _dbService;

        public StudentsController(IStudentDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents([FromServices] IStudentDbService dbService)
        {
            //Budowanie connection string
            /*
            var conBuilder = new SqlConnectionStringBuilder();
            conBuilder.InitialCatalog = "pgago";
            //..
            string conStr = conBuilder.ConnectionString;
            */

            //1. Nisko-poziomowa
            //  1.1 Sterownikow Oracle/SqlServer
            //  1.2 Sterownikow ogolnych
            //
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from students";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    list.Add(st);
                }

            }

            return Ok(list);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from students where indexnumber=@index";

                /*
                SqlParameter par = new SqlParameter();
                par.Value = indexNumber;
                par.ParameterName = "index";
                com.Parameters.Add(par);
                */
                com.Parameters.AddWithValue("index", indexNumber);

                con.Open();
                var dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();
                    if (dr["IndexNumber"] != DBNull.Value)
                        st.IndexNumber = dr["IndexNumber"].ToString();
                    if (dr["FirstName"] != DBNull.Value)
                        st.FirstName = dr["FirstName"].ToString();
                    if (dr["LastName"] != DBNull.Value)
                        st.LastName = dr["LastName"].ToString();
                    if (dr["BirthDate"] != DBNull.Value)
                        st.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
                    return Ok(st);
                }

            }

            return NotFound();
        }

        [HttpGet("ex2")]
        public IActionResult GetStudents2()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "TestProc3";
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("LastName", "Kowalski");

                var dr = com.ExecuteReader();
                //...

            }

            return NotFound();
        }

        [HttpGet("ex3")]
        public IActionResult GetStudents3()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "insert into Student(FirstName) values (@firstName)";


                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    int affectedRows = com.ExecuteNonQuery();

                    com.CommandText = "update into ...";
                    com.ExecuteNonQuery();

                    //...
                    transaction.Commit();
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                }

            }

            return Ok();
        }
    }
}
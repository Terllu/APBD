using KolokwiumPoprawa.DTOs.Response;
using KolokwiumPoprawa.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KolokwiumPoprawa.Services
{
    public class SqlServerDbService : IDbService
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18801;Integrated Security=True";

        public TeamMemberResponse GetTeamMember(int id)
        {
            var response = new TeamMemberResponse();

            using (var connection = new SqlConnection(ConString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();

                var transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                command.CommandText = "Select * From TeamMember Where IdTeamMember = @IdTeamMember";
                command.Parameters.AddWithValue("IdTeamMember", id);

                var dr = command.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                    transaction.Rollback();
                    throw new MemberDoesNotExists("Member does not exists");
                }

                response.IdTeamMember = int.Parse(dr["IdTeamMember"].ToString());
                response.FirstName = dr["FirstName"].ToString();
                response.LastName = dr["LastName"].ToString();
                response.Email = dr["Email"].ToString();
                response.TaskList = new List<TaskResponse>();
                response.TaskListCreatedBy = new List<TaskResponse>();

                dr.Close();

                command.CommandText = "Select * From Task Inner Join Project On Project.IdTeam = Task.IdTeam Inner Join TaskType.IdTaskType = Task.IdTaskType Where IdAssignedTo = @IdAssignedTo Order by Task.Deadline DESC";
                command.Parameters.AddWithValue("IdAssignedTo", id);
                dr = command.ExecuteReader();

            }

            return response;
        }

        public IActionResult DeleteProject(int id)
        {
            using (var connection = new SqlConnection(ConString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();

                var transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                command.CommandText = "Select * From Project Where IdTeam = @IdTeam";
                command.Parameters.AddWithValue("IdTeam", id);

                var dr = command.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                    transaction.Rollback();
                    throw new ProjectDoesNotExists("Proejtct does not exists");
                }

                command.CommandText = "Select * From Project Inner Join Task on Project.IdTeam = Task.IdTeam Where IdTeam = @IdTeam";
                command.Parameters.AddWithValue("IdTeam", id);

                dr = command.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                    transaction.Rollback();
                    throw new TaskDoesNotExists("Tasks does not exists");
                }
                    command.CommandText = "Delete From Task Where IdTeam = @IdTeam";
                    command.Parameters.AddWithValue("IdTeam", id);
                    command.ExecuteNonQuery();

                dr.Close();

                command.CommandText = "Delete From Project Where IdTeam = @IdTeam";
                command.Parameters.AddWithValue("IdTeam", id);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            return new OkObjectResult("Success");
        }
    }
}
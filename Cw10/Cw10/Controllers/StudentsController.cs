using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cw10.Models;
using Cw10.Services;
using Microsoft.Extensions.Configuration;
using Cw10.DTOs.Requests;

namespace Cw10.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _context;
        public IConfiguration Configuration { get; set; }

        public StudentsController(IStudentDbService context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.GetStudents());
        }

        [HttpPut("modify")]
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            return Ok(_context.ModifyStudent(request));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteStudent(DeleteStudentRequest request)
        {
            return Ok(_context.DeleteStudent(request));
        }
    }
}
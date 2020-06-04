using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw11.DTOs.Requests;
using Cw11.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Cw11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class StudentsController : ControllerBase
    {
        private readonly IDoctorDbService _context;
        public IConfiguration Configuration { get; set; }

        public StudentsController(IDoctorDbService context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.GetDoctors());
        }

        [HttpPost("add")]
        public IActionResult AddDoctor(AddDoctorRequest request)
        {
            return Ok(_context.AddDoctor(request));
        }

        [HttpPut("modify")]
        public IActionResult ModifyStudent(ModifyDoctorRequest request)
        {
            return Ok(_context.ModifyDoctor(request));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteStudent(DeleteDoctorRequest request)
        {
            return Ok(_context.DeleteDoctor(request));
        }
    }
}
using System;
using Microsoft.AspNetCore.Mvc;
using Cw10.DTOs.Requests;
using Cw10.Services;
using Cw10.Models;
using Microsoft.Extensions.Configuration;

namespace Cw10.Controllers
{
    [Route("api/enrollments")]
    [ApiController] //-> implicit model validation
    public class EnrollmentsController : ControllerBase
    {
        private readonly IStudentDbService _context;
        public IConfiguration Configuration { get; set; }

        public EnrollmentsController(IStudentDbService context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            return _context.EnrollStudent(request);
        }

        [HttpPost("promotions")]
        public void PromoteStudents(EnrollPromotionRequest request)
        {
            _context.PromoteStudent(request);
        }


    }
}
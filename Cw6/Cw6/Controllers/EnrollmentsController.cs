﻿using System;
using Microsoft.AspNetCore.Mvc;
using Cw6.DTOs.Requests;
using Cw6.DTOs.Responses;
using Cw6.Services;
using Cw6.Models;

namespace Cw6.Controllers
{
    [Route("api/enrollments")]
    [ApiController] //-> implicit model validation
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            _service.EnrollStudent(request);

            var response = new EnrollStudentResponse();
            response.LastName = request.LastName;
            response.StartDate = DateTime.Now;
            response.Semester = 1;

            return Ok(response);
        }

        [HttpPost("promotions")]
        public IActionResult PromoteStudents(EnrollPromotionRequest request)
        {
            _service.PromoteStudents(request);
            var response = new EnrollPromotionRequest();
            response.Semester = request.Semester + 1;
            response.Studies = request.Studies;
            return Ok(response);
        }


    }
}
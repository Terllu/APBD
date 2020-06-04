using System.Collections.Generic;
using Cw10.DTOs.Requests;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Services
{
    public interface IStudentDbService
    {
        public IEnumerable<Student> GetStudents();
        public IActionResult ModifyStudent(ModifyStudentRequest request);
        public IActionResult DeleteStudent(DeleteStudentRequest request);
        public IActionResult EnrollStudent(EnrollStudentRequest request);
        public void PromoteStudent(EnrollPromotionRequest request);
    }
}

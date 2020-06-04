using System.Collections.Generic;
using Cw11.DTOs.Requests;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Services
{
    public interface IDoctorDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public IActionResult AddDoctor(AddDoctorRequest request);
        public IActionResult ModifyDoctor(ModifyDoctorRequest request);
        public IActionResult DeleteDoctor(DeleteDoctorRequest request);
    }
}

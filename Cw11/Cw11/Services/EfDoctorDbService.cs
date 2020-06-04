using System;
using System.Collections.Generic;
using System.Linq;
using Cw11.DTOs.Requests;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;


namespace Cw11.Services
{
    public class EfDoctorDbService : IDoctorDbService
    {

        private readonly s18801Context _context;
        public EfDoctorDbService(s18801Context context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctor.ToList();
        }

        public IActionResult AddDoctor(AddDoctorRequest request)
        {
            var dt = new Doctor();
            dt.IdDoctor = _context.Doctor.Max(dt => dt.IdDoctor + 1);
            dt.FirstName = request.FirstName;
            dt.LastName = request.LastName;
            dt.Email = request.Email;

            _context.Attach(dt);
            _context.Add(dt);
            _context.SaveChanges();

            return new OkObjectResult(dt);
        }

        public IActionResult ModifyDoctor(ModifyDoctorRequest request)
        {
            var doctor = _context.Doctor.SingleOrDefault(dt => dt.IdDoctor == request.IdDoctor);
            var dt = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _context.Attach(dt);
            _context.Entry(dt).Property("FirstName").IsModified = true;
            _context.Entry(dt).Property("LastName").IsModified = true;
            _context.Entry(dt).Property("Email").IsModified = true;
            _context.SaveChanges();

            return new OkObjectResult(dt);
        }

        public IActionResult DeleteDoctor(DeleteDoctorRequest request)
        {
            var doctor = _context.Doctor.SingleOrDefault(dt => dt.IdDoctor == request.IdDoctor);

            if (doctor == null)
                return new BadRequestResult();

            var dt = new Doctor
            {
                IdDoctor = request.IdDoctor
            };

            _context.Attach(dt);
            _context.Remove(dt);
            _context.SaveChanges();

            return new OkObjectResult(dt);
        }
    }
}

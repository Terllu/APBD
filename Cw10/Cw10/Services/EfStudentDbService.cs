using System;
using System.Collections.Generic;
using System.Linq;
using Cw10.DTOs.Requests;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Services
{
    public class EfStudentDbService : IStudentDbService
    {

        private readonly s18801Context _context;
        public EfStudentDbService(s18801Context context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Student.ToList();
        }

        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            var student = _context.Student.Select(st => st.IndexNumber == request.IndexNumber);

            if (student == null)
                return new BadRequestResult();

            var st = new Student();
            st.IndexNumber = request.IndexNumber;
            st.FirstName = request.FirstName;
            st.LastName = request.LastName;
            st.BirthDate = request.Birthdate;

            _context.Attach(st);
            _context.Entry(st).Property("FirstName").IsModified = true;
            _context.Entry(st).Property("LastName").IsModified = true;
            _context.Entry(st).Property("Birthdate").IsModified = true;
            _context.SaveChanges();

            return new OkObjectResult(st);
        }

        public IActionResult DeleteStudent(DeleteStudentRequest request)
        {
            var student = _context.Student.Select(st => st.IndexNumber == request.IndexNumber);

            if (student == null)
                return new BadRequestResult();

            var st = new Student();
            st.IndexNumber = request.IndexNumber;

            _context.Attach(st);
            _context.Remove(st);
            _context.SaveChanges();

            return new OkObjectResult(st);
        }

        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var IdStudy = _context.Studies.Where(st => st.Name == request.Studies).Select(st => st.IdStudy).FirstOrDefault();


            var en = new Enrollment();
            en.Semester = 1;
            en.StartDate = DateTime.Now;

            _context.Attach(en);
            _context.SaveChanges();

            var st = new Student();
            st.FirstName = request.FirstName;
            st.IndexNumber = request.IndexNumber;
            st.FirstName = request.FirstName;
            st.LastName = request.LastName;
            st.BirthDate = request.Birthdate;

            _context.Attach(st);
            _context.SaveChanges();

            return new OkObjectResult(st);
        }

        public void PromoteStudent(EnrollPromotionRequest request)
        {
            _context.Database.ExecuteSqlRaw("EXEC PromoteStudentsProcedure @Studies, @Semester, request.Studies, request.Semestr")
        }
    }
}

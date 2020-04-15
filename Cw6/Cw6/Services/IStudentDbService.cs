using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw6.DTOs.Requests;
using Cw6.Models;

namespace Cw6.Services
{
    public interface IStudentDbService
    {
        void EnrollStudent(EnrollStudentRequest request);
        void PromoteStudents(EnrollPromotionRequest request);
        Boolean ChcekIndexNumber(string index);
    }
}

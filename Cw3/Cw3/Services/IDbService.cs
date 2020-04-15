using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;

namespace Cw3.Services
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}

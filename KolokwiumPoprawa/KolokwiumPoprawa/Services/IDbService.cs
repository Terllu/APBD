using KolokwiumPoprawa.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumPoprawa.Services
{
    public interface IDbService
    {
        public TeamMemberResponse GetTeamMember(int id);
        public IActionResult DeleteProject(int id);
    }
}

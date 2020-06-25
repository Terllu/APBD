using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumPoprawa.DTOs.Response
{
    public class TeamMemberResponse
    {
        public int IdTeamMember { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IEnumerable<TaskResponse> TaskList { get; set; }
        public IEnumerable<TaskResponse> TaskListCreatedBy { get; set; }
    }
}

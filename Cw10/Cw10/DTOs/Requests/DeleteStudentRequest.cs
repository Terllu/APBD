using System;
using System.ComponentModel.DataAnnotations;

namespace Cw10.DTOs.Requests
{
    public class DeleteStudentRequest
    {
        [Required(ErrorMessage = "Musisz podać Index!")]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }
    }
}

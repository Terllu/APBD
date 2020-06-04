using System;
using System.ComponentModel.DataAnnotations;

namespace Cw11.DTOs.Requests
{
    public class DeleteDoctorRequest
    {
        [Required(ErrorMessage = "Musisz podać Index!")]
        [RegularExpression("[0-9]+$")]
        public int IdDoctor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs.Request
{
    public class PrescriptionRequest
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int idPatient { get; set; }
        [Required]
        public int idDoctor { get; set; }
    }
}

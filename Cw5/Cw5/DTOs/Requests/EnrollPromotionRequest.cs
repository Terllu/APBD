using System.ComponentModel.DataAnnotations;

namespace Cw5.DTOs.Requests
{
    public class EnrollPromotionRequest
    {
        [Required(ErrorMessage = "Musisz podać studia")]
        public string Studies { get; set; }
        [Required(ErrorMessage = "Musisz podać semestr")]
        public int Semester { get; set; }
    }
}

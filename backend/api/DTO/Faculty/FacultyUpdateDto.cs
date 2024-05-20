using System.ComponentModel.DataAnnotations;

namespace api.DTO.Faculty
{
    public class FacultyUpdateDto
    {
        [Required]
        public int FacultyID { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? WebSite { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? DeanId { get; set; }
    }
}
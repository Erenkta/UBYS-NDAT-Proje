using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class LecturerAccountUpdateDto
    {
        [Required]
        public string? UserId { get; set; }
        public string? Phone {get; set;}
        public string? PersonalMail {get; set;}
    }
}
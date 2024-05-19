using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.AccountInfo
{
    public class AdministratorAccountPOSTDto
    {
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Required]
        public string LastName {get; set;} = string.Empty;
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Please enter a valid 9-digit number.")]
        public int AdministratorSSN {get; set;}
        //[Required]
        //public string? CurrentType { get; set; }
        //[Required]
        //public string? CurrentStatus { get; set; }
        [Required]
        public string? SchoolMail {get; set;}
        public string? Phone {get; set;}
        [Required]
        public string? UserId {get; set;}
    }
}
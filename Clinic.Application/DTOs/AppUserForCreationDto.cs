using Clinic.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Application.DTOs
{
    public class AppUserForCreationDto
    {
        [Required(ErrorMessage = "The username is required.")]
        [MaxLength(50, ErrorMessage = "Maximum characters are 50.")]
        [MinLength(5, ErrorMessage = "Minimum characters are 5.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "The password is required.")]
        [MaxLength(50, ErrorMessage = "Maximum characters are 50.")]
        [MinLength(5, ErrorMessage = "Minimum characters are 5.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "The email is required.")]
        [MaxLength(200, ErrorMessage = "Maximum characters are 200.")]
        [EmailAddress]
        public string Email { get; set; }


        public RoleType RoleType { get; set; }
    }
}

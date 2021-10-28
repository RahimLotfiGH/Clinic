using Clinic.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Entities
{
    public class AppUser
    {
        public long Id { get; set; }


        [Required(ErrorMessage = "The username is required.")]
        [MaxLength(50, ErrorMessage = "Maximum characters are 50.")]
        [MinLength(5, ErrorMessage = "Minimum characters are 5.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "The password is required.")]
        [MaxLength(50, ErrorMessage = "Maximum characters are 50.")]
        [MinLength(5, ErrorMessage = "Minimum characters are 5.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [MaxLength(50, ErrorMessage = "Maximum characters are 50.")]
        [MinLength(5, ErrorMessage = "Minimum characters are 5.")]
        public string FirstName { get; set; }


        [MaxLength(50, ErrorMessage = "Maximum characters are 50.")]
        [MinLength(5, ErrorMessage = "Minimum characters are 5.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "The email is required.")]
        [MaxLength(200, ErrorMessage = "Maximum characters are 200.")]
        [EmailAddress]
        public string Email { get; set; }


        [MaxLength(11, ErrorMessage = "Maximum characters are 11.")]
        public string Telephone { get; set; }


        [MaxLength(500, ErrorMessage = "Maximum characters are 500.")]
        public string Address { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public RoleType RoleType { get; set; }

    }
}

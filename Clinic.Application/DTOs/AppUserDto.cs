using Clinic.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Clinic.Application.DTOs
{
    public class AppUserDto
    {
        public long Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public RoleType RoleType { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _5510_final_project_Forum.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Rating {  get; set; }
        public string? ProfileImageUrl {  get; set; }
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

    }
}
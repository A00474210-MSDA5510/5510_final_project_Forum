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
        [PersonalData]
        public string? City { get; set; }
        [PersonalData]
        public string? Province {  get; set; }
        [PersonalData]
        public string? Country { get; set; }
        [PersonalData]
        public string? PostalCode { get; set; }
        [PersonalData]
        public Subscription? Subscription { get; set; }

        public int? isSubbed { get; set; }


    }
}
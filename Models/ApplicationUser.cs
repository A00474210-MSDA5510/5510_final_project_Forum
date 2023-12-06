using Microsoft.AspNetCore.Identity;

namespace _5510_final_project_Forum.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Rating {  get; set; }
        public string? ProfileImageUrl {  get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActive {  get; set; }

    }
}
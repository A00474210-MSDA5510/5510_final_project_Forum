using _5510_final_project_Forum.Data;
using _5510_final_project_Forum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _5510_final_project_Forum.Services
{
    public class SubscriptionService : ISubscriptions
    {
        private readonly ApplicationDbContext _context;
        private static UserManager<ApplicationUser> _userManager;
        public SubscriptionService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task Add(ApplicationUser user)
        {
            user.isSubbed = 1;
            IdentityResult result = await _userManager.UpdateAsync(user);
        }

        public Task Delete(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

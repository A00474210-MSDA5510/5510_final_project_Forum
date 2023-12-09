using _5510_final_project_Forum.Models;
namespace _5510_final_project_Forum.Data
{
    public interface ISubscriptions
    {
        Post GetById(int id);
        Task Add(ApplicationUser user);
        Task Delete(ApplicationUser user);
    }
}

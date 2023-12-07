using _5510_final_project_Forum.Data;
using _5510_final_project_Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;

namespace _5510_final_project_Forum.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {

            var posts = _context.Post.ToList();
            return posts;
        }

        public Post GetById(int id)
        {
            return _context.Post.Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Replies)
                    .ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .First();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            IEnumerable<Post>  placeholderposts = new List<Post>(1);
            placeholderposts.Append(GetById(1));
            return placeholderposts;

        }
    }
}

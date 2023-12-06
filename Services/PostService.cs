using _5510_final_project_Forum.Data;
using _5510_final_project_Forum.Models;
using Microsoft.EntityFrameworkCore;
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
        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            IEnumerable<Post> test = _context.Post.Include(post => post.Id);
            Console.WriteLine(test.Count());
            return test;
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

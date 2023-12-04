using _5510_final_project_Forum.Data;
using Microsoft.AspNetCore.Mvc;

namespace _5510_final_project_Forum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        public PostController(IPost postService) 
        {
            _postService = postService;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var model = new PostIndexModel
            {

            };
            return View();
        }
    }
}

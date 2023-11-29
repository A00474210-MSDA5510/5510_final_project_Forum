using _5510_final_project_Forum.Data;
using _5510_final_project_Forum.Models;
using _5510_final_project_Forum.Models.ForumView;
using Microsoft.AspNetCore.Mvc;

namespace _5510_final_project_Forum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        public ForumController(IForum formService)
        {
            _forumService = formService;
        }

        public IActionResult Index()
        {
            var forum = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                    Description = forum.Description,
                });

            var model = new ForumIndexModel
            {
                ForumList = forum
            };

            return View();
        }
    }
}

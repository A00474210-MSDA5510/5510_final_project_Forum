using _5510_final_project_Forum.Data;
using _5510_final_project_Forum.Models;
using _5510_final_project_Forum.Models.ForumView;
using _5510_final_project_Forum.Models.PostModels;
using _5510_final_project_Forum.Models.ReplyModels;
using _5510_final_project_Forum.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _5510_final_project_Forum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private static UserManager<ApplicationUser> _userManager;
        public PostController(IPost postService, IForum forumService, UserManager<ApplicationUser> userManager) 
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                CreatedAt = post.Created,
                PostContent = post.Content,
                Replies = BuildPostReplies(post.Replies),

            };
            return View(model);
        }

        public IActionResult Create(int id)
        {
            var forum = _forumService.GetById(id);
            var model = new NewPostModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                //User here means the current logged in user
                AuthorName = User.Identity.Name,
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);

            await _postService.Add(post);

      
            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostIndexModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var reply = BuildReply(model, user);
            await _postService.AddReply(reply);
            return RedirectToAction("Index", "Post", new { id = model.Id });
        }


        private Replies BuildReply (PostIndexModel model, ApplicationUser user)
        {
            var post = _postService.GetById(model.Id);
            return new Replies
            {
                Content = model.newReplyContent,
                Created = DateTime.Now,
                User = user,
                Post = post
            };
        }
        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };
        }
        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<Replies> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Date = reply.Created,
                ReplyContent = reply.Content,
            });
              
        }
    }
}

using _5510_final_project_Forum.Models.PostModels;
namespace _5510_final_project_Forum.Models.ForumView
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum {  get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}

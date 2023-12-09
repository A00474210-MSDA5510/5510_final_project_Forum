using _5510_final_project_Forum.Models.ForumView;

namespace _5510_final_project_Forum.Models.PostModels
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public DateTime DatePosted { get; set; }
        public ForumListingModel Forum {  get; set; }
        public int? AuthorSubType { get; set; }
        public int RepliesCount { get; set; }
    }
}

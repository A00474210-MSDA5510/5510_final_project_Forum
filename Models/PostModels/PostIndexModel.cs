using _5510_final_project_Forum.Models.ReplyModels;

namespace _5510_final_project_Forum.Models.PostModels
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId {  get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PostContent { get; set; }
        public string newReplyContent { get; set; }
        public IEnumerable<PostReplyModel> Replies { get; set; }

    }
}

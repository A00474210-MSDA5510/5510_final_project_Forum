using System.Data;

namespace _5510_final_project_Forum.Models.ReplyModels
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorRating { get; set; }
        public string AuthorImageUrl {  get; set; }
        public DateTime Created {  get; set; }
        public string ReplyContent { get; set; }

    }
}

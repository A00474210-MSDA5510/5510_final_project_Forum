namespace _5510_final_project_Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content {  get; set; }
        public DateTime Created {  get; set; }
        public required virtual ApplicationUser User { get; set; }
        public required virtual Forum Forum { get; set; }
        public required virtual IEnumerable<Replies> Replies { get; set; }
    }
}

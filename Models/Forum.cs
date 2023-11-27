namespace _5510_final_project_Forum.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public required string Title {  get; set; }
        public required string Description {  get; set; }
        public DateTime Created {  get; set; }
        public required string ImageUrl { get; set; }
        public required IEnumerable<Post> Posts { get; set; }
    }
}

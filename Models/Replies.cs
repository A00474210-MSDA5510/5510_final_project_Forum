namespace _5510_final_project_Forum.Models
{
    public class Replies
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime Created { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}

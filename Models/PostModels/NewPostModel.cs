﻿namespace _5510_final_project_Forum.Models.PostModels
{
    public class NewPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ForumName { get; set; }
        public string ForumImageUrl { get; set; }
        public int ForumId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }
        public string AuthorName { get; set; }
    }
}
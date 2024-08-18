﻿namespace MicroMultiBusiness.Comment.Entities
{
    public class UserComment
    {
        public int UserCommentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; } 
        public string? ImageURL { get; set; }
        public string ProductId { get; set; }
    }
}

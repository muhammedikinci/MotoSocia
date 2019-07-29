using Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Post
    {
        [Key]
        public int _id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(75)]
        public string Title { get; set; }
        [Required]
        [MinLength(50)]
        [MaxLength(1000)]
        public string Content { get; set; }
        [Required]
        public int RelatedGroupID { get; set; }
        [Required]
        public int SenderUserID { get; set; }
        public Counter<int> LikedUsers { get; set; }
        public Counter<int> CommentedUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

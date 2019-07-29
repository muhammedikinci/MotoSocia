using Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Event
    {
        [Key]
        public int _id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int RelatedGroupID { get; set; }
        public int SenderUserID { get; set; }
        [NotMapped]
        public Counter<int> Subscribers { get; set; }
        [NotMapped]
        public Dates EventDates { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

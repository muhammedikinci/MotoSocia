using Domain.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Group
    {
        [Key]
        public int _id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int MemberLimit { get; set; }
        [Required]
        public string GroupIcon { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public List<MediaLink> MediaLinks { get; set; }
        [Required]
        public int GroupOwnerID { get; set; }
        public Counter<int> AdminIDs { get; set; }
        public Counter<int> MemberIDs { get; set; }
        public Counter<int> EventIDs { get; set; }
        public Counter<int> PostIDs { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

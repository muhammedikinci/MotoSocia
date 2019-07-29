using Domain.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class User
    {
        [Key]
        public int _id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(70)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [MaxLength(150)]
        public string Password { get; set; }
        public string LasChangedPassword { get; set; }
        [NotMapped]
        public List<UserRelational> GroupIDs { get; set; }
        [NotMapped]
        public List<UserRelational> PostIDs { get; set; }
        [NotMapped]
        public List<UserRelational> EventIDs { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

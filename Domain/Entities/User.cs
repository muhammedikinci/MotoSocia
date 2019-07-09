using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class User
    {
        [Key]
        public int _id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

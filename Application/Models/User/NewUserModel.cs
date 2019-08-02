using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.User
{
    public class NewUserModel
    {
        public int _id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

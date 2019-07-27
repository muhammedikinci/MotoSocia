using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Account
{
    public class UpdateUserModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
    }
}

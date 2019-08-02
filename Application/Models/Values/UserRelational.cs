using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Models.Values
{
    public class UserRelational
    {
        public int RelationalID { get; set; }
        public bool Liked { get; set; }
        public bool Commented { get; set; }
        [NotMapped]
        public List<int> Comments { get; set; }
        public MemberType Type { get; set; }

        public enum MemberType
        {
            OWNER,
            ADMIN,
            NORMAL
        }
    }
}

using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tests.GetUserData
{
    public class GetUserDataTestParameter
    {
        public IMotoDBContext Context { get; set; }
        public NewUserModel User { get; set; }
    }
}

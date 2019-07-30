using Application.Command;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application.Actions.Account
{
    public class GetCurrentClaims : ICommand
    {
        IEnumerable<Claim> Claims;
        public NewUserModel User = new NewUserModel();
        
        public GetCurrentClaims(IEnumerable<Claim> claims)
        {
            Claims = claims;
        }

        public void Execute()
        {
            foreach (var item in Claims)
            {
                if (item.Type == ClaimTypes.Name)
                {
                    User.UserName = item.Value;
                }
                else if (item.Type == ClaimTypes.Email)
                {
                    User.Email = item.Value;
                }
            }
        }

        public object[] Result()
        {
            return new object[] { User };
        }
    }
}

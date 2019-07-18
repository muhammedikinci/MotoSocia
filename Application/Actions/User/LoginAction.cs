using Application.Models.User;
using Domain.Entities;
using System.Linq;

namespace Application.Actions.User
{
    public class LoginAction
    {
        private IMotoDBContext Context { get; set; }
        private LoginUserModel User { get; set; }

        public LoginAction(IMotoDBContext Context, LoginUserModel User)
        {
            this.Context = Context;
            this.User = User;
        }

        public void Action(out NewUserModel LoggedInUserData)
        {
            var data = Context.Users.Where(_ => _.Password == User.Password && _.UserName == User.UserName).First();

            if (data != null)
            {
                LoggedInUserData = new NewUserModel()
                {
                    UserName = data.UserName,
                    Email = data.Email,
                };
            }
            else
            {
                LoggedInUserData = new NewUserModel();
            }
        }
    }
}

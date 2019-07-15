using System.Linq;
using Application.Models.User;
using Application.CommandPattern;

namespace Application.Commands.User
{
    public class LoginCommand : Command
    {
        public LoginCommand(IMotoDBContext context, LoginUserModel Data) : base(context, Data)
        {

        }

        public override void Execute()
        {
            var Credentials = (LoginUserModel)Data;
            var data = Context.Users.Where(_ => _.Password == Credentials.Password && _.UserName == Credentials.UserName).First();

            if (data != null)
            {
                LoggedInUserData = new NewUserModel()
                {
                    UserName = data.UserName,
                    Email = data.Email,
                };
            }
        }

        public NewUserModel LoggedInUserData;
    }
}

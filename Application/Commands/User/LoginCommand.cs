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
            var data = Context.Users.Where(_ => _.Password == Credentials.Password && _.UserName == Credentials.UserName);

            IsLoggedIn = data.ToList().Count == 1;
        }

        public bool IsLoggedIn = false;
    }
}

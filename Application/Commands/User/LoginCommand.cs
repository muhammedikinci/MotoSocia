using System.Linq;
using Application.Models.User;
using Application.CommandPattern;
using Application.Actions.User;

namespace Application.Commands.User
{
    public class LoginCommand : Command
    {
        public NewUserModel LoggedInUserData;
        private LoginAction loginAction;

        public LoginCommand(IMotoDBContext context, LoginUserModel Data) : base(context, Data)
        {
            loginAction = new LoginAction(context, Data);
        }

        public override void Execute()
        {
            loginAction.Action(out LoggedInUserData);
        }
    }
}

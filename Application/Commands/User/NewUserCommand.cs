using Application.Models.User;
using Application.CommandPattern;
using Application.Actions.User;

namespace Application.Commands.User
{
    public class NewUserCommand : Command
    {
        private NewUserAction newUserAction;

        public NewUserCommand(IMotoDBContext context, NewUserModel Data) : base (context, Data)
        {
            newUserAction = new NewUserAction(context, Data);
        }

        public override void Execute()
        {
            newUserAction.Action();
        }
    }
}

using Application.Models.User;
using Application.Command;
using System.Linq;

namespace Application.Actions.User
{
    public class LoginAction : ICommand
    {
        private IMotoDBContext Context { get; set; }
        private LoginUserModel User { get; set; }
        public NewUserModel LoggedInUserData { get; set; }

        public LoginAction(IMotoDBContext Context, LoginUserModel User)
        {
            this.Context = Context;
            this.User = User;
        }

        public void Execute()
        {
            var data = Context.Users.Where(_ => _.Password == User.Password && _.UserName == User.UserName).FirstOrDefault();

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

            DatabaseLog databaseLog = new DatabaseLog();
            databaseLog.Write<LoginAction, DatabaseLog>(data != null);
        }
    }
}

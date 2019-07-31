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

        public LoginAction(Transport<LoginUserModel> transport)
        {
            this.Context = transport.Dependencies.Context;
            this.User = transport.Data;
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

            Log.Write<LoginAction, DatabaseLog>(data != null);
        }

        public object[] Result()
        {
            return new object[] { LoggedInUserData };
        }
    }
}

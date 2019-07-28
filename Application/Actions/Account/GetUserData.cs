using Application.Command;
using Application.Models.User;
using System.Linq;

namespace Application.Actions.Account
{
    public class GetUserData : ICommand
    {
        private IMotoDBContext context;
        private NewUserModel user;

        public NewUserModel FullData;

        public GetUserData(IMotoDBContext context, NewUserModel user)
        {
            this.context = context;
            this.user = user;
        }

        public void Execute()
        {
            if (context == null || user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.UserName))
                return;

            var userData = context.Users.Where(_ => _.Email == user.Email && _.UserName == user.UserName).FirstOrDefault();

            if (userData != null &&
                !string.IsNullOrEmpty(userData.UserName) &&
                !string.IsNullOrEmpty(userData.Email) &&
                !string.IsNullOrEmpty(userData.Name))
            {
                FullData = new NewUserModel() {
                    Name= userData.Name,
                    Surname= userData.Surname,
                    Email= userData.Email,
                    UserName= userData.UserName
                };
            }
        }
    }
}

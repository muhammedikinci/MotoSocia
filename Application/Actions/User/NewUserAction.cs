using Application.Models.User;
using Application.Command;
using System.Linq;

namespace Application.Actions.User
{
    public class NewUserAction : ICommand
    {
        private IMotoDBContext Context { get; set; }
        private NewUserModel User { get; set; }

        public NewUserAction(IMotoDBContext Context, NewUserModel User)
        {
            this.Context = Context;
            this.User = User;
        }

        public bool Result = false;

        public void Execute()
        {
            var data = Context.Users.Where(_ => _.UserName == User.UserName).FirstOrDefault();

            if (data == null && 
                User != null && 
                !string.IsNullOrEmpty(User.UserName) &&
                !string.IsNullOrEmpty(User.Password) &&
                !string.IsNullOrEmpty(User.Surname) &&
                !string.IsNullOrEmpty(User.Name))
            {
                Context.Users.Add(new Domain.Entities.User
                {
                    UserName = User.UserName,
                    Email = User.Email,
                    Name = User.Name,
                    Password = User.Password,
                    Surname = User.Surname
                });

                Context.SaveChanges();
                Result = true;
            }

            Log.Write<NewUserAction, DatabaseLog>(Result);
        }

        object[] ICommand.Result()
        {
            return new object[] { Result };
        }
    }
}

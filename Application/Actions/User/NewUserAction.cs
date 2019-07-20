using Application.Models.User;
using Application.Command;

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

        public void Execute()
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
        }
    }
}

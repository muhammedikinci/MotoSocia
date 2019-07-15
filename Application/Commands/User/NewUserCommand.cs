using Application.Models.User;
using Application.CommandPattern;

namespace Application.Commands.User
{
    public class NewUserCommand : Command
    {
        public NewUserCommand(IMotoDBContext context, NewUserModel Data) : base (context, Data)
        {

        }

        public override void Execute()
        {
            var user = (NewUserModel)Data;

            Context.Users.Add(new Domain.Entities.User
            {
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Surname = user.Surname
            });

            Context.SaveChanges();
        }
    }
}

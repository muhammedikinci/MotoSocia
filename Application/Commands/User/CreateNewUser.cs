namespace Application.Commands.User
{
    public class CreateNewUser : Command
    {
        public CreateNewUser(IMotoDBContext context, Models.User Data) : base (context, Data)
        {

        }

        public override void Execute()
        {
            var user = (Models.User)Data;

            context.Users.Add(new Domain.Entities.User
            {
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Surname = user.Surname
            });

            context.SaveChanges();
        }
    }
}

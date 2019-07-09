namespace Application.Commands.User
{
    public class CreateNewUser : Command
    {
        IMotoDBContext _context;

        public CreateNewUser(DataTransport dataObject) : base (dataObject)
        {

        }

        public override void Execute()
        {
            _context = DataObject._context;

            Domain.Entities.User UserData = (Domain.Entities.User)DataObject.Data;

            _context.Users.Add(UserData);
            _context.SaveChanges();
        }
    }
}

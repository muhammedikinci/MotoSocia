using Microsoft.EntityFrameworkCore;
using Persistence;
using Xunit;

namespace Application.Tests.NewUserAction
{
    public class NewUserActionTestTheoryData : TheoryData<NewUserActionTestParameter>
    {
        public NewUserActionTestTheoryData()
        {
            var options = new DbContextOptionsBuilder<MotoDBContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MotoSocia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;

            var context = new MotoDBContext(options);

            Add(new NewUserActionTestParameter
            {
                context = context,
                user = new Models.User.NewUserModel()
            });

            Add(new NewUserActionTestParameter
            {
                context = context,
                user = new Models.User.NewUserModel()
                {
                    Email = "",
                    Name = "",
                    Password = "",
                    UserName = ""
                }
            });
        }
    }
}

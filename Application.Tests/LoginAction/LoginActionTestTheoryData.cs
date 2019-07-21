using Microsoft.EntityFrameworkCore;
using Xunit;
using Persistence;

namespace Application.Tests
{
    class LoginActionTestTheoryData : TheoryData<LoginActionTestParameter>
    {
        public LoginActionTestTheoryData()
        {
            var options = new DbContextOptionsBuilder<MotoDBContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MotoSocia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;

            var context = new MotoDBContext(options);

            Add(new LoginActionTestParameter
            {
                context = context,
                user = new Models.User.LoginUserModel()
            });

            Add(new LoginActionTestParameter
            {
                context = context,
                user = new Models.User.LoginUserModel() { UserName = "", Password = "" }
            });

            Add(new LoginActionTestParameter
            {
                context = context,
                user = new Models.User.LoginUserModel() { UserName = "qqqqq", Password = "qqqqq" }
            });
        }
    }
}

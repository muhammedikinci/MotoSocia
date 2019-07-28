using Application.Models.User;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Xunit;

namespace Application.Tests.GetUserData
{
    public class GetUserDataTestTheoryData : TheoryData<GetUserDataTestParameter>
    {
        public GetUserDataTestTheoryData()
        {
            var options = new DbContextOptionsBuilder<MotoDBContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MotoSocia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;

            var context = new MotoDBContext(options);

            Add(new GetUserDataTestParameter());

            Add(new GetUserDataTestParameter()
            {
                Context = context
            });

            Add(new GetUserDataTestParameter()
            {
                Context = context,
                User = new NewUserModel()
            });

            Add(new GetUserDataTestParameter()
            {
                Context = context,
                User = new NewUserModel()
                {
                    Email="",
                    UserName=""
                }
            });

            Add(new GetUserDataTestParameter()
            {
                Context = context,
                User = new NewUserModel()
                {
                    Email = "test",
                    UserName = "test"
                }
            });
        }
    }
}

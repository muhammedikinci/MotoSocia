using Application.Command;
using Xunit;

namespace Application.Tests.GetUserData
{
    public class GetUserDataTest
    {
        [Theory, ClassData(typeof(GetUserDataTestTheoryData))]
        public void Action_NoExcaption_WhenModelAndContextIsNull(GetUserDataTestParameter parameter)
        {
            Actions.Account.GetUserData getUserData = new Actions.Account.GetUserData(parameter.Context, parameter.User);
            var getUserDataCommand = new Invoker<Actions.Account.GetUserData>(getUserData);

            getUserDataCommand.Invoke();

            Assert.Null(getUserData.FullData);
        }
    }
}

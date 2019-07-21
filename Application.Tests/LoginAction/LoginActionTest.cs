using Xunit;
using Application.Actions.User;
using Application.Command;
using Application.Models.User;

namespace Application.Tests
{
    public class LoginActionTest
    {
        [Theory, ClassData(typeof(LoginActionTestTheoryData))]
        public void Action_NoException_WhenCredentialsNullOrEmptyOrFalse(LoginActionTestParameter parameter)
        {
            LoginAction loginAction = new LoginAction(parameter.context, parameter.user);
            var command = new Invoker<LoginAction>(loginAction);
            command.Invoke();

            var emptyModel = new NewUserModel();

            Assert.Equal(emptyModel.Name, loginAction.LoggedInUserData.Name);
            Assert.Equal(emptyModel.UserName, loginAction.LoggedInUserData.UserName);
            Assert.Equal(emptyModel.Surname, loginAction.LoggedInUserData.Surname);
            Assert.Equal(emptyModel.Email, loginAction.LoggedInUserData.Email);
        }
    }
}

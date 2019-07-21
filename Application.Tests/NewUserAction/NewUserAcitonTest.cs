using Application.Command;
using Xunit;

namespace Application.Tests.NewUserAction
{
    public class NewUserAcitonTest
    {
        [Theory, ClassData(typeof(NewUserActionTestTheoryData))]
        public void Action_NoException_WhenUserDataIsNullOrEmpty(NewUserActionTestParameter parameter)
        {
            Actions.User.NewUserAction newUserAction = 
                new Actions.User.NewUserAction(parameter.context, parameter.user);
            var command = new Invoker<Actions.User.NewUserAction>(newUserAction);
            command.Invoke();

            Assert.False(newUserAction.Result);
        }
    }
}

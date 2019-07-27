using Xunit;

namespace Application.Tests.GetCurrentClaims
{
    public class GetCurrentClaimsTest
    {
        [Theory, ClassData(typeof(GetCurrentClaimsTestTheoryData))]
        public void GetCurrentClaims_NoExceptionWhenClaimsIsNullOrEmpty(GetCurrentClaimsTestParameter parameter)
        {
            Actions.Account.GetCurrentClaims getCurrentClaims = new Actions.Account.GetCurrentClaims(parameter.Claims);
            var command = new Command.Invoker<Actions.Account.GetCurrentClaims>(getCurrentClaims);

            try
            {
                command.Invoke();
            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }

            int count = 0;

            foreach (var item in parameter.Claims)
            {
                count++;
            }

            if (count == 0)
            {
                Assert.Null(getCurrentClaims.User.UserName);
            }
            else
            {
                Assert.Empty(getCurrentClaims.User.UserName);
            }
        }
    }
}

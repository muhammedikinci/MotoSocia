using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace Application.Tests.GetCurrentClaims
{
    public class GetCurrentClaimsTestTheoryData : TheoryData<GetCurrentClaimsTestParameter>
    {
        public GetCurrentClaimsTestTheoryData()
        {
            Add(new GetCurrentClaimsTestParameter()
            {
                Claims = new List<Claim>()
            });

            Add(new GetCurrentClaimsTestParameter()
            {
                Claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, ""),
                    new Claim(ClaimTypes.Name, ""),
                    new Claim(ClaimTypes.Email, ""),
                }
            });
        }
    }
}

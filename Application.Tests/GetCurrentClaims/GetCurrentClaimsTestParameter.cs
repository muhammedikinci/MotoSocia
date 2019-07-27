using Application.Models.User;
using System.Collections.Generic;
using System.Security.Claims;

namespace Application.Tests.GetCurrentClaims
{
    public class GetCurrentClaimsTestParameter
    {
        public IEnumerable<Claim> Claims { get; set; }
    }
}

using Domain.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Application.Extensions
{
    public static class AuthorizationExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.Count(c => c.Type == ClaimTypes.Role && c.Value == AuthenticationConstants.OperationClaims.AdminStr) > 0;
        }
    }
}

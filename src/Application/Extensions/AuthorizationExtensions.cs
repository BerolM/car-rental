using Domain.Constants;
using System;
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
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var id = claimsPrincipal?.Claims?.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault()?.Value;
            if (id == null)
                return 0;

            return Convert.ToInt32(id);
        }
    }
}

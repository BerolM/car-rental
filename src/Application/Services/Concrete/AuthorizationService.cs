using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    internal class AuthorizationService : IAuthorizationService
    {
        public ClaimsPrincipal GetClaimsPrincipal(User user, List<OperationClaim> operationClaims)
        {
            IEnumerable<Claim> claims = GetClaims(user, operationClaims);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, AuthenticationConstants.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
        private IEnumerable<Claim> GetClaims(User user,List<OperationClaim> operationClaims)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim("email", user.Email));
            operationClaims.ForEach(c => claims.Add(new Claim(ClaimTypes.Role, c.Id.ToString())));
            //foreach(var c in operationClaims)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, c.Name));
            //}
            return claims;
        }
    }
}

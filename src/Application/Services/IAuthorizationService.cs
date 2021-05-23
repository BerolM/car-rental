using Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Application.Services
{
    public interface IAuthorizationService
    {
        ClaimsPrincipal GetClaimsPrincipal(User user, List<OperationClaim> operationClaims);
    }
}

using Application.Infrastructure.Persistence;
using Application.Services.Commons;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    internal class UserOperationClaimService : BaseService, IUserOperationClaimService
    {
        public UserOperationClaimService(ICarRentalDbContext context) : base(context)
        {

        }
        public List<OperationClaim> GetClaims(int userId)
        {
            var claims = (from uoc in Context.UserOperationClaim.Include(x => x.OperationClaim)
                          where uoc.UserId == userId
                          select uoc.OperationClaim
                        ).ToList();
            return claims;
        }
    }
}

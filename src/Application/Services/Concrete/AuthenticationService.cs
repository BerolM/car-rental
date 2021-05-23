using Domain.Constants;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace Application.Services.Concrete
{
    internal class AuthenticationService : IAuthenticationService
    {
        private IUserService UserService { get; }
        private IUserOperationClaimService UserOperationClaimService { get; }
        private IAuthorizationService AuthorizationService { get; }

        private IHashService HashService { get; }
        
        public AuthenticationService(IUserService userService, IHashService hashService,
                                     IUserOperationClaimService userOperationClaimService,
                                     IAuthorizationService authorizationService)
        {
            UserService = userService;
            HashService = hashService;
            UserOperationClaimService = userOperationClaimService;
            AuthorizationService = authorizationService;
        }
        public Response<ClaimsPrincipal> Register(UserRegisterDTO user)
        {
            byte[] passwordHash, passwordSalt;
            HashService.Create(user.Password, out passwordHash, out passwordSalt);

            User userToCreate = new User
            {
                Email = user.EMail,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserOperationClaim = new Collection<UserOperationClaim>()
                {
                    new UserOperationClaim
                    {
                        OperationClaimId = AuthenticationConstants.OperationClaims.User
                    }
                }
            };
            var response = UserService.Add(userToCreate);
            if (response.IsSuccess==false)
            {
                return Response<ClaimsPrincipal>.Fail(response.Message);
            }

            var claimPrincipal = GetClaimsPrincipal(response.Data);
            return Response<ClaimsPrincipal>.Success("Kayıt başarılı",claimPrincipal);
        }
        public Response<ClaimsPrincipal> Login(UserLoginDTO user)
        {
            var userToChech = UserService.GetByEmail(user.EMail);
            if (userToChech == null)
                return Response<ClaimsPrincipal>.Fail("Kullanıcı adı veya parola yanlış");
            if (HashService.Verify(user.Password, userToChech.PasswordHash, userToChech.PasswordSalt) == false)
                return Response<ClaimsPrincipal>.Fail("Kullanıcı adı veya parola yanlış");

            var claimsPrincipal = GetClaimsPrincipal(userToChech);

            return Response<ClaimsPrincipal>.Success("Giriş başarılı", claimsPrincipal);
        }

        private ClaimsPrincipal GetClaimsPrincipal(User user)
        {
            var operationClaims = UserOperationClaimService.GetClaims(user.Id);
            var claimsPrincipal = AuthorizationService.GetClaimsPrincipal(user, operationClaims);
            return claimsPrincipal;
        }

    }
}

using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCCards.ViewModels.Account;

namespace TCCCards.Identity.Identity
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        //repository to get user from db
        private readonly CustomUserService _userService;

        public ResourceOwnerPasswordValidator(CustomUserService userService)
        {
            _userService = userService;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var companyName = context.Request.Raw.Get("CompanyName");

                //get your user model from db (by username - in my case its email)
                UserViewModel user = await _userService.GetUserAsync(context.UserName, context.Password, companyName);

                if (user != null)
                {
                    //set the result
                    context.Result = new GrantValidationResult(
                        subject: user.Id.ToString(),
                        authenticationMethod: "custom",
                        claims: GetUserClaims(user));
                    return;
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid credentials");
                return;
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
            throw new NotImplementedException();
        }

        //build claims array from user data
        public static Claim[] GetUserClaims(UserViewModel user)
        {
           return new Claim[]
            {
                new Claim(JwtClaimTypes.Name, user.UserName),
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.Role, user.UserLoginFrom),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("UserId", user.Id.ToString()),
            };
        }
    }
}

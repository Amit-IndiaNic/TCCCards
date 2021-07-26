using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCCards.Identity.Data;
using TCCCards.ViewModels.Account;

namespace TCCCards.Identity.Identity
{
    public class ProfileService : IProfileService
    {
        private readonly TCCContext _dataContext;
        public ProfileService(TCCContext dataContext)
        {
            _dataContext = dataContext;
        }
        ////services
        //private readonly IUserService _userService;

        //public ProfileService(IUserService userService)
        //{
        //    _userService = userService;
        //}

        //Get user profile date in terms of claims when calling /connect/userinfo
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //get subject from context (this was set ResourceOwnerPasswordValidator.ValidateAsync),
                //where and subject was set to my user id.
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
                var loginFrom = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Role);
                //var role = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Role);
                if (!string.IsNullOrEmpty(userId?.Value))
                {
                    //get user from db (find user by user id)
                    UserViewModel user = await GetUserAsync(Convert.ToString(userId.Value), Convert.ToString(loginFrom.Value));

                    // issue the claims for the users
                    if (user != null)
                    {
                        user.UserLoginFrom = loginFrom?.Value;
                        var claims = ResourceOwnerPasswordValidator.GetUserClaims(user);

                        context.IssuedClaims.AddRange(claims);//.ToList();
                    }
                }
            }
            catch (Exception)
            {
                //log your error
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                //get subject from context (set in resourceownerpasswordvalidator.validateasync),
                var userid = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");
                var loginFrom = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Role);
                if (!string.IsNullOrEmpty(userid?.Value))
                {
                    UserViewModel user = await GetUserAsync(Convert.ToString(userid.Value), Convert.ToString(loginFrom.Value));


                    if (user != null)
                    {
                        // TODO: Need to check if this functionality is needed
                        //if (user.IsActive)
                        {
                            context.IsActive = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //handle error logging
            }
        }

        private Task<UserViewModel> GetUserAsync(string userID, string loginFrom)
        {
            long userIDint = Convert.ToInt64(userID);

            switch (loginFrom)
            {
                case "RegisteredUser":
                    var user = _dataContext.User.Where(s => s.Id == userIDint).FirstOrDefault();
                    return Task.FromResult(new UserViewModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.Email,
                        UserLoginFrom = "RegisteredUser"
                    });
                //case "CreatedUser":
                //    var userDetail = _dataContext.UserDetail.Where(s => s.Id == userIDint).FirstOrDefault();
                //    return Task.FromResult(new UserViewModel
                //    {
                //        Id = userDetail.Id,
                //        Email = userDetail.Email,
                //        FirstName = userDetail.FirstName,
                //        LastName = userDetail.LastName,
                //        SQLDataSource = userDetail.SQLDataSource,
                //        SQLUserID = userDetail.SQLUserID,
                //        SQLPassword = userDetail.SQLPassword,
                //        UserName = userDetail.Email,
                //        UserLoginFrom = "CreatedUser",
                //    });
                default:
                    throw new NotImplementedException("UserType not exists");
            }
        }
    }
}

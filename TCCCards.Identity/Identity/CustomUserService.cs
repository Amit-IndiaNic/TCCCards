using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCCards.Common;
using TCCCards.Identity.Data;
using TCCCards.ViewModels.Account;

namespace TCCCards.Identity.Identity
{
    public class CustomUserService
    {
        private readonly TCCContext _dataContext;
        public CustomUserService(TCCContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<UserViewModel> GetUserAsync(string username, string password, string companyName)
        {
            var user = _dataContext.User.Where(s => s.IsActive && s.Email == username).FirstOrDefault();
            if (user != null && EncryptionUtility.Decrypt(user.Password) == password)
            {
                return Task.FromResult(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.Email,
                    UserLoginFrom = "RegisteredUser"
                });
            }

            return Task.FromResult((UserViewModel)null);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        public UserService(IUserService userService)
        {

            _userService = userService;

        }
        public async Task AddUserAsync(User user)
        {
            await _userService.AddUserAsync(user);
        }

        public Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GenerateEmailConfirmationTokenAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task GenerateForgotPasswordTokenAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> PasswordSignInAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}

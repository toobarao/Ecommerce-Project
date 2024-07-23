using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Data;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Interfaces;

namespace WearMe.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly WearMeContext _dbContext;
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(WearMeContext dbContext) {
            _dbContext = dbContext;

        }
        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
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

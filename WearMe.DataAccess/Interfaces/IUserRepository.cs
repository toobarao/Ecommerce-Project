using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.DataAccess.Interfaces
{
   public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> CreateUserAsync(User user,string password);

        Task<SignInResult> PasswordSignInAsync(User user, string password);

        Task SignOutAsync();

       // Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

        Task GenerateEmailConfirmationTokenAsync(User user);

        Task GenerateForgotPasswordTokenAsync(User user);

     //   Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
        public Task AddUserAsync(User user);
        public Task DeleteUserByIdAsync(int id);
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task UpdateUserAsync(User user);
      
    }
}

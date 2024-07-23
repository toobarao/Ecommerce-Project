using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Data;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Interfaces;
using WearMe.DataAccess.Migrations;

namespace WearMe.DataAccess.Implementations
{
    public class UserCartRepository : IUserCartRepository
    {
        private readonly WearMeContext _dbContext;
        public UserCartRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserCartAsync(UserCart userCart)
        {
            await _dbContext.UserCart.AddAsync(userCart);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteUserCartByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCart>> GetUserCartAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserCart> GetUserCartByUserIdAsync(User user)
        {
            return await _dbContext.UserCart.Where(x => x.user == user).FirstOrDefaultAsync();
        }

        public async Task UpdateUserCartAsync(UserCart userCart)
        {
             _dbContext.UserCart.Update(userCart);
            await _dbContext.SaveChangesAsync();
        }
    }
}

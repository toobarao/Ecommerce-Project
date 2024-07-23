using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public interface IUserCartService
    {
        public Task AddUserCartAsync(UserCart userCart);
        public Task DeleteUserCartByIdAsync(int id);
        public Task<IEnumerable<UserCart>> GetUserCartAsync();
        public Task<UserCart> GetUserCartByUserIdAsync(User user);
        public Task UpdateUserCartAsync(UserCart userCart);
    }
}

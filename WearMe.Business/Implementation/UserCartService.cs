using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Interfaces;

namespace WearMe.Business.Implementation
{
    public class UserCartService : IUserCartService
    {
        private readonly IUserCartRepository _userCartRepository;
        public UserCartService(IUserCartRepository userCartRepository)
        {
            _userCartRepository = userCartRepository;
        }
        public async Task AddUserCartAsync(UserCart userCart)
        {
            await _userCartRepository.AddUserCartAsync(userCart);   
        }

        public Task DeleteUserCartByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCart>> GetUserCartAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserCart> GetUserCartByUserIdAsync(User user)
        {
            return await _userCartRepository.GetUserCartByUserIdAsync(user);
        }

        public async Task UpdateUserCartAsync(UserCart userCart)
        {
            await _userCartRepository.UpdateUserCartAsync(userCart);
        }
    }
}

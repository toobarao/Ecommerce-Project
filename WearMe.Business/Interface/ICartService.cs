using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using WearMe.Business.Entities;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public interface ICartService
    {
        void AddProductToCart(CartOperationContext context);
        void RemoveProductFromCart(CartOperationContext context);
        void RemoveProductOnce(CartOperationContext context);
        List<string> GetCartItems(string cartItemsCookie);
        string? MergeAndRemoveDuplication(string cartItemsCookie, string databaseCartItem);



    }
}

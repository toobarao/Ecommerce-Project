using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.Business.Entities;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Implementation
{
    public class CartService:ICartService
    {
        public void AddProductToCart(CartOperationContext context)
        {
            context.CartItems.Add(context.ProductId);
        }

        public void RemoveProductFromCart(CartOperationContext context)
        {
            context.CartItems.RemoveAll(id => id == context.ProductId);
        }

        public void RemoveProductOnce(CartOperationContext context)
        {
            var itemToRemove = context.CartItems.FirstOrDefault(id => id == context.ProductId);
            if (itemToRemove != null)
            {
                context.CartItems.Remove(itemToRemove);
            }
        }

       

        public List<string> GetCartItems(string cartItemsCookie)
        {
            if (!string.IsNullOrEmpty(cartItemsCookie))
            {
                return JsonConvert.DeserializeObject<List<string>>(cartItemsCookie);
            }
            return new List<string>();
        }
        private Dictionary<string, int> GetItemCounts(List<string> items)
        {
            var itemCounts = new Dictionary<string, int>();
            foreach (var item in items)
            {
                if (itemCounts.ContainsKey(item))
                {
                    itemCounts[item]++;
                }
                else
                {
                    itemCounts[item] = 1;
                }
            }
            return itemCounts;
        }
        public string? MergeAndRemoveDuplication(string cartItemsCookie,string databaseCartItem)
        {
            var cartItems = GetCartItems(cartItemsCookie);
            var databaseCartItemsList = GetCartItems(databaseCartItem);

            // Create dictionaries to store counts of each item
            Dictionary<string, int> cookieDict = GetItemCounts(cartItems);
            Dictionary<string, int> databaseDict = GetItemCounts(databaseCartItemsList);

            // Merge dictionaries and remove duplicates by taking the maximum count
            foreach (var item in cookieDict)
            {
                if (databaseDict.ContainsKey(item.Key))
                {
                    databaseDict[item.Key] = Math.Max(databaseDict[item.Key], item.Value);
                }
                else
                {
                    databaseDict[item.Key] = item.Value;
                }
            }

            // Convert the dictionary back to a list
            var mergedCartItems = new List<string>();
            foreach (var item in databaseDict)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    mergedCartItems.Add(item.Key);
                }
            }

            // Serialize the merged list back to JSON
            var mergedCartItemsJson = JsonConvert.SerializeObject(mergedCartItems);
            return mergedCartItemsJson;



        }


    }
}

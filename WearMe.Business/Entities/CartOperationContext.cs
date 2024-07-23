using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.Business.Entities
{
    public class CartOperationContext
    {
        public string ProductId { get; set; }
        public List<string> CartItems { get; set; }
    }
}

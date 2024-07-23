using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Models
{
    public class CartViewModel
    {
      public List<CartProduct> cartProducts = new List<CartProduct>();
        public decimal Subtotal {  get; set; }
    }
    public class CartProduct
    {
        public ProductViewModel ProductViewModel { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}

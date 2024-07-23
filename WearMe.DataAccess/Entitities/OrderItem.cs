using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
   public class OrderItem
    {
        [Key]
      public int Id { get; set; }
        [ForeignKey("order_Id")]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order order { get; set; }
        [ForeignKey("product_Id")]
        public Product product { get; set; }
        public int Quantity {  get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice {  get; set; }

    }
}

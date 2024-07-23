using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? user_Id {  get; set; }
        [ForeignKey("user_Id")]
        public User User { get; set; }
        public Guest Guest { get; set; }
        public int? guest_Id {  get; set; }
    
        public string Status { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }
        public string shippingAddress { get; set; }
        public string paymentMethod { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
       
    }
}

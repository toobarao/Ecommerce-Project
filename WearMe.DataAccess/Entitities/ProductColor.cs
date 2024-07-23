using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
    public class ProductColor
    {
        // Composite primary key
      
        public int ProductId { get; set; }

      
        public int ColorId { get; set; }

        // Navigation properties
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WearMe.DataAccess.Entitities
{
    public class ProductSize
    {
       
        public int ProductId { get; set; }

      
        public int SizeId { get; set; }

        // Navigation properties
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("SizeId")]
        public Size Size { get; set; }
    }
}

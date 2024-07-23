using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        // public string ImageUrl { get; set; }

        //public List<Color> Colors { get; set; }
        // public List<Size> Sizes { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [ForeignKey("SubcategoryId")]
        public Subcategory Subcategory { get; set; }
        public List<Image> Images { get; set; }
    }
}

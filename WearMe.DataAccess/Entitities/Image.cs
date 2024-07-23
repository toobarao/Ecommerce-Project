using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
    public  class Image
    {
        [Key()]
        public int Id { get; set; }
        public byte[] ImageData { get; set; }

       // public string ImageUrl { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}

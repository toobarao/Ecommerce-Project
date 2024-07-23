using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Models
{
    public class ImageViewModel
    {
        [Required]
        public List<Images> images {  get; set; } 
      
        public DataAccess.Entitities.Product Product { get; set; }
        public List<Color> colors { get; set; }
        public List<Size> sizes { get; set; }
     
    }
   public class Images
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Models
{
    public class ProductViewModel
    {
       public Product product { get; set; }
        public string ImageUrl {  get; set; }
        public List<Size> sizes { get; set; }
        public List<Color> colors { get; set; }
    }
}

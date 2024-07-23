using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Models
{
    public class Check
    {
       
        public int Id { get; set; }

       
        public string Name { get; set; }
       
        public List<CategoryType> Type { get; set; }
       
        public List<Category> Category { get; set; }
    }
}

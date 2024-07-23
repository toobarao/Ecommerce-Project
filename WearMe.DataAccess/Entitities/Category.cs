using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
    public class Category
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        public  string Name { get; set; }
        public List<Subcategory> Subcategories { get; set;}
        public List<CategoryType> CategoryTypes { get; set;}


    }
}

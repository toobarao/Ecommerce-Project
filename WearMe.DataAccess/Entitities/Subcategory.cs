using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WearMe.DataAccess.Entitities
{
    public class Subcategory
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [ForeignKey("CategoryType")]
        public CategoryType? Type { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
    
        public int? CategoryType { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
    public class UserCart
    {
        public int Id { get; set; }
     
        public string userId {  get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }  
       
        public string? cartproduct {  get; set; }  
    }
}

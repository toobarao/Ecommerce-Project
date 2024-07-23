﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearMe.DataAccess.Entitities
{
    public class Gender
    {
        [Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("ProductId")]
        public string Product { get; set; }
    }
}

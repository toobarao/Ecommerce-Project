﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.DataAccess.Interfaces
{
    public interface ISubcategoryRepository
    {
        public Task AddSubcategoryAsync(Subcategory subcategory);
        public Task DeleteSubcategoryByIdAsync(int id);
        public Task<IEnumerable<Subcategory>> GetSubcategoriesAsync();
        public Task<Subcategory> GetSubcategoryByIdAsync(int id);
        public Task UpdateSubcategoryAsync(Subcategory subcategory);
    }
}

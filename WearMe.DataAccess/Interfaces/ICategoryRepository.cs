using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.DataAccess.Interfaces
{
    public  interface ICategoryRepository
    {
        public Task AddCategoryAsync(Category category);
        public Task DeleteCategoryByIdAsync(int id);
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task UpdateCategoryAsync(Category category);
        public Task<IEnumerable<CategoryType>> GetCategoryTypesByCategoryAsync(int Id);
        public Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryAsync(int Id);
    }
}

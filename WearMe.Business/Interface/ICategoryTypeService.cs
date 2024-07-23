using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public interface ICategoryTypeService
    {
        public Task<IEnumerable<CategoryType>> GetCategoryTypesAsync();
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task AddCategoryTypeAsync(CategoryType categoryType);
        public  Task<Category> GetCategoryByIdAsync(int id);
        public Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryTypeAsync(int Id);
        public Task<IEnumerable<CategoryType>> GetCategoryTypesByCategoryAsync(int Id);
        public Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryAsync(int Id);
    }
}

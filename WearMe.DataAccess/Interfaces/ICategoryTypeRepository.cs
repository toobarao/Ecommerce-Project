using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.DataAccess.Interfaces
{
    public interface ICategoryTypeRepository
    {
        public Task AddCategoryTypeAsync(CategoryType categoryType);
        public Task DeleteCategoryTypeByIdAsync(int id);
        public Task<IEnumerable<CategoryType>> GetCategoryTypesAsync();
        public Task<CategoryType> GetCategoryTypeByIdAsync(int id);
        public Task UpdateCategoryTypeAsync(CategoryType categoryType);
        public Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryTypeAsync(int Id);
    }
}

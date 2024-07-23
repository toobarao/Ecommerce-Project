using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(Category category);
        public Task DeleteCategoryByIdAsync(int id);
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task UpdateCategoryAsync(Category category);
       
    }
}

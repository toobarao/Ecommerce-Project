using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Data;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Interfaces;

namespace WearMe.DataAccess.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WearMeContext _dbContext;
        public CategoryRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddCategoryAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.Categories.SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CategoryType>> GetCategoryTypesByCategoryAsync(int Id)
        {
            
            return await _dbContext.CategoryTypes.Where(x=>x.Category.Id == Id).ToListAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryAsync(int Id)
        {

            return await _dbContext.Subcategories.Where(x => x.CategoryId == Id).ToListAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}


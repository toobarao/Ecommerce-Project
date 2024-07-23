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
    public class CategoryTypeRepository : ICategoryTypeRepository
    {
        private readonly WearMeContext _dbContext;
        public CategoryTypeRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddCategoryTypeAsync(CategoryType categoryType)
        {
            _dbContext.CategoryTypes.Add(categoryType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryTypeByIdAsync(int id)
        {
            var categoryType = await _dbContext.CategoryTypes.FindAsync(id);
            if (categoryType != null)
            {
                _dbContext.CategoryTypes.Remove(categoryType);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CategoryType> GetCategoryTypeByIdAsync(int id)
        {
            return await _dbContext.CategoryTypes.SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CategoryType>> GetCategoryTypesAsync()
        {
            return await _dbContext.CategoryTypes.Include("Category").ToListAsync();

        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryTypeAsync(int Id)
        {
            return await _dbContext.Subcategories
                                .Where(x => x.CategoryType != null && x.CategoryType == Id)
                                .ToListAsync();



        }

        public async Task UpdateCategoryTypeAsync(CategoryType categoryType)
        {
            _dbContext.CategoryTypes.Update(categoryType);
            await _dbContext.SaveChangesAsync();
        }
    }
}

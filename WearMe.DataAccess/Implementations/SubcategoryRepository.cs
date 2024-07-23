using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
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
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly WearMeContext _dbContext;

        public SubcategoryRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task AddSubcategoryAsync(Subcategory subcategory)
        {
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSubcategoryByIdAsync(int id)
        {
            var subcategory = await _dbContext.Subcategories.FindAsync(id);
            if (subcategory != null)
            {
                _dbContext.Subcategories.Remove(subcategory);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesAsync()
        {
            var subcategories = _dbContext.Subcategories.ToList();
            foreach (var subcategory in subcategories)
            {
                if (subcategory.CategoryType != null)
                {
                    CategoryType categoryType = new CategoryType();
                    categoryType = _dbContext.CategoryTypes.Find(subcategory.CategoryType);
                }
                Category category = new Category();
                category = _dbContext.Categories.Find(subcategory.CategoryId);
                subcategory.Category = category;


            }



            return subcategories;
        }

        public async Task<Subcategory> GetSubcategoryByIdAsync(int id)
        {
            return await _dbContext.Subcategories.SingleAsync(x => x.Id == id);
        }

        public async Task UpdateSubcategoryAsync(Subcategory subcategory)
        {
            _dbContext.Subcategories.Update(subcategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}

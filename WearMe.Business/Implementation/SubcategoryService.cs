using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Interfaces;

namespace WearMe.Business.Implementation
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        public SubcategoryService(ICategoryRepository categoryRepository, ICategoryTypeRepository categoryTypeRepository, ISubcategoryRepository subcategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryTypeRepository = categoryTypeRepository;
            _subcategoryRepository = subcategoryRepository;
        }
        public async Task AddSubcategoryAsync(Subcategory subcategory)
        {
            await _subcategoryRepository.AddSubcategoryAsync(subcategory);

        }

        public Task DeleteSubcategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
           return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<IEnumerable<CategoryType>> GetCategoryTypesAsync()
        {
           return await _categoryTypeRepository.GetCategoryTypesAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesAsync()
        {
            return await _subcategoryRepository.GetSubcategoriesAsync();
        }

        public Task<Subcategory> GetSubcategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSubcategoryAsync(Subcategory category)
        {
            throw new NotImplementedException();
        }
    }
}

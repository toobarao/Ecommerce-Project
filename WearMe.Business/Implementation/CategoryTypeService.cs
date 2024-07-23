using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Implementations;
using WearMe.DataAccess.Interfaces;

namespace WearMe.Business.Implementation
{
    public class CategoryTypeService : ICategoryTypeService
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryTypeService(ICategoryTypeRepository categoryTypeRepository, ICategoryRepository categoryRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryTypeAsync(CategoryType categoryType)
        {

            await _categoryTypeRepository.AddCategoryTypeAsync(categoryType);

        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<IEnumerable<CategoryType>> GetCategoryTypesAsync()
        {
            return await _categoryTypeRepository.GetCategoryTypesAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryTypeAsync(int Id)
        {
           return await _categoryTypeRepository.GetSubcategoriesByCategoryTypeAsync(Id);
        }
        public async Task<IEnumerable<CategoryType>> GetCategoryTypesByCategoryAsync(int Id)
        {
            return await _categoryRepository.GetCategoryTypesByCategoryAsync(Id);
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryAsync(int Id)
        {
            return await _categoryRepository.GetSubcategoriesByCategoryAsync(Id);
        }
    }
}

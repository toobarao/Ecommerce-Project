using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public interface IProductService
    {
        public Task AddProductAsync(Product product, List<int> colors, List<int> sizes, List<Image> images);
        public Task DeleteProductByIdAsync(int id);
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<IEnumerable<Color>> GetColorsAsync();
        public Task<IEnumerable<Size>> GetSizesAsync();
        public Task<IEnumerable<Subcategory>> GetSubcategoriesAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task UpdateProductAsync(Product product );
        public  Task<Subcategory> GetSubcategoryByIdAsync(int id);
        public Task<IEnumerable<Product>> GetProductsBySubcategoryIdAsync(int Id);
        public Task<IEnumerable<Color>> getProductColorById(int Id);
        public Task<IEnumerable<Size>> getProductSizeById(int Id);
    }
}

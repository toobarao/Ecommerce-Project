using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        public Task AddProductAsync(Product product,List<Color> colors,List<Size> sizes,List<Image> images);
        public Task DeleteProductByIdAsync(int id);
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task UpdateProductAsync(Product product);
        public Task<IEnumerable<Product>> GetProductsBySubcategoryIdAsync(int Id);
        public Task<IEnumerable<Color>> getProductColorById(int Id);
        public Task<IEnumerable<Size>> getProductSizeById(int Id);

        //public Task<IEnumerable<Subcategory>> GetSubcategoriesAsync();
    }
}

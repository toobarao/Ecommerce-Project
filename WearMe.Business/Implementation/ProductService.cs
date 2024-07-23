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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        public ProductService(IProductRepository productRepository,ISubcategoryRepository subcategoryRepository, IColorRepository colorRepository, ISizeRepository sizeRepository)
        {
            _productRepository = productRepository;
            _subcategoryRepository = subcategoryRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
        }
        public async Task AddProductAsync(Product product,List<int> colors, List<int> sizes, List<Image> images)
        {
            List<Color> colorList = new List<Color>();
            List<Size> sizeList = new List<Size>();
            foreach (var color in colors)
            {
                Color color1 = new Color();
                color1 = await _colorRepository.GetColorByIdAsync(color);
                colorList.Add(color1);
            }
            foreach (var size in sizes)
            {
                Size size1 = new Size();
                size1 = await _sizeRepository.GetSizeByIdAsync(size);
                sizeList.Add(size1);
            }
            await _productRepository.AddProductAsync(product,colorList,sizeList,images);
        }

        public async Task DeleteProductByIdAsync(int id)
        {
           await _productRepository.DeleteProductByIdAsync(id);
        }

        public async Task<IEnumerable<Color>> GetColorsAsync()
        {
            return await _colorRepository.GetColorAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            
           return  await _productRepository.GetProductByIdAsync(id);
        }
        public async Task<Subcategory> GetSubcategoryByIdAsync(int id)
        {

            return await _subcategoryRepository.GetSubcategoryByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
           return await _productRepository.GetProductsAsync();
        }

        public async Task<IEnumerable<Size>> GetSizesAsync()
        {
           return await _sizeRepository.GetSizesAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesAsync()
        {
            var subcategories= await _subcategoryRepository.GetSubcategoriesAsync();
            foreach (var subcategory in subcategories)
            {
                subcategory.Name = subcategory.Name +"-"+ subcategory.Category.Name;
                if(subcategory.Type!=null)
                {
                    subcategory.Name= subcategory.Name + "-" + subcategory.Type.Name;
                }
            }
            return subcategories;
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async  Task<IEnumerable<Product>> GetProductsBySubcategoryIdAsync(int Id)
        {
           return await _productRepository.GetProductsBySubcategoryIdAsync(Id);
        }

        public async Task<IEnumerable<Color>> getProductColorById(int Id)
        {
            return await _productRepository.getProductColorById(Id);
        }

        public async Task<IEnumerable<Size>> getProductSizeById(int Id)
        {
           return await _productRepository.getProductSizeById(Id);
        }
    }
}

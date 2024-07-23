using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Data;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Interfaces;

namespace WearMe.DataAccess.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly WearMeContext _dbContext;
        public ProductRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddProductAsync(Product product, List<Color> colors, List<Size> sizes, List<Image> images)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            foreach (var color in colors)
            {
                ProductColor productColor = new ProductColor();
                productColor.Color = color;
                productColor.Product=product;
              await  _dbContext.ProductColors.AddAsync(productColor);
                await _dbContext.SaveChangesAsync();
            }
            foreach (var size in sizes)
            {
                ProductSize productSize = new ProductSize();
                productSize.Size = size;
                productSize.Product = product;
                await _dbContext.ProductSizes.AddAsync(productSize);
                await _dbContext.SaveChangesAsync();
            }
           
            foreach (var image in images)
            {
              
                image.Product = product;
                ImageRepository imageRepository=new ImageRepository(_dbContext);
               await imageRepository.AddImageAsync(image);
            }

        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product= await _dbContext.Products.FindAsync(id);
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Color>> getProductColorById(int Id)
        {
            var productColors=await _dbContext.ProductColors.Where(x=>x.ProductId==Id).ToListAsync();
            List<Color> colorList = new List<Color>();
            foreach (var productColor in productColors)
            {
                Color color = new Color();
                color=await _dbContext.Colors.FindAsync(productColor.ColorId);
                colorList.Add(color);

            }
            return colorList;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetProductsBySubcategoryIdAsync(int Id)
        {
            return await _dbContext.Products.Where(x=>x.Subcategory.Id == Id).ToListAsync();
        }

        public async Task<IEnumerable<Size>> getProductSizeById(int Id)
        {
            var productSizes = await _dbContext.ProductSizes.Where(x => x.ProductId == Id).ToListAsync();
            List<Size> sizeList = new List<Size>();
            foreach (var productSize in productSizes)
            {
                Size size = new Size();
                size = await _dbContext.Sizes.FindAsync(productSize.SizeId);
                sizeList.Add(size);

            }
            return sizeList;
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesAsync()
        {
            return await _dbContext.Subcategories.ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}

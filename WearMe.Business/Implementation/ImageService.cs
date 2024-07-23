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
    public class ImageService:IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IProductRepository _productRepository;
        public ImageService(IImageRepository imageRepository, IProductRepository productRepository)
        {
            _imageRepository = imageRepository;
            _productRepository = productRepository;

        }

        public async Task<IEnumerable<Image>> GetImagesByProductIdAsync(int Id)
        {
            return await _imageRepository.GetImagesByProductIdAsync(Id);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await  _productRepository.GetProductByIdAsync(id);
        }
    }
}

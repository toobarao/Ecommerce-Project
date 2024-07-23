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
    public class ImageRepository : IImageRepository
    {
        private readonly WearMeContext _dbContext;
        public ImageRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddImageAsync(Image image)
        {
            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteImageByIdAsync(int id)
        {
            var image = await _dbContext.Images.FindAsync(id);
            if (image != null)
            {
                _dbContext.Images.Remove(image);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            return await _dbContext.Images.ToListAsync();
        }

        public async Task<Image> GetImagesByIdAsync(int id)
        {
            return await _dbContext.Images.SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Image>> GetImagesByProductIdAsync(int Id)
        {
            return await _dbContext.Images.Where(x=>x.Product.Id== Id).Include("Product").ToListAsync();
        }

        public async Task UpdateImageAsync(Image image)
        {
            _dbContext.Images.Update(image);
            await _dbContext.SaveChangesAsync();
        }
    }
}

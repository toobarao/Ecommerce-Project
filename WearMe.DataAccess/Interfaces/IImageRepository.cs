using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.DataAccess.Interfaces
{
    public interface IImageRepository
    {
        public Task AddImageAsync(Image image);
        public Task DeleteImageByIdAsync(int id);
        public Task<IEnumerable<Image>> GetImagesAsync();
        public Task<Image> GetImagesByIdAsync(int id);
        public Task UpdateImageAsync(Image image);
        public Task<IEnumerable<Image>> GetImagesByProductIdAsync(int Id);
    }
}

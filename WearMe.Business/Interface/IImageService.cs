using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public  interface IImageService
    {
        public Task<IEnumerable<Image>> GetImagesByProductIdAsync(int Id);
        public Task<Product> GetProductByIdAsync(int id);
    }
}

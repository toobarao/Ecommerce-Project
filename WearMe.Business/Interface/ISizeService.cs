using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public interface ISizeService
    {
        public Task AddSizeAsync(Size size);
        public Task DeleteSizeByIdAsync(int id);
        public Task<IEnumerable<Size>> GetSizesAsync();
        public Task<Size> GetSizeByIdAsync(int id);
        public Task UpdateSizeAsync(Size size);
    }
}

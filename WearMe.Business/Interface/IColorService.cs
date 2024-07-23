using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;

namespace WearMe.Business.Interface
{
    public interface IColorService
    {
        public Task AddColorAsync(Color color);
        public Task DeleteColorByIdAsync(int id);
        public Task<IEnumerable<Color>> GetColorAsync();
        public Task<Color> GetColorByIdAsync(int id);
        public Task UpdateColorAsync(Color color);
    }
}

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
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task AddColorAsync(Color color)
        {
            await _colorRepository.AddColorAsync(color);
        }

        public async Task DeleteColorByIdAsync(int id)
        {
            await _colorRepository.DeleteColorByIdAsync(id);
        }

        public async Task<IEnumerable<Color>> GetColorAsync()
        {
            return await _colorRepository.GetColorAsync();
        }

        public async Task<Color> GetColorByIdAsync(int id)
        {
            return await _colorRepository.GetColorByIdAsync(id);
        }

        public async Task UpdateColorAsync(Color color)
        {
            await _colorRepository.UpdateColorAsync(color);
        }
    }
}

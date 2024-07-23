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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
        public async Task AddSizeAsync(Size size)
        {
            await _sizeRepository.AddSizeAsync(size);
        }

        public async Task DeleteSizeByIdAsync(int id)
        {
            await _sizeRepository.DeleteSizeByIdAsync(id);
        }

        public async Task<Size> GetSizeByIdAsync(int id)
        {
            return await _sizeRepository.GetSizeByIdAsync(id);
        }

        public async Task<IEnumerable<Size>> GetSizesAsync()
        {
            return await _sizeRepository.GetSizesAsync();
        }

        public async Task UpdateSizeAsync(Size size)
        {
            await _sizeRepository.UpdateSizeAsync(size);
        }
    }
}

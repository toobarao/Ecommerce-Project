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
    public class SizeRepository : ISizeRepository
    {
        private readonly WearMeContext _dbContext;
        public SizeRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSizeAsync(Size size)
        {
            _dbContext.Sizes.Add(size);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSizeByIdAsync(int id)
        {
            var size = await _dbContext.Sizes.FindAsync(id);
            if (size != null)
            {
                _dbContext.Sizes.Remove(size);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Size> GetSizeByIdAsync(int id)
        {
            return await _dbContext.Sizes.SingleAsync(x => x.Id == id);

        }

        public async Task<IEnumerable<Size>> GetSizesAsync()
        {
            return await _dbContext.Sizes.ToListAsync();
        }

        public async Task UpdateSizeAsync(Size size)
        {
            _dbContext.Sizes.Update(size);
            await _dbContext.SaveChangesAsync();
        }
    }
}

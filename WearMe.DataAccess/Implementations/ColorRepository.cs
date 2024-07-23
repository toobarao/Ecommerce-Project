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
    public class ColorRepository : IColorRepository
    {
        private readonly WearMeContext _dbContext;
        public ColorRepository(WearMeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddColorAsync(Color color)
        {
            _dbContext.Colors.Add(color);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteColorByIdAsync(int id)
        {
            var color = await _dbContext.Colors.FindAsync(id);
            if (color != null)
            {
                _dbContext.Colors.Remove(color);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Color>> GetColorAsync()
        {
            return await _dbContext.Colors.ToListAsync();
        }

        public async Task<Color> GetColorByIdAsync(int id)
        {
            return await _dbContext.Colors.SingleAsync(x => x.Id == id);
        }

        public async Task UpdateColorAsync(Color color)
        {
            _dbContext.Colors.Update(color);
            await _dbContext.SaveChangesAsync();
        }
    }
}

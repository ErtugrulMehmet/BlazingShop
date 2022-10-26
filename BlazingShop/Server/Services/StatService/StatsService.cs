using BlazingShop.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Server.Services.StatService
{
    public class StatsService : IStatsService
    {
        private readonly DataContext _context;

        public StatsService(DataContext context)
        {
            _context = context;
        }
        public async Task<int> GetVisits()
        {
            var stats = await _context.Stats.FirstOrDefaultAsync();
            if (stats is null)
            {
                return 0;
            }
            return stats.Vists;
        }

        public async Task IncrementVisits()
        {
            var stats = await _context.Stats.FirstOrDefaultAsync();
            if (stats is null)
            {
                _context.Stats.Add(new Shared.Stats { Vists = 1 ,LastVisit=DateTime.Now });
            }
            else
            {
                stats.Vists++;
                stats.LastVisit = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }
    }
}

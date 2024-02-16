using cpu_price_monitor.Data;
using Microsoft.EntityFrameworkCore;

namespace cpu_price_monitor.Services
{
    public class PriceService : IPriceService
    {
        private readonly CpuDb _db;
        public PriceService(CpuDb db) { _db = db; }
        //public async Task<Price> GetAllPricesForCpu(int id)
        //{
        //    return await _db.Prices.FirstOrDefaultAsync(x => x.Id == id);
        //}
        public async Task<List<Price>> GetAllPricesForCpu(int cpu_id)
        {
            return await _db.Prices.Where(p => p.CpuId == cpu_id).OrderBy(p => p.DateTime).ToListAsync();
        }
    }
}

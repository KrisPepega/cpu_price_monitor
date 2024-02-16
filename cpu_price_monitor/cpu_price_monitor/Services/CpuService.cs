using cpu_price_monitor.Data;
using Microsoft.EntityFrameworkCore;

namespace cpu_price_monitor.Services
{
    public class CpuService : ICpuService
    {
        private readonly CpuDb _db;
        public CpuService(CpuDb db) { _db = db; }

        public async Task<Cpu> GetCpu(int id)
        {
            return await _db.Cpus.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Cpu>> GetAllCpus()
        {
            //List<Cpu> cpus = await _db.Cpus.ToListAsync();
            //return cpus;
            return await _db.Cpus.ToListAsync();
        }
    }
}

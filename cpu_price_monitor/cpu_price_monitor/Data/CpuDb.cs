using Microsoft.EntityFrameworkCore;

namespace cpu_price_monitor.Data
{
    public class CpuDb : DbContext
    {
        public CpuDb(DbContextOptions<CpuDb> options) : base(options){ }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}

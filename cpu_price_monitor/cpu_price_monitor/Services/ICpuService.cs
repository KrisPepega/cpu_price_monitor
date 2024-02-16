using cpu_price_monitor.Data;

namespace cpu_price_monitor.Services
{
    public interface ICpuService
    {
        public Task<Cpu> GetCpu(int id);
        public Task<List<Cpu>> GetAllCpus();
        //public Task<Cpu> CreateCpu(Cpu cpu);
        //public Task RefreshCpuDb();
        //public Task<Cpu> UpdateCpu(Cpu cpu);
        //public Task DeleteCpu(Cpu cpu);
    }
}

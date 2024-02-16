using cpu_price_monitor.Data;

namespace cpu_price_monitor.Services
{
    public interface IPriceService
    {
        //public Task<Price> GetPricesForCpu(int cpu_id);
        public Task<List<Price>> GetAllPricesForCpu(int cpu_id);
    }
}

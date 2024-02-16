namespace cpu_price_monitor.Data
{
    public class Price
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string VendorLink { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int CpuId { get; set; }
        public Cpu? Cpu { get; set; }
    }
}

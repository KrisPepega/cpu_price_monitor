using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace cpu_price_monitor.Data
{
    public class Cpu
    {
        public int Id {  get; set; }
        public uint prId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public float? UserRating { get; set; }
        public int? TotalRatings { get; set; }
        public string? Img {  get; set; }
        public int? LowestPrice { get; set; }

        public ICollection<Price>? Prices { get; }
    }
}

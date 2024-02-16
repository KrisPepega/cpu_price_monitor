using cpu_price_monitor.Data;
using cpu_price_monitor.Services;
using Microsoft.AspNetCore.Components;

namespace cpu_price_monitor.Components.Pages.Cpus
{
    public partial class AllCpus : ComponentBase
    {
        [Inject]
        protected ICpuService CpuService { get; set; }
        public List<Cpu> Cpus { get; set; }
        public string NameFilter = "";
        public string PrIdFilter = "";
        public string DescriptionFilter = "";
        public string BrandFilter = "";
        public float? UserRatingMin = null;
        public float? UserRatingMax = null;
        public int? TotalRatingsMin = null;
        public int? TotalRatingsMax = null;
        public float? PriceMin = null;
        public float? PriceMax = null;

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("On_init");
            Cpus = await CpuService.GetAllCpus();
        }

        public List<Cpu> FilteredCpus => Cpus.Where(c => c.Name.ToLower().Contains(NameFilter.ToLower()))
                                             .Where(c => c.prId.ToString().ToLower().Contains(PrIdFilter.ToLower()))
                                             .Where(c => c.Description != null ? c.Description.ToLower().Contains(DescriptionFilter.ToLower()) : true )
                                             .Where(c => c.Brand != null ? c.Brand.ToLower().Contains(BrandFilter.ToLower()) : true)
                                             .Where(c => UserRatingMin != null ? c.UserRating >= UserRatingMin : true)
                                             .Where(c => UserRatingMax != null ? c.UserRating <= UserRatingMax : true)
                                             .Where(c => TotalRatingsMin != null ? c.TotalRatings >= TotalRatingsMin : true)
                                             .Where(c => TotalRatingsMax != null ? c.TotalRatings <= TotalRatingsMax: true)
                                             .Where(c => PriceMin != null ? c.LowestPrice >= (int)(PriceMin*100) : true)
                                             .Where(c => PriceMax != null ? c.LowestPrice <= (int)(PriceMax *100) : true)
                                             .ToList();

    }
}

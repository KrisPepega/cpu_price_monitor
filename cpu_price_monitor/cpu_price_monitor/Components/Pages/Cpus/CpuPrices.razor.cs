using cpu_price_monitor.Data;
using cpu_price_monitor.Services;
using Microsoft.AspNetCore.Components;

namespace cpu_price_monitor.Components.Pages.Cpus
{
        public partial class CpuPrices : ComponentBase
        {
            
            [Inject]
            protected IPriceService PriceService { get; set; }

            [Inject]
            protected ICpuService CpuService { get; set; }

            [Parameter]
            public int Id { get; set; }

            public List<Price> Prices { get; set; }
            public Cpu? Cpu { get; set; }

            public int? IdFilter = null;
            public int? CpuIdFilter = null;
            public float? PriceMin = null;
            public float? PriceMax = null;

            protected override async Task OnInitializedAsync()
            {
                Cpu = await CpuService.GetCpu(Id);
                if (Cpu != null)
                {
                    Prices = await PriceService.GetAllPricesForCpu(Id);
                }
            }

            public List<Price> FilteredPrices => Prices.Where(p => p.Id.ToString().ToLower().Contains(IdFilter.ToString().ToLower()))
                                         .Where(p => p.CpuId.ToString().ToLower().Contains(CpuIdFilter.ToString().ToLower()))
                                         .Where(p => PriceMin != null ? p.Value >= (int)(PriceMin * 100) : true)
                                         .Where(p => PriceMax != null ? p.Value <= (int)(PriceMax * 100) : true)
                                         .ToList();
    }

}

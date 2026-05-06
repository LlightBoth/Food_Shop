using Microsoft.JSInterop;

namespace FoodShop.WebApps.Services
{
    public class ChartServices
    {
        private readonly IJSRuntime _js;

        public ChartServices(IJSRuntime js) { _js = js; }

        public async Task RenderChart(string id, ChartConfig config)
        {
            await _js.InvokeVoidAsync("chartHelper.createOrUpdateChart", id, config);
        }
    }
}

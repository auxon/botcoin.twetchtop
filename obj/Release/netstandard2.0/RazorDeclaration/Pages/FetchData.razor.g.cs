#pragma checksum "D:\repos\BotCoin.TwetchTop\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8be6fbdf4983b1d6df4da5f36c4215d0289767a"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BotCoin.TwetchTop.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.AspNetCore.Components.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using BotCoin.TwetchTop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using BitCoin.BitBus.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using BotCoin.TwetchTop.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\repos\BotCoin.TwetchTop\_Imports.razor"
using BotCoin.TwetchTop.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 37 "D:\repos\BotCoin.TwetchTop\Pages\FetchData.razor"
       
    WeatherForecast[] forecasts;

    protected override async Task OnInitAsync()
    {
        forecasts = await Http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591

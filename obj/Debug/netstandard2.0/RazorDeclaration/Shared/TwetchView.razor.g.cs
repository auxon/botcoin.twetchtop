#pragma checksum "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ca4eb7fd4686d97240f6944fa6be21536995f1b"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BotCoin.TwetchTop.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
#nullable restore
#line 1 "d:\repos\BotCoin.TwetchTop\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "d:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "d:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "d:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "d:\repos\BotCoin.TwetchTop\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "d:\repos\BotCoin.TwetchTop\_Imports.razor"
using BotCoin.TwetchTop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "d:\repos\BotCoin.TwetchTop\_Imports.razor"
using BotCoin.TwetchTop.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor"
using System.Reactive.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor"
using BitCoin.Twetch.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor"
using BitCoin.Twetch.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor"
using BotCoin.TwetchTop.Shared;

#line default
#line hidden
#nullable disable
    public class TwetchView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor"
       
    [Parameter]
    private string Title { get; set; }

    [Parameter]
    private RenderFragment ChildContent { get; set; }

    [Parameter]
    private EventCallback<UIMouseEventArgs> OnClick { get; set; }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "d:\repos\BotCoin.TwetchTop\Shared\TwetchView.razor"
       

    List<ITwetch> Twetches = new List<ITwetch>() { new Twetch("00", "Loading ...") };

    protected override void OnInit()
    {
        Twetches.Add(new Twetch("01", "OnInit called ..."));
        base.OnInit();
    }

    protected override async Task OnParametersSetAsync()
    {
        Twetches.Add(new Twetch("005", "OnParametersSetAsync called ..."));
        await base.OnParametersSetAsync();
    }

    protected override async Task OnInitAsync()
    {
        Twetches.Add(new Twetch("004", "OnInitAsync called ..."));

        //TwetchController.ObservableTwetches.Take(5)
        //    .Subscribe(twetch => Twetches.Add(twetch));

        var twetches =
               from tx in QueryTwetchProvider.GetTwetches().Take(10)
               select tx;

        await foreach (var twetch in twetches)
        {
            Twetches.Add(twetch);
        }

        Twetches.Add(new Twetch("004", "OnInitAsync complete."));

        await base.OnInitAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591

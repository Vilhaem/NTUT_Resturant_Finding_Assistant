// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BookStore.UI.Wasm.Pages.Resturants
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using BookStore.UI.Wasm;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using BookStore.UI.Wasm.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using BookStore.UI.Wasm.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using BookStore.UI.Wasm.Contracts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using BookStore.UI.Wasm.Static;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using BookStore.UI.Wasm.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/resturants/update/{Id:int}")]
    public partial class ResturantUpdate : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "c:\Users\WilliamLiu\Desktop\Resturant_manager\src\BookStore.UI.Wasm\Pages\Resturants\ResturantUpdate.razor"
       
    [Parameter]
    public int Id { get; set; }

    public Author Model = new Author();

    private bool _isSuccessful = true;

    protected override async Task OnInitializedAsync()
    {
        Model = await _repo.GetSingle(Endpoints.AuthorsEndpoint, Id);
    }

    private async Task UpdateAuthor()
    {
        _isSuccessful = await _repo.Update(Endpoints.AuthorsEndpoint, Model, Model.Id);

        if(_isSuccessful)
        {
            _toastService.ShowSuccess($"Successfully Updated Author: {Model.FirstName} {Model.LastName}");
            BackToList();
        }
        else
        {
            _isSuccessful = false;
            _toastService.ShowError("An error occurred while updating the record!");
        }
    }

    public void BackToList()
    {
        _navManager.NavigateTo("/authors/");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService _toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthorRepository _repo { get; set; }
    }
}
#pragma warning restore 1591

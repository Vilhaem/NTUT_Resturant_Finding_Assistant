using NTUT_Resturant_Finding_Assistant;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

using (var context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    context.Resturants.Add(new Resturant{
        Id = 1,
        Name = "Resturant1",
        Style = "Style1",
        PriceClass = 1,
        Distance = 1.1,
        Address = "Address1",
        Rating = 5
    });
    context.Resturants.Add(new Resturant{
        Id = 2,
        Name = "Resturant2",
        Style = "Style2",
        PriceClass = 2,
        Distance = 2.2,
        Address = "Address2",
        Rating = 4
    });
    context.SaveChanges();
    
    var resturants = context.Resturants.ToList();
    foreach(var resturant in resturants)
    {
        Console.WriteLine(resturant.Id + " " + resturant.Name + " " + resturant.Style + " " + resturant.PriceClass + " " + resturant.Distance + " " + resturant.Address + " " + resturant.Rating);
    }
    // ExecuteSqlRaw can be used to execute SQL command directly
    context.Database.ExecuteSqlRaw("Delete from Resturants where Id = 2");
    var resturantz = context.Resturants.ToList();
    foreach(var resturant in resturantz)
    {
        Console.WriteLine(resturant.Id + " " + resturant.Name + " " + resturant.Style + " " + resturant.PriceClass + " " + resturant.Distance + " " + resturant.Address + " " + resturant.Rating);
    }
}
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(options =>{options.IgnoreScriptIsolation = true;});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

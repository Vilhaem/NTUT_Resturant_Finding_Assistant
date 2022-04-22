using NTUT_Resturant_Finding_Assistant;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSqlite<ResturantStoreContext>("ResturantStore.db");

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
// var scopeFacory = app.Services.GetRequiredService<IServiceScopeFactory>();
// using (var scope = scopeFacory.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<ResturantStoreContext>();
//     db.Database.EnsureCreated();
// }

app.Run();

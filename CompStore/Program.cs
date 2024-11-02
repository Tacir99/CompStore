using CompStore.Context;
using CompStore.Manager;
using CompStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IComputerService,ComputerManager>();
builder.Services.AddScoped<IDetailService, DetailManager>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Computer}/{action=ComputerList}/{id?}");

app.Run();

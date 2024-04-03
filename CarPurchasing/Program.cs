using CarPurchasing_DAL.Models;
using CarPurchasing_DAL.Repositories.Services;
using CarPurchasing_DAL.Repositories.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CarpurchasingContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITagihanService, TagihanService>();
builder.Services.AddScoped<IMobilService, MobilService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<IUsageService, UsageService>();  
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped(sp => 
  ActivatorUtilities.CreateInstance<CarpurchasingContext>(sp)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

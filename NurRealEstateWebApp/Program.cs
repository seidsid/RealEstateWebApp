using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using NurRealEstateWebApp.Models;
using NurRealEstateWebApp.Service;
using NurRealEstateWebApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<NurDbContext, NurDbContext>();
builder.Services.AddDbContext<NurDbContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("MyConnection"));
});


// Injections
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IImageService, ImageService>();  


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Property}/{action=AddProperty}/{id?}");

app.Run();
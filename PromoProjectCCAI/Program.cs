using Microsoft.EntityFrameworkCore;
using PromoProject;
using PromoProjectCCAI;
using PromoProjectCCAI.Mapper;
using PromoProjectCCAI.Repositories.Promos;
using PromoProjectCCAI.Repositories.Stores;
using PromoProjectCCAI.Services.Promos;
using PromoProjectCCAI.Services.Stores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// config:

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

//configure connection string DBContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PromoDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repositories Dependency Injection:
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IPromoRepository, PromoRepository>();

// Services Dependency Injection:
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IPromoService, PromoService>();

// AutoMapper DI:
builder.Services.AddAutoMapper(typeof(MappingProfiles));

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

// Seed Database
PromoDbInitializer.Seed(app);

app.Run();

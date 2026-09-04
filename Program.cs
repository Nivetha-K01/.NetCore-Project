using Microsoft.EntityFrameworkCore;
using PJAverageRate.Data;
using PJAverageRate.Repository;
using PJAverageRate.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICommonPickRepository, CommonPickRepository>();
builder.Services.AddScoped<IpjAverageRateRepo, pjAveragerateRepo>();
builder.Services.AddScoped<IpjAveragerateService, pjAveragerateService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=PJAverageRate}/{id?}")
    .WithStaticAssets();


app.Run();

using Microsoft.EntityFrameworkCore;
using onpmysql.DbData;
using onpmysql.Models;
using onpmysql.Repositories;

using ZomatoDb;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CsvDbContext>(

options =>
 options.UseSqlServer(builder.Configuration.
GetConnectionString("DefaultConnection")));
// serverVersion: ServerVersion.AutoDetect(
//     builder.Configuration.GetConnectionString("DefaultConnection"))));

// builder.Services.AddDbContext<ZomatoDb>(options =>
// options.UseMySql(builder.Configuration.GetConnectionString("ZomatoConnection"),
// new MySqlServerVersion(new Version(8, 0, 0)))
// );

builder.Services.AddScoped<ITwitterRepository, TwitterRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
    app.UseSwaggerUI();


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

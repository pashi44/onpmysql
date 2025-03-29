using Microsoft.EntityFrameworkCore;
using onpmysql.DbData;
using onpmysql.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CsvDbContext>(

options =>
 options.UseMySql(builder.Configuration.
GetConnectionString("DefaultConnection"),
serverVersion: ServerVersion.AutoDetect(
    builder.Configuration.GetConnectionString("DefaultConnection"))));


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

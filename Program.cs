using Microsoft.EntityFrameworkCore;
using onpmysql.DbData;
using onpmysql.Models;
using onpmysql.Repositories;
using ZomatoDb;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "onpmysqlAPI",
        Version = "v1"
    });
});


builder.Services.AddDbContext<CsvDbContext>(

options =>
 options.UseMySql(builder.Configuration.
GetConnectionString("DefaultConnection"),
serverVersion: ServerVersion.AutoDetect(
    builder.Configuration.GetConnectionString("DefaultConnection"))));

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
    app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");





// app.MapControllerRoute(
    // name: "zomato",
    // pattern: "{action=zomato}/{id?}",
    // defaults: new { controller = "Zomato" }
// );
app.Run();

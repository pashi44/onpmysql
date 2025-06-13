using Microsoft.EntityFrameworkCore;
using onpmysql.DbData;
using onpmysql.Models;
using onpmysql.Repositories;

using ZomatoDb;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Services.AddSwaggerGen();



try
{
    builder.Services.AddDbContext<CsvDbContext>(options =>
        options.UseMySql(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
            serverVersion: ServerVersion.AutoDetect(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
        )
    );
}
catch (Exception ex)
{
    Console.WriteLine("❌ Failed to configure MySQL DbContext: " + ex.Message);
    // You can also log the full exception or rethrow
    // throw;
}

builder.Services.AddDbContext<IdenDbContext>(

options =>
options.UseSqlite(builder.Configuration.GetConnectionString("IdenConn"))
);



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
// app.UseSerilogRequestLogging();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

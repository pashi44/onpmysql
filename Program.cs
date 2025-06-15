using Microsoft.EntityFrameworkCore;
using onpmysql.DbData;
using onpmysql.Models;
using onpmysql.Repositories;

using ZomatoDb;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Models.Identity;
using Microsoft.AspNetCore.Identity;

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

// builder.Services.AddDbContext<ZomatoDb>(options =>
// options.UseMySql(builder.Configuration.GetConnectionString("ZomatoConnection"),
// new MySqlServerVersion(new Version(8, 0, 0)))
// );


//modeled in the iden.cs 
builder.Services.AddDbContext<IdenDbContext>(
options =>
// options.UseSqlite(builder.Configuration.GetConnectionString("IdenConn"))
options.UseSqlite(builder.Configuration["ConnectionStrings:IdenConn"])
);

//registered     authorization of type AppUserservice to  the middleware
//from IdenDbStore
builder.Services.AddIdentityCore<AppUser>()
.AddEntityFrameworkStores<IdenDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<ITwitterRepository, TwitterRepository>();

builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(

options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Bearer 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Bearer 
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;



}
).AddJwtBearer(
options =>
{

    System.String? secret = builder.Configuration["JwtConfig:Secret"];
    System.String? issuer = builder.Configuration["JwtConfig:ValidIssuer"];
    System.String? audience = builder.Configuration["JwtConfig:ValidAudience"];

    if ((secret == null || issuer == null || audience == null))
        throw new ApplicationException("JWT token audience or issuer isnt set");
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;

    options.TokenValidationParameters = new()
    {

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidIssuer = issuer,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))


    };


}

);





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
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

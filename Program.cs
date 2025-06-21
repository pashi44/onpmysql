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
using Microsoft.OpenApi.Models;
using DotNetEnv;

using StackExchange.Redis;

DotNetEnv.Env.Load();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

//builder.Services.AddSingleton<IConnectionMultiplexer>(
//sp =>
// ConnectionMultiplexer.Connect("localhost:6739")


//);



if (builder.Environment.IsDevelopment())
{


    builder.Configuration.AddUserSecrets<Program>();

}

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

try
{
    builder.Services.AddDbContextPool<CsvDbContext>(options =>
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
//     options.UseMySql(builder.Configuration.GetConnectionString("ZomatoConnection"),
//     new MySqlServerVersion(new Version(8, 0, 0)))
// );

// modeled in the iden.cs 
builder.Services.AddDbContextPool<IdenDbContext>(
    options =>
    // options.UseSqlite(builder.Configuration.GetConnectionString("IdenConn"))
    options.UseSqlite(builder.Configuration["ConnectionStrings:IdenConn"])
);

// registered authorization of type AppUserService to the middleware
// from IdenDbStore
builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdenDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ITwitterRepository, TwitterRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
   // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Bearer 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Bearer 
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("Bearer"  , options =>
{
    System.String? secret = builder.Configuration["JwtConfig:Secret"];
    System.String? issuer = builder.Configuration["JwtConfig:ValidIssuer"];
    System.String? audience = builder.Configuration["JwtConfig:ValidAudiences"];

    if ((secret == null || issuer == null || audience == null))
        throw new ApplicationException("JWT token audience or issuer isn't set");

    options.SaveToken = true;
    options.RequireHttpsMetadata = false;

    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = audience,
        ValidIssuer = issuer,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
    };
});



//redis cache registering to  the middle pipeline
// builder.Services.AddSingleton<ZomatoController>();

var app = builder.Build();

// scoped service for adding roles 
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // these scoped services create the AspNetRoles in the db store
    if (!await roleManager.RoleExistsAsync(AppRoles.User))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.User));
    }

    if (!await roleManager.RoleExistsAsync(AppRoles.VipUser))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.VipUser));
    }

    if (!await roleManager.RoleExistsAsync(AppRoles.Administrator))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.Administrator));
    }
} // create service scope


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

// app.UseSerilogRequestLogging(); // optionally enable request logging

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

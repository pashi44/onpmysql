

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


public class IdenDbContext : IdentityDbContext<AppUser>
{

    private readonly IConfiguration _configuration;

    public IdenDbContext(DbContextOptions<IdenDbContext> options, IConfiguration configuration)
        : base(options)
    {

        _configuration = configuration;

    }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);



    }



}



using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



public class IdenDbContext : IdentityDbContext<AppUser>
{
    public IdenDbContext(DbContextOptions<IdenDbContext> options)
        : base(options) { }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }



}

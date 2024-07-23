using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WearMe.Presentation.Areas.Identity.Data;

namespace WearMe.Presentation.Data;

/*public class WearMePresentationContext : IdentityDbContext<WearMePresentationUser>
{
    public WearMePresentationContext(DbContextOptions<WearMePresentationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}*/

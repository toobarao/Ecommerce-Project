using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.DataAccess.Entitities;
using Color = WearMe.DataAccess.Entitities.Color;
using Size = WearMe.DataAccess.Entitities.Size;

namespace WearMe.DataAccess.Data
{
    public class WearMeContext:IdentityDbContext<User>
    {
        

        public WearMeContext(DbContextOptions<WearMeContext> options):base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<UserCart> UserCart { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .Property(o => o.createdAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .Property(o => o.updatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Product>()
           .Property(p => p.CreatedDate)
           .HasDefaultValueSql("GETUTCDATE()");

            // Configure composite primary key using Fluent API
            modelBuilder.Entity<ProductColor>()
                .HasKey(pc => new { pc.ProductId, pc.ColorId });
            modelBuilder.Entity<ProductSize>()
               .HasKey(pc => new { pc.ProductId, pc.SizeId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

        }
    }

    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }
}


using BarnManagement.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarnManagement.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Barn> Barns { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSpecies> AnimalSpecies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BarnInventory> BarnInventories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Barn>()
                .HasOne(b => b.OwnerUser)
                .WithOne(u => u.Barn)
                .HasForeignKey<Barn>(b => b.OwnerUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BarnInventory>()
                .HasOne(bi => bi.Barn)
                .WithMany(b => b.Inventory)
                .HasForeignKey(bi => bi.BarnId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Barn>().Property(b => b.BarnBalance).HasColumnType("decimal(18,2)");
            builder.Entity<Sale>().Property(s => s.SaleAmount).HasColumnType("decimal(18,2)");
            builder.Entity<Sale>().Property(s => s.UnitPriceAtSale).HasColumnType("decimal(18,2)");
            builder.Entity<Purchase>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Entity<Purchase>().Property(p => p.TotalCost).HasColumnType("decimal(18,2)");
            builder.Entity<Product>().Property(p => p.ProductPrice).HasColumnType("decimal(18,2)");

            builder.Entity<AnimalSpecies>().Property(s => s.AnimalSpeciesPurchasePrice).HasColumnType("decimal(18,2)");

        }
    }
}

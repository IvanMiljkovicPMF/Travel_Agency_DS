using Microsoft.EntityFrameworkCore;
using Models;
using Models.AllPackages;

namespace Utils.DataConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<SeaPackage> SeaPackages { get; set; }
        public DbSet<MountainPackage> MountainPackages { get; set; }
        public DbSet<ExcursionPackage> ExcursionPackages { get; set; }
        public DbSet<CruisePackage> CruisePackages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasIndex(c => c.PassportNumber).IsUnique();

            modelBuilder.Entity<TravelPackage>()
                .HasDiscriminator<string>("PackageType")
                .HasValue<SeaPackage>("Sea")
                .HasValue<MountainPackage>("Mountain")
                .HasValue<ExcursionPackage>("Excursion")
                .HasValue<CruisePackage>("Cruise");

            // Many-to-many for Reservation
            modelBuilder.Entity<Reservation>().HasKey(r => r.Id);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.TravelPackage)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.TravelPackageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

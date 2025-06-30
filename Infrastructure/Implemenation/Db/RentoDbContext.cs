using Microsoft.EntityFrameworkCore;
using Rento.Entities;

namespace Rento.Infrastructure.Implemenation.Db
{
    public class RentoDbContext() : DbContext
    {
        public virtual DbSet<Branch> Branchs { get; set; }
        public virtual DbSet<BranchWorkingHour> BranchWorkingHours { get; set; }
        public virtual DbSet<VehicleCategorie> VehicleCategories { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }
        public virtual DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "Initial Catalog=RentoDb;" +
                "Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                        .HasMany<BranchWorkingHour>()
                        .WithOne()
                        .HasForeignKey(b => b.BranchId)
                        .IsRequired();

            modelBuilder.Entity<BranchWorkingHour>()
                        .OwnsMany(b => b.Intervals, WorkingHourIntervalBuilder =>
                        {
                            WorkingHourIntervalBuilder.ToJson();
                        });

            modelBuilder.Entity<Branch>()
                        .HasMany<Vehicle>()
                        .WithOne()
                        .HasForeignKey(v => v.BranchId);

            modelBuilder.Entity<Vehicle>()
                        .HasOne<VehicleManufacturer>()
                        .WithOne()
                        .HasForeignKey<Vehicle>(v => v.VehicleManufacturerId);

            modelBuilder.Entity<Vehicle>()
                        .HasOne<VehicleModel>()
                        .WithOne()
                        .HasForeignKey<Vehicle>(v => v.VehicleModelId);

            modelBuilder.Entity<VehicleCategorie>()
                        .HasMany<VehicleModel>()
                        .WithOne()
                        .HasForeignKey(vm => vm.VehicleCategorieId);

            modelBuilder.Entity<Branch>() 
                .Property(r => r.CoordinatesLatitude).HasPrecision(15, 15);
            modelBuilder.Entity<Branch>()
                .Property(r => r.CoordinatesLongitude).HasPrecision(15, 15);

            base.OnModelCreating(modelBuilder);
        }
    }
}

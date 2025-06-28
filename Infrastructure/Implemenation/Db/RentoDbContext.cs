using Microsoft.EntityFrameworkCore;
using Rento.Entities;
using Rento.Entities.ValueObjects;

namespace Rento.Infrastructure.Implemenation.Db
{
    public class RentoDbContext() : DbContext
    {
        public virtual DbSet<Branch> Branchs { get; set; }
        public virtual DbSet<BranchWorkingHour> BranchWorkingHours { get; set; }

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
                .Property(r => r.CoordinatesLatitude).HasPrecision(15, 15);
            modelBuilder.Entity<Branch>()
                .Property(r => r.CoordinatesLongitude).HasPrecision(15, 15);

            base.OnModelCreating(modelBuilder);
        }
    }
}

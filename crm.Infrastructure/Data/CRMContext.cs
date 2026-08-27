using crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace crm.Infrastructure.Data
{
    public class CRMContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Followup> Followups { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<StatusFollowup> StatusHistory { get; set; }

        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(x => x.Governorate)
                    .WithMany(x => x.Areas)
                    .HasForeignKey(x => x.GovernorateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(x => x.IsDeleted)
                    .HasDefaultValue(false);

                entity.HasOne(x => x.Area)
                    .WithMany(x => x.Customers)
                    .HasForeignKey(x => x.AreaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Tag)
                    .WithMany(x => x.Customers)
                    .HasForeignKey(x => x.TagId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Followup>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.DeviceType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.Notes)
                    .HasMaxLength(500);

                entity.Property(x => x.PaymentType)
                    .HasConversion<int>();

                entity.Property(x => x.DeviceCondition)
                    .HasConversion<int>();

                entity.Property(x => x.OperationType)
                    .HasConversion<int>();

                entity.Property(x => x.Platform)
                    .HasConversion<int>();

                entity.HasOne(x => x.Customer)
                    .WithMany(x => x.Followups)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.StatusHistory)
                    .WithOne(x => x.Followup)
                    .HasForeignKey(x => x.FollowupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<StatusFollowup>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Status)
                    .HasConversion<int>();

                entity.Property(x => x.Notes)
                    .HasMaxLength(500);
            });
        }
    }
}
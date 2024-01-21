using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Domain.Models;

namespace webapi.DataAccess.Context
{
    public class TravelAppContext : IdentityDbContext<TravelUser>
    {
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Payment> PaymentEvents { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }

        public TravelAppContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            setModelBuilderContractEntity(modelBuilder);
            setModelBuilderInvoiceEntity(modelBuilder);
            setModelBuilderOrganizationEntity(modelBuilder);
            setModelBuilderPaymentEntity(modelBuilder);

            modelBuilder.Entity<TravelUser>()
                .HasOne(entity => entity.Organization)
                .WithMany(entity => entity.Users)
                .HasForeignKey(entity => entity.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void setModelBuilderContractEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasOne(entity => entity.Organization)
                .WithMany(entity => entity.Contracts)
                .HasForeignKey(entity => entity.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(entity => entity.User)
                .WithMany(entity => entity.Contracts)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasIndex(entity => entity.ContractNumber)
                .IsUnique();

            modelBuilder.Entity<Contract>()
                .Property(entity => entity.Footer)
                .HasColumnType("VARCHAR(255)");
        }

        private void setModelBuilderInvoiceEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasIndex(entity => entity.Number)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .Property(entity => entity.Note)
                .HasColumnType("VARCHAR(255)");

            modelBuilder.Entity<Invoice>()
                .HasOne(entity => entity.User)
                .WithMany(entity => entity.Invoices)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void setModelBuilderOrganizationEntity()
        {
            modelBuilder.Entity<Organization>()
                .Property(entity => entity.DefaultFooter)
                .HasColumnType("VARCHAR(255)");

            modelBuilder.Entity<Organization>()
                .Property(entity => entity.InvoiceNote)
                .HasColumnType("VARCHAR(255)");
        }

        private void setModelBuilderPaymentEntity()
        {
            modelBuilder.Entity<Payment>()
                .Property(entity => entity.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Payment>()
                .HasOne(entity => entity.User)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(entity => entity.Contract)
                .HasForeignKey(entity => entity.ContractId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(entity => entity.Invoice)
                .HasForeignKey(entity => entity.InvoiceId);
        }
    }
}
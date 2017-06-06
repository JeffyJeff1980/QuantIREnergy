using Microsoft.EntityFrameworkCore;
using QuantIREnergy2.Models;

namespace QuantIREnergy2.Data
{
    public class QuantContext : DbContext
    {
        public QuantContext(DbContextOptions<QuantContext> options) : base(options)
        {
        }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<Institution>().ToTable("Institution");
            modelBuilder.Entity<Investor>().ToTable("Investor");
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            var connectionString = @"Server=localhost;Database=QuantIREnergyDB;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
        }
    }
}

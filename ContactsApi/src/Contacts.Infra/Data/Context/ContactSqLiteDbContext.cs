using Contacts.Infra.Data.Mapping;
using Contacts.Infra.Data.DBOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Contacts.Infra.Data.Context
{
    public class ContactSqliteDbContext : DbContext
    {
        public DbSet<NaturalPersonDBO> NaturalPerson{ get; set; }
        public DbSet<LegalPersonDBO> LegalPerson { get; set; }
        public DbSet<AddressDBO> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            optionsBuilder.UseSqlite(config["SQLiteConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new LegalPersonMap());
            modelBuilder.ApplyConfiguration(new NaturalPersonMap());
        }
    }
}

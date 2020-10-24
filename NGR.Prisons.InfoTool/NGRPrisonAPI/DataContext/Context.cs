using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NGRPrisonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.DataContext
{
    public class Context : DbContext
    {
        private readonly IConfiguration _config;
        public Context(IConfiguration config, DbContextOptions<Context> options) : base(options)
        {
            _config = config;
        }

        public DbSet<State> State { get; set; }
        public DbSet<Prison> Prisons { get; set; }
        public DbSet<Inmate> Inmates { get; set; }

        protected override  void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_config.GetConnectionString("AppConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .HasData(new
                {
                    Id = 1,
                    StateName = "Abia"
                },
                new
                {
                    Id = 2,
                    StateName = "Imo"
                });

            modelBuilder.Entity<Prison>()
                .HasData(new
                {
                    Id = 1,
                    PrisonName = "Abia Maximum",
                    StateId = 1,
                    DateCreated = DateTime.UtcNow,
                    EstablishedDate = new DateTime(1990, 02, 22)
                },
                new
                {
                    Id = 2,
                    PrisonName = "Abia Manimum",
                    StateId = 1,
                    DateCreated = DateTime.UtcNow,
                    EstablishedDate = new DateTime(1980, 02, 22)
                },
                new
                {
                    Id = 3,
                    PrisonName = "Imo Maximum",
                    StateId = 2,
                    DateCreated = DateTime.UtcNow,
                    EstablishedDate = new DateTime(1980, 02, 22)
                });

            modelBuilder.Entity<Inmate>()
                .HasData(new
                {
                    Id = 1,
                    FirstName = "Jane",
                    LastName = "Doe",
                    PrisonId = 1,
                    DateCreated = DateTime.UtcNow,
                    SentencedDate = new DateTime(1995, 02, 22),
                    Gender ="Female",
                    Offenses = "Aggravated sex and armed robbery",
                    DateOfBirth = new DateTime(1965, 10, 22),
                    RelasedDate = new DateTime(2010, 02, 22),
                    StateId = 1
                },
                new
                {
                    Id = 2,
                    FirstName = "Joe",
                    LastName = "Doe",
                    PrisonId = 3,
                    DateCreated = DateTime.UtcNow,
                    SentencedDate = new DateTime(1990, 02, 22),
                    Gender = "Male",
                    Offenses = "Serial Rapist",
                    DateOfBirth = new DateTime(1960, 10, 22),
                    RelasedDate = new DateTime(2020, 02, 22),
                    StateId = 2
                });
            
            modelBuilder.Entity<Inmate>()   
                .HasOne(u => u.State).WithMany(u => u.Inmates).IsRequired().OnDelete(DeleteBehavior.Restrict);

        }
    }
}

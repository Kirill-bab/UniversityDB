using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB.DAL.Entities;

namespace UniversityDB.DAL.Contexts
{
    public class DatabaseManagerContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        //public DbSet<Game> Games { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        //public DbSet<ExpSession> ExpSessions { get; set; }

        /// <inheritdoc />
        public DatabaseManagerContext(DbContextOptions<DatabaseManagerContext> options) : base(options)
        {
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5437;Database=postgres;Username=postgres;Password=qwerty");
            optionsBuilder.LogTo(Console.WriteLine);
            
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable("Students");
            modelBuilder.Entity<Faculty>()
                .ToTable("Faculties");
            //modelBuilder.Entity<Category>()
            //    .ToTable("Categories");
            //modelBuilder.Entity<Provider>()
            //    .ToTable("Providers");
            //modelBuilder.Entity<Tag>()
            //    .ToTable("Tags");
            //modelBuilder.Entity<ExpSession>()
            //    .ToTable("ExpiredSessions");
        }
    }
}

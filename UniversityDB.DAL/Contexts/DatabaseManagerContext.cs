using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB.DAL.Entities;
using UniversityDB.DAL.Entities.TeachersRanks;

namespace UniversityDB.DAL.Contexts
{
    public class DatabaseManagerContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<SeniorTeacher> SeniorTeachers { get; set; }
        public DbSet<Docent> Docents { get; set; }
        public DbSet<Proffesor> Proffesors { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<ScheduleItem> Schedule { get; set; }
        public DbSet<Group> Groups { get; set; }

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

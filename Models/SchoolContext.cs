using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration;
using System;
namespace Kolokvijum2.Models
{
    public class SchoolContext : DbContext
    {
        //skole studenti
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        public SchoolContext() { }
        public SchoolContext(DbContextOptions options) : base(options) {  }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            //string s = configuration.GetConnectionString("DefaultConnection");
            //uzima connection string iz appsetting
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21)));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //definisanje tabela u bazi, 
            //ne radi ako baza ne postoji, rpvo napraviti mysql bazu
            modelBuilder.Entity<School>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<School>()
                .Property(p => p.Id)
                .UseMySQLAutoIncrementColumn("INT");


            modelBuilder.Entity<School>()
                .Property(p => p.Name)
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<School>()
                .Property(p => p.Description)
                .HasColumnType("TEXT")
                .HasMaxLength(120)
                .IsRequired();

            // 1-N veza tabela
            modelBuilder.Entity<Student>()
                .HasOne(t => t.School)
                .WithMany(t => t.Students);

            modelBuilder.Entity<Student>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Student>()
                .Property(p => p.Id)
                .UseMySQLAutoIncrementColumn("INT");

            //indeks je unique
            modelBuilder.Entity<Student>()
                .HasIndex(p => p.Index)
                .IsUnique();
            //atribut indeksa maxlength 30
            modelBuilder.Entity<Student>()
                .Property(p => p.Index)
                .HasMaxLength(30);

            modelBuilder.Entity<Student>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

            // More constrict?
            modelBuilder.Entity<Student>()
                .Property(p => p.Age)
                .IsRequired();

            // Bolje bi bilo da ima reference tabela ali ok
            modelBuilder.Entity<Student>()
                .Property(p => p.Gender)
                .HasMaxLength(6)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.YearOfStudy)
                .IsRequired();
        }
    }
}

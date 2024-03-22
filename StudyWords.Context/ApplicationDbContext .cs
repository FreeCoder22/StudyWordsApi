using StudyWords.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;

namespace StudyWords.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
          : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Word> Word { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"), serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Word>().Property(w => w.LastUpdateDate).HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");
            modelBuilder.Entity<User>().Property(u => u.LastUpdateDate).HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }

}

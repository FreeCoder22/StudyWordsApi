﻿using EnglishWords.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;

namespace EnglishWords.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Word> Word { get; set; }
        public DbSet<User> User { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
            optionsBuilder.UseMySql("Server=localhost; Port=3307; User ID=root; Password=abc123$$; Database=EnglishWords;", serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Word>().Property(w => w.LastUpdateDate).HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");
            modelBuilder.Entity<User>().Property(u => u.LastUpdateDate).HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");
            modelBuilder.Entity<Word>().HasIndex(w => w.WordText).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.EnsureCreated(); // Create the database if it doesn't exist

            //    var isWord = context.Word.FirstOrDefault(b => b.WordText == "test");
            //    if (isWord == null)
            //    {
            //        context.Word.Add(new Word { WordText = "test", WordTranslate = "test", IsLearning = false, CreateAtDate = DateTime.Now });
            //    }

            //    context.SaveChanges();
            //}

        }
    }

}
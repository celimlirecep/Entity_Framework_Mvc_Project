using DatabaseImageProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseImageProject.Models
{
    public class DatabaseImageProjectContext:DbContext
    {
        public DatabaseImageProjectContext()
        {

        }
        public DatabaseImageProjectContext(DbContextOptions<DatabaseImageProjectContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DatabaseImage");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Ignore(x => x.file);
                entity.Ignore(x => x.ImageFullPath);
                
            });
        }

    }
}

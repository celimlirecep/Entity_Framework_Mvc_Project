using Microsoft.EntityFrameworkCore;
using Sales.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models.Concreate
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {

        }
        
        public SalesDbContext(DbContextOptions<SalesDbContext> options):base(options)//ctor
        {

        }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:SalesConn");

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codefirstdeneme.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace  codefirstdeneme.Models.Entities
{
    public class LibraryContext:DbContext
    {
        public LibraryContext (DbContextOptions<LibraryContext> options):base(options){

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:KutuphaneConnection");
            }
        }

        
    }
}
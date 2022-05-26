using Ef_2504.DAL.Concrete.EF.Config;
using Ef_2504.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_2504.DAL.Concrete.EF
{
    public class BookAppDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RECEP-CELIMLI\\SQLEXPRESS;Database=BookAppDb;User=sa;Pwd=123");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfig());
            //modelBuilder.ApplyConfiguration(new AuthorConfig());
            //modelBuilder.ApplyConfiguration(new BookConfig());
            //modelBuilder.ApplyConfiguration(new BookDetailConfig());

            //toplu halde kullanma
            //var olan konfiglerimizden herhang, birini alarak tüm konfiglere aynılarının uygulanmasını sağlar
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfig).Assembly);
        }




    }
}

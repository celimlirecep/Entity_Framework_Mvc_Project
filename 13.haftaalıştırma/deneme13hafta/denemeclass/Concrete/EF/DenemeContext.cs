using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using denemeclass.Concrete.EF.Config;
using denemeclass.Entities;
using Microsoft.EntityFrameworkCore;

namespace denemeclass.Concrete.EF
{
    public class DenemeContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookDetail> bookDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RECEP-CELIMLI\\SQLEXPRESS;Database=DenemeLibraryApp;User=sa;Pwd=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly);
        }


    }
}

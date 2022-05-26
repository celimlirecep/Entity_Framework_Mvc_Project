using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using denemeclass.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace denemeclass.Concrete.EF.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(c => c.BookName).IsRequired();
            builder.Property(c => c.BookPrice).HasDefaultValue(0);
            builder.Property(b => b.BookCreateDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(

              new Book { BookId = 1, BookName = "Yeni başlayanlar için c#", BookImgUrl = "https://www.nobelkitap.com/nblurun/nobelkitap_com_460233.jpg", BookPrice = 150, CategoryId = 1 },
              new Book { BookId = 2, BookName = "Yeni başlayanlar için Pyton", BookImgUrl = "https://i.dr.com.tr/cache/500x400-0/originals/0000000694609-1.jpg", BookPrice = 150, CategoryId = 2 },
              new Book { BookId = 3, BookName = "javascript Programlama", BookImgUrl = "https://i.dr.com.tr/cache/600x600-0/originals/0000000457676-1.jpg", BookPrice = 150, CategoryId = 3 }


              );
        }
    }
}

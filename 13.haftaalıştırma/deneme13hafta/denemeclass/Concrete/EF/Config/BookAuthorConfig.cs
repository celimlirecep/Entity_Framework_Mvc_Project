using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using denemeclass.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace denemeclass.Concrete.EF.Config
{
    public class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(ba => ba.BookAuthorId);

            builder.HasOne(b => b.Book)
                .WithMany(b => b.BookAuthor)
                .HasForeignKey(b => b.BookId);

            builder.HasOne(b => b.Author)
                .WithMany(b => b.BookAuthor)
                .HasForeignKey(b => b.AuthorId);
            builder.HasData(
               new BookAuthor { BookAuthorId = 1, BookId = 1, AuthorId = 1 },
               new BookAuthor { BookAuthorId = 2, BookId = 2, AuthorId = 2 },
               new BookAuthor { BookAuthorId = 3, BookId = 3, AuthorId = 3 }
               );

        }
    }
}

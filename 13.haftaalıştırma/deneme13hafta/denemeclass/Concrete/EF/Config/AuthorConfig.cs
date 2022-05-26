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
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);
            builder.Property(a => a.AuthorFirstName).IsRequired();
            builder.Property(a => a.AuthorLastName).IsRequired();
            builder.Ignore(a => a.AuthorFullName);
            builder.Property(a => a.AuthorCreatedDate).HasDefaultValue(DateTime.Now);

            builder.HasData(
               new Author { AuthorId = 1, AuthorFirstName = "Şeyma", AuthorLastName = "kalın" },
               new Author { AuthorId = 2, AuthorFirstName = "cansu", AuthorLastName = "hayat" },
               new Author { AuthorId = 3, AuthorFirstName = "Melike", AuthorLastName = "ruhani" }

               );
        }
    }
}

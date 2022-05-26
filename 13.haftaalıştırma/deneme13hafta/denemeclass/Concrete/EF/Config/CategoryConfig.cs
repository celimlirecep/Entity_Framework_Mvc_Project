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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryName).IsRequired();

            builder.HasData(
              new Category { CategoryId = 1, CategoryName = "Roman", CategoryDescription = "romanlar" },
              new Category { CategoryId = 2, CategoryName = "Hikaye", CategoryDescription = "Hikayeler" },
              new Category { CategoryId = 3, CategoryName = "Bilgisayar", CategoryDescription = "Bİlgisayar Kitapları" }


              );
        }
    }
}

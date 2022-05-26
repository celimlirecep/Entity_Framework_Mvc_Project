using Ef_2504.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ef_2504.DAL.Concrete.EF.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Categoryname).IsRequired();
            builder.HasData(
                new Category { CategoryId = 1, Categoryname = "Roman", CategoryDescription = "romanlar" },
                new Category { CategoryId = 2, Categoryname = "Hikaye", CategoryDescription = "Hikayeler" },
                new Category { CategoryId = 3, Categoryname = "Bilgisayar", CategoryDescription = "Bİlgisayar Kitapları" }


                );

        }
    }
}

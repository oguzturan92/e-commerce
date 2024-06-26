using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class Category3Configuration : IEntityTypeConfiguration<Category3>
    {
        public void Configure(EntityTypeBuilder<Category3> builder)
        {
            builder.HasData(
                new Category3() {
                    Category3Id = 1,
                    Category3Name = "Gömlek",
                    Category3Description = "",
                    Category3Url = "gomlek",
                    Category3Approval = true,
                    Category3Sort = 1,
                    Category3ListType = "Urun",
                    Category3Visibility = "MenuTrue",
                    Category2Id = 1
                },
                new Category3() {
                    Category3Id = 2,
                    Category3Name = "Tişört",
                    Category3Description = "",
                    Category3Url = "tisort",
                    Category3Approval = true,
                    Category3Sort = 2,
                    Category3ListType = "Urun",
                    Category3Visibility = "MenuTrue",
                    Category2Id = 1
                },
                new Category3() {
                    Category3Id = 3,
                    Category3Name = "Pantolon",
                    Category3Description = "",
                    Category3Url = "pantolon",
                    Category3Approval = true,
                    Category3Sort = 1,
                    Category3ListType = "Urun",
                    Category3Visibility = "MenuTrue",
                    Category2Id = 2
                }
            );
        }
    }
}
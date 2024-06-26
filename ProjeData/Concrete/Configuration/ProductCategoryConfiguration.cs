using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                new ProductCategory() { CategoryId=1, ProductId=1},
                new ProductCategory() { CategoryId=1, ProductId=2},
                new ProductCategory() { CategoryId=1, ProductId=3},
                new ProductCategory() { CategoryId=1, ProductId=4},
                new ProductCategory() { CategoryId=1, ProductId=5},
                new ProductCategory() { CategoryId=3, ProductId=6},
                new ProductCategory() { CategoryId=1, ProductId=7},
                new ProductCategory() { CategoryId=1, ProductId=8},
                new ProductCategory() { CategoryId=2, ProductId=8},
                new ProductCategory() { CategoryId=1, ProductId=9},
                new ProductCategory() { CategoryId=1, ProductId=10},
                new ProductCategory() { CategoryId=2, ProductId=10},
                new ProductCategory() { CategoryId=3, ProductId=10},
                new ProductCategory() { CategoryId=1, ProductId=11},
                new ProductCategory() { CategoryId=3, ProductId=11},
                new ProductCategory() { CategoryId=2, ProductId=12}
            );
        }
    }
}
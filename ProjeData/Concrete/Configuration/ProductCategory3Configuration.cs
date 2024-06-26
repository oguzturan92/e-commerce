using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductCategory3Configuration : IEntityTypeConfiguration<ProductCategory3>
    {
        public void Configure(EntityTypeBuilder<ProductCategory3> builder)
        {
            builder.HasData(
                new ProductCategory3() { Category3Id=2, ProductId=1},
                new ProductCategory3() { Category3Id=2, ProductId=2},
                new ProductCategory3() { Category3Id=2, ProductId=4},
                new ProductCategory3() { Category3Id=1, ProductId=5},
                new ProductCategory3() { Category3Id=3, ProductId=7},
                new ProductCategory3() { Category3Id=1, ProductId=8},
                new ProductCategory3() { Category3Id=1, ProductId=9},
                new ProductCategory3() { Category3Id=1, ProductId=11},
                new ProductCategory3() { Category3Id=3, ProductId=11}
            );
        }
    }
}
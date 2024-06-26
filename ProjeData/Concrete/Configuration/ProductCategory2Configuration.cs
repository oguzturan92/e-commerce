using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductCategory2Configuration : IEntityTypeConfiguration<ProductCategory2>
    {
        public void Configure(EntityTypeBuilder<ProductCategory2> builder)
        {
            builder.HasData(
                new ProductCategory2() { Category2Id=1, ProductId=1},
                new ProductCategory2() { Category2Id=1, ProductId=3},
                new ProductCategory2() { Category2Id=1, ProductId=5},
                new ProductCategory2() { Category2Id=2, ProductId=7},
                new ProductCategory2() { Category2Id=3, ProductId=7},
                new ProductCategory2() { Category2Id=1, ProductId=8},
                new ProductCategory2() { Category2Id=6, ProductId=8},
                new ProductCategory2() { Category2Id=1, ProductId=9},
                new ProductCategory2() { Category2Id=4, ProductId=10},
                new ProductCategory2() { Category2Id=1, ProductId=11},
                new ProductCategory2() { Category2Id=5, ProductId=12},
                new ProductCategory2() { Category2Id=6, ProductId=12}
            );
        }
    }
}
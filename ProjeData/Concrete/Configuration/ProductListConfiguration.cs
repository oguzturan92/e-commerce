using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductListConfiguration : IEntityTypeConfiguration<ProductList>
    {
        public void Configure(EntityTypeBuilder<ProductList> builder)
        {
            builder.HasData(
                new ProductList() { ProductId=1, ListId=1},
                new ProductList() { ProductId=2, ListId=1},
                new ProductList() { ProductId=3, ListId=1},
                new ProductList() { ProductId=5, ListId=1},
                new ProductList() { ProductId=6, ListId=1},
                new ProductList() { ProductId=8, ListId=1},
                new ProductList() { ProductId=10, ListId=1},
                new ProductList() { ProductId=1, ListId=2},
                new ProductList() { ProductId=2, ListId=2},
                new ProductList() { ProductId=3, ListId=2},
                new ProductList() { ProductId=5, ListId=2},
                new ProductList() { ProductId=8, ListId=2},
                new ProductList() { ProductId=9, ListId=2},
                new ProductList() { ProductId=10, ListId=2},
                new ProductList() { ProductId=11, ListId=2},
                new ProductList() { ProductId=12, ListId=2}
            );
        }
    }
}
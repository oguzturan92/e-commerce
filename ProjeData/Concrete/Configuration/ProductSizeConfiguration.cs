using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasData(
                new ProductSize() {
                    ProductSizeId=1,
                    ProductSizePrice=250,
                    ProductSizeStock=10,
                    SizeId=1,
                    ProductId=1
                },
                new ProductSize() {
                    ProductSizeId=2,
                    ProductSizePrice=250,
                    ProductSizeStock=10,
                    SizeId=2,
                    ProductId=1
                },
                new ProductSize() {
                    ProductSizeId=3,
                    ProductSizePrice=250,
                    ProductSizeStock=10,
                    SizeId=3,
                    ProductId=1
                },
                new ProductSize() {
                    ProductSizeId=4,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=1,
                    ProductId=2
                },
                new ProductSize() {
                    ProductSizeId=5,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=2,
                    ProductId=2
                },
                new ProductSize() {
                    ProductSizeId=6,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=3,
                    ProductId=2
                },
                new ProductSize() {
                    ProductSizeId=7,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=1,
                    ProductId=4
                },
                new ProductSize() {
                    ProductSizeId=8,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=2,
                    ProductId=4
                },
                new ProductSize() {
                    ProductSizeId=9,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=3,
                    ProductId=4
                },
                new ProductSize() {
                    ProductSizeId=10,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=4,
                    ProductId=4
                },
                new ProductSize() {
                    ProductSizeId=11,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=5,
                    ProductId=4
                },
                new ProductSize() {
                    ProductSizeId=12,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=1,
                    ProductId=5
                },
                new ProductSize() {
                    ProductSizeId=13,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=2,
                    ProductId=5
                },
                new ProductSize() {
                    ProductSizeId=14,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=3,
                    ProductId=5
                },
                new ProductSize() {
                    ProductSizeId=15,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=4,
                    ProductId=5
                },
                new ProductSize() {
                    ProductSizeId=16,
                    ProductSizePrice=6999,
                    ProductSizeStock=10,
                    SizeId=4,
                    ProductId=7
                },
                new ProductSize() {
                    ProductSizeId=17,
                    ProductSizePrice=5999,
                    ProductSizeStock=10,
                    SizeId=5,
                    ProductId=7
                },
                new ProductSize() {
                    ProductSizeId=18,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=1,
                    ProductId=8
                },
                new ProductSize() {
                    ProductSizeId=19,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=2,
                    ProductId=8
                },
                new ProductSize() {
                    ProductSizeId=20,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=3,
                    ProductId=8
                },
                new ProductSize() {
                    ProductSizeId=21,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=4,
                    ProductId=8
                },
                new ProductSize() {
                    ProductSizeId=22,
                    ProductSizePrice=0,
                    ProductSizeStock=0,
                    SizeId=5,
                    ProductId=8
                },
                new ProductSize() {
                    ProductSizeId=23,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=1,
                    ProductId=9
                },
                new ProductSize() {
                    ProductSizeId=24,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=2,
                    ProductId=9
                },
                new ProductSize() {
                    ProductSizeId=25,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=3,
                    ProductId=9
                },
                new ProductSize() {
                    ProductSizeId=26,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=4,
                    ProductId=9
                },
                new ProductSize() {
                    ProductSizeId=27,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=5,
                    ProductId=9
                },
                new ProductSize() {
                    ProductSizeId=28,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=17,
                    ProductId=10
                },
                new ProductSize() {
                    ProductSizeId=29,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=18,
                    ProductId=10
                },
                new ProductSize() {
                    ProductSizeId=30,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=19,
                    ProductId=10
                },
                new ProductSize() {
                    ProductSizeId=31,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=20,
                    ProductId=10
                },
                new ProductSize() {
                    ProductSizeId=32,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=21,
                    ProductId=10
                },
                new ProductSize() {
                    ProductSizeId=33,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=1,
                    ProductId=11
                },
                new ProductSize() {
                    ProductSizeId=34,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=2,
                    ProductId=11
                },
                new ProductSize() {
                    ProductSizeId=35,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=3,
                    ProductId=11
                },
                new ProductSize() {
                    ProductSizeId=36,
                    ProductSizePrice=4999,
                    ProductSizeStock=10,
                    SizeId=4,
                    ProductId=11
                },
                new ProductSize() {
                    ProductSizeId=37,
                    ProductSizePrice=4999,
                    ProductSizeStock=10,
                    SizeId=5,
                    ProductId=11
                },
                new ProductSize() {
                    ProductSizeId=38,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=17,
                    ProductId=12
                },
                new ProductSize() {
                    ProductSizeId=39,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=18,
                    ProductId=12
                },
                new ProductSize() {
                    ProductSizeId=40,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=19,
                    ProductId=12
                },
                new ProductSize() {
                    ProductSizeId=41,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=20,
                    ProductId=12
                },
                new ProductSize() {
                    ProductSizeId=42,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=21,
                    ProductId=12
                },
                new ProductSize() {
                    ProductSizeId=43,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=7,
                    ProductId=3
                },
                new ProductSize() {
                    ProductSizeId=44,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=9,
                    ProductId=3
                },
                new ProductSize() {
                    ProductSizeId=45,
                    ProductSizePrice=0,
                    ProductSizeStock=10,
                    SizeId=10,
                    ProductId=3
                }
            );
        }
    }
}
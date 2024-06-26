using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(
                new ProductImage() {
                    ProductImageId=1,
                    ProductImageName="product-1-1.jpg",
                    ProductImageSort=1,
                    ProductId=1
                },
                new ProductImage() {
                    ProductImageId=2,
                    ProductImageName="product-1-2.jpg",
                    ProductImageSort=2,
                    ProductId=1
                },
                new ProductImage() {
                    ProductImageId=3,
                    ProductImageName="product-2-1.jpg",
                    ProductImageSort=1,
                    ProductId=2
                },
                new ProductImage() {
                    ProductImageId=4,
                    ProductImageName="product-2-2.jpg",
                    ProductImageSort=2,
                    ProductId=2
                },
                new ProductImage() {
                    ProductImageId=5,
                    ProductImageName="product-4-1.jpg",
                    ProductImageSort=1,
                    ProductId=3
                },
                new ProductImage() {
                    ProductImageId=6,
                    ProductImageName="product-4-2.jpg",
                    ProductImageSort=2,
                    ProductId=3
                },
                new ProductImage() {
                    ProductImageId=7,
                    ProductImageName="product-5-1.jpg",
                    ProductImageSort=1,
                    ProductId=4
                },
                new ProductImage() {
                    ProductImageId=8,
                    ProductImageName="product-5-2.jpg",
                    ProductImageSort=2,
                    ProductId=4
                },
                new ProductImage() {
                    ProductImageId=9,
                    ProductImageName="product-3-1.jpg",
                    ProductImageSort=1,
                    ProductId=5
                },
                new ProductImage() {
                    ProductImageId=10,
                    ProductImageName="product-3-2.jpg",
                    ProductImageSort=2,
                    ProductId=5
                },
                new ProductImage() {
                    ProductImageId=11,
                    ProductImageName="product-6-1.jpg",
                    ProductImageSort=1,
                    ProductId=6
                },
                new ProductImage() {
                    ProductImageId=12,
                    ProductImageName="product-6-2.jpg",
                    ProductImageSort=2,
                    ProductId=6
                },
                new ProductImage() {
                    ProductImageId=13,
                    ProductImageName="product-7-1.jpg",
                    ProductImageSort=1,
                    ProductId=7
                },
                new ProductImage() {
                    ProductImageId=14,
                    ProductImageName="product-7-2.jpg",
                    ProductImageSort=2,
                    ProductId=7
                },
                new ProductImage() {
                    ProductImageId=15,
                    ProductImageName="product-8-1.jpg",
                    ProductImageSort=1,
                    ProductId=8
                },
                new ProductImage() {
                    ProductImageId=16,
                    ProductImageName="product-8-2.jpg",
                    ProductImageSort=2,
                    ProductId=8
                },
                new ProductImage() {
                    ProductImageId=17,
                    ProductImageName="product-9-1.jpg",
                    ProductImageSort=1,
                    ProductId=9
                },
                new ProductImage() {
                    ProductImageId=18,
                    ProductImageName="product-9-2.jpg",
                    ProductImageSort=2,
                    ProductId=9
                },
                new ProductImage() {
                    ProductImageId=19,
                    ProductImageName="product-10-1.jpg",
                    ProductImageSort=1,
                    ProductId=10
                },
                new ProductImage() {
                    ProductImageId=20,
                    ProductImageName="product-10-2.jpg",
                    ProductImageSort=2,
                    ProductId=10
                },
                new ProductImage() {
                    ProductImageId=21,
                    ProductImageName="product-10-3.jpg",
                    ProductImageSort=3,
                    ProductId=10
                },
                new ProductImage() {
                    ProductImageId=22,
                    ProductImageName="product-10-4.jpg",
                    ProductImageSort=4,
                    ProductId=10
                },
                new ProductImage() {
                    ProductImageId=23,
                    ProductImageName="product-11-1.jpg",
                    ProductImageSort=1,
                    ProductId=11
                },
                new ProductImage() {
                    ProductImageId=24,
                    ProductImageName="product-11-2.jpg",
                    ProductImageSort=2,
                    ProductId=11
                },
                new ProductImage() {
                    ProductImageId=25,
                    ProductImageName="product-11-3.jpg",
                    ProductImageSort=3,
                    ProductId=11
                },
                new ProductImage() {
                    ProductImageId=26,
                    ProductImageName="product-12-1.jpg",
                    ProductImageSort=1,
                    ProductId=12
                },
                new ProductImage() {
                    ProductImageId=27,
                    ProductImageName="product-12-2.jpg",
                    ProductImageSort=2,
                    ProductId=12
                }
            );
        }
    }
}
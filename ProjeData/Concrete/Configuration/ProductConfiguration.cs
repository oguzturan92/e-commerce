using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() {
                    ProductId = 1,
                    ProductName = "Takım Elbise",
                    ProductShortName = "Takım elbise Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "Krem",
                    ProductPrice = 7999,
                    ProductSalePrice = 4999,
                    ProductUrl = "takim-elbise",
                    ProductImage = "product-1-1.jpg",
                    ProductApproval = true,
                    ProductSort = 1,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 2,
                    ProductName = "Siyah Tişört.",
                    ProductShortName = "Siyah Tişört Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 4999,
                    ProductSalePrice = 3999,
                    ProductUrl = "siyah-tisort",
                    ProductImage = "product-2-1.jpg",
                    ProductApproval = true,
                    ProductSort = 2,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 3,
                    ProductName = "Kahverengi Atkı",
                    ProductShortName = "Kahverengi atkı. Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "Standart",
                    ProductPrice = 499,
                    ProductSalePrice = 349,
                    ProductUrl = "kahverengi-atki",
                    ProductImage = "product-4-1.jpg",
                    ProductApproval = true,
                    ProductSort = 3,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 4,
                    ProductName = "Beyaz Basic Tişört",
                    ProductShortName = "Beyaz basic tişört. Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 999,
                    ProductSalePrice = 899,
                    ProductUrl = "beyaz-basic-tisort",
                    ProductImage = "product-5-1.jpg",
                    ProductApproval = false,
                    ProductSort = 4,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 5,
                    ProductName = "Bej Renk Kalın Tulum",
                    ProductShortName = "Bej Renk Kaln Tulum Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 3999,
                    ProductSalePrice = 2999,
                    ProductUrl = "bej-renk-kalin-tulum",
                    ProductImage = "product-3-1.jpg",
                    ProductApproval = true,
                    ProductSort = 5,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 6,
                    ProductName = "Yüzük ve Kolye",
                    ProductShortName = "Yüzük ve Kolye Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "Standart",
                    ProductPrice = 299,
                    ProductSalePrice = 0,
                    ProductUrl = "yuzuk-ve-kolye",
                    ProductImage = "product-6-1.jpg",
                    ProductApproval = true,
                    ProductSort = 6,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 7,
                    ProductName = "Uzun Palto",
                    ProductShortName = "Uzun Palto Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 12999,
                    ProductSalePrice = 9999,
                    ProductUrl = "uzun-palto",
                    ProductImage = "product-7-1.jpg",
                    ProductApproval = true,
                    ProductSort = 7,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 8,
                    ProductName = "Figürlü Gömlek",
                    ProductShortName = "Figürlü Gömlek Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 1999,
                    ProductSalePrice = 999,
                    ProductUrl = "figurlu-gomlek",
                    ProductImage = "product-8-1.jpg",
                    ProductApproval = true,
                    ProductSort = 8,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 9,
                    ProductName = "Kare Desenli Gömlek",
                    ProductShortName = "Kare Desenli Gömlek Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 2499,
                    ProductSalePrice = 0,
                    ProductUrl = "kare-desenli-gomlek",
                    ProductImage = "product-9-1.jpg",
                    ProductApproval = true,
                    ProductSort = 9,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 10,
                    ProductName = "Koşu Ayakkabısı",
                    ProductShortName = "Koşu Ayakkabısı Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 14999,
                    ProductSalePrice = 7499,
                    ProductUrl = "kosu-ayakkabisi",
                    ProductImage = "product-10-1.jpg",
                    ProductApproval = true,
                    ProductSort = 10,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 11,
                    ProductName = "Kırmızı Triko",
                    ProductShortName = "Kırmızı Triko Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 14999,
                    ProductSalePrice = 7499,
                    ProductUrl = "kirmizi-triko",
                    ProductImage = "product-11-1.jpg",
                    ProductApproval = true,
                    ProductSort = 11,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                },
                new Product() {
                    ProductId = 12,
                    ProductName = "Mevsimlik Bot",
                    ProductShortName = "Mevsimlik Bot Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!",
                    ProductColor = "",
                    ProductPrice = 7999,
                    ProductSalePrice = 6999,
                    ProductUrl = "mevsimlik-bot",
                    ProductImage = "product-12-1.jpg",
                    ProductApproval = true,
                    ProductSort = 12,
                    ProductStock = 10,
                    ProductKdv = 10,
                    ProductSeoTitle = "Seo başlık",
                    ProductSeoDescription = "Seo açıklama",
                    ProductSeoKeyword = "Seo anahtar kelime"
                }
            );
        }
    }
}
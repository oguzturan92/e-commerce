using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasData(
                new Size() {
                    SizeId=1,
                    SizeTitle="S Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="S",
                    SizeImage="",
                    SizeSort=1,
                    SizeTypeId=2
                },
                new Size() {
                    SizeId=2,
                    SizeTitle="M Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="M",
                    SizeImage="",
                    SizeSort=2,
                    SizeTypeId=2
                },
                new Size() {
                    SizeId=3,
                    SizeTitle="L Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="L",
                    SizeImage="",
                    SizeSort=3,
                    SizeTypeId=2
                },
                new Size() {
                    SizeId=4,
                    SizeTitle="XL Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="XL",
                    SizeImage="",
                    SizeSort=4,
                    SizeTypeId=2
                },
                new Size() {
                    SizeId=5,
                    SizeTitle="XXL Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="XXL",
                    SizeImage="",
                    SizeSort=5,
                    SizeTypeId=2
                },
                new Size() {
                    SizeId=6,
                    SizeTitle="Beyaz",
                    SizeWriteOrImg="Resim",
                    SizeWrite="",
                    SizeImage="beyaz.jpg",
                    SizeSort=1,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=7,
                    SizeTitle="Sarı",
                    SizeWriteOrImg="Resim",
                    SizeWrite="",
                    SizeImage="sari.jpg",
                    SizeSort=2,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=8,
                    SizeTitle="Turuncu",
                    SizeWriteOrImg="Resim",
                    SizeWrite="",
                    SizeImage="turuncu.jpg",
                    SizeSort=3,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=9,
                    SizeTitle="Mavi",
                    SizeWriteOrImg="Resim",
                    SizeWrite="",
                    SizeImage="mavi.jpg",
                    SizeSort=4,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=10,
                    SizeTitle="Siyah",
                    SizeWriteOrImg="Resim",
                    SizeWrite="",
                    SizeImage="siyah.jpg",
                    SizeSort=5,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=11,
                    SizeTitle="42 Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="42",
                    SizeImage="",
                    SizeSort=16,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=12,
                    SizeTitle="44 Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="44",
                    SizeImage="",
                    SizeSort=17,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=13,
                    SizeTitle="46 Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="46",
                    SizeImage="",
                    SizeSort=18,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=14,
                    SizeTitle="48 Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="48",
                    SizeImage="",
                    SizeSort=19,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=15,
                    SizeTitle="50 Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="50",
                    SizeImage="",
                    SizeSort=20,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=16,
                    SizeTitle="52 Beden",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="52",
                    SizeImage="",
                    SizeSort=21,
                    SizeTypeId=1
                },
                new Size() {
                    SizeId=17,
                    SizeTitle="40 Numara",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="40",
                    SizeImage="",
                    SizeSort=1,
                    SizeTypeId=3
                },
                new Size() {
                    SizeId=18,
                    SizeTitle="41 Numara",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="41",
                    SizeImage="",
                    SizeSort=2,
                    SizeTypeId=3
                },
                new Size() {
                    SizeId=19,
                    SizeTitle="42 Numara",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="42",
                    SizeImage="",
                    SizeSort=3,
                    SizeTypeId=3
                },
                new Size() {
                    SizeId=20,
                    SizeTitle="43 Numara",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="43",
                    SizeImage="",
                    SizeSort=4,
                    SizeTypeId=3
                },
                new Size() {
                    SizeId=21,
                    SizeTitle="44 Numara",
                    SizeWriteOrImg="Yazi",
                    SizeWrite="44",
                    SizeImage="",
                    SizeSort=5,
                    SizeTypeId=3
                }
            );
        }
    }
}
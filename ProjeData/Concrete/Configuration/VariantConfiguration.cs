using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class VariantConfiguration : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.HasData(
                new Variant() {VariantId=1,VariantSecond=1,ProductId=3},
                new Variant() {VariantId=2,VariantSecond=3,ProductId=3},
                new Variant() {VariantId=3,VariantSecond=5,ProductId=3},
                new Variant() {VariantId=4,VariantSecond=7,ProductId=3},
                new Variant() {VariantId=5,VariantSecond=9,ProductId=3},

                new Variant() {VariantId=6,VariantSecond=5,ProductId=10},
                new Variant() {VariantId=7,VariantSecond=6,ProductId=10},
                new Variant() {VariantId=8,VariantSecond=7,ProductId=10},
                new Variant() {VariantId=9,VariantSecond=12,ProductId=10},

                new Variant() {VariantId=10,VariantSecond=1,ProductId=11},
                new Variant() {VariantId=11,VariantSecond=7,ProductId=11},
                new Variant() {VariantId=12,VariantSecond=8,ProductId=11},

                new Variant() {VariantId=13,VariantSecond=9,ProductId=12},
                new Variant() {VariantId=14,VariantSecond=10,ProductId=12},

                new Variant() {VariantId=15,VariantSecond=7,ProductId=9},
                new Variant() {VariantId=16,VariantSecond=8,ProductId=9},
                new Variant() {VariantId=17,VariantSecond=10,ProductId=9},
                new Variant() {VariantId=18,VariantSecond=11,ProductId=9},

                new Variant() {VariantId=19,VariantSecond=5,ProductId=6},
                new Variant() {VariantId=20,VariantSecond=7,ProductId=6},
                new Variant() {VariantId=21,VariantSecond=8,ProductId=6},
                new Variant() {VariantId=22,VariantSecond=9,ProductId=6},
                new Variant() {VariantId=23,VariantSecond=10,ProductId=6},

                new Variant() {VariantId=24,VariantSecond=1,ProductId=8},
                new Variant() {VariantId=25,VariantSecond=2,ProductId=8},
                new Variant() {VariantId=26,VariantSecond=5,ProductId=8},
                new Variant() {VariantId=27,VariantSecond=6,ProductId=8},
                new Variant() {VariantId=28,VariantSecond=7,ProductId=8},
                new Variant() {VariantId=29,VariantSecond=9,ProductId=8},
                new Variant() {VariantId=30,VariantSecond=10,ProductId=8},

                new Variant() {VariantId=31,VariantSecond=2,ProductId=7},
                new Variant() {VariantId=32,VariantSecond=5,ProductId=7},
                new Variant() {VariantId=33,VariantSecond=6,ProductId=7},
                new Variant() {VariantId=34,VariantSecond=9,ProductId=7},
                new Variant() {VariantId=35,VariantSecond=10,ProductId=7},
                new Variant() {VariantId=36,VariantSecond=12,ProductId=7},
                
                new Variant() {VariantId=37,VariantSecond=2,ProductId=1},
                new Variant() {VariantId=38,VariantSecond=3,ProductId=1},
                new Variant() {VariantId=39,VariantSecond=5,ProductId=1},
                new Variant() {VariantId=40,VariantSecond=7,ProductId=1},
                new Variant() {VariantId=41,VariantSecond=9,ProductId=1},

                new Variant() {VariantId=42,VariantSecond=2,ProductId=2},
                new Variant() {VariantId=43,VariantSecond=6,ProductId=2},
                new Variant() {VariantId=44,VariantSecond=8,ProductId=2},
                new Variant() {VariantId=45,VariantSecond=10,ProductId=2},

                new Variant() {VariantId=46,VariantSecond=1,ProductId=5},
                new Variant() {VariantId=47,VariantSecond=2,ProductId=5},
                new Variant() {VariantId=48,VariantSecond=3,ProductId=5},
                new Variant() {VariantId=49,VariantSecond=5,ProductId=5},
                new Variant() {VariantId=50,VariantSecond=6,ProductId=5},
                new Variant() {VariantId=51,VariantSecond=1,ProductId=5}
            );
        }
    }
}
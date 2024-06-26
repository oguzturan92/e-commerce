using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class SizeTypeConfiguration : IEntityTypeConfiguration<SizeType>
    {
        public void Configure(EntityTypeBuilder<SizeType> builder)
        {
            builder.HasData(
                new SizeType() {
                    SizeTypeId=1,
                    SizeTypeName="RENK",
                    SizeTypeSort=1
                },
                new SizeType() {
                    SizeTypeId=2,
                    SizeTypeName="BEDEN",
                    SizeTypeSort=2
                },
                new SizeType() {
                    SizeTypeId=3,
                    SizeTypeName="NUMARA",
                    SizeTypeSort=3
                }
            );
        }
    }
}
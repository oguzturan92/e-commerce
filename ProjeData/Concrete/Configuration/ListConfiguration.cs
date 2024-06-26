using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ListConfiguration : IEntityTypeConfiguration<List>
    {
        public void Configure(EntityTypeBuilder<List> builder)
        {
            builder.HasData(
                new List() {
                    ListId=1,
                    ListTitle="Kombin Ürünler",
                    ListLocation="Ozel",
                    ListType="Standart",
                    ListColumn=4,
                    ListApproval=true,
                    ListSort=1,
                    ProductId=1
                },
                new List() {
                    ListId=2,
                    ListTitle="Haftanın Ürünleri",
                    ListLocation="Genel",
                    ListType="Kaydirmali",
                    ListColumn=4,
                    ListApproval=true,
                    ListSort=2,
                    ProductId=1
                }
            );
        }
    }
}
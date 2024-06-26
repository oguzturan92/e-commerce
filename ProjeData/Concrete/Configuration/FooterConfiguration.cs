using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class FooterConfiguration : IEntityTypeConfiguration<Footer>
    {
        public void Configure(EntityTypeBuilder<Footer> builder)
        {
            builder.HasData(
                new Footer() {
                    FooterId=1,
                    FooterTitle="KURUMSAL",
                    FooterApproval=true,
                    FooterSort=1
                },
                new Footer() {
                    FooterId=2,
                    FooterTitle="YARDIM",
                    FooterApproval=true,
                    FooterSort=2
                },
                new Footer() {
                    FooterId=3,
                    FooterTitle="ALIŞVERİŞ",
                    FooterApproval=true,
                    FooterSort=3
                }
            );
        }
    }
}
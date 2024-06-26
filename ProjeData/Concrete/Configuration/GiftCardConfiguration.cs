using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class GiftCardConfiguration : IEntityTypeConfiguration<GiftCard>
    {
        public void Configure(EntityTypeBuilder<GiftCard> builder)
        {
            builder.HasData(
                new GiftCard() {
                    GiftCardId = 1,
                    GiftCardTitle = "HDY1",
                    GiftCardOran = 20,
                    GiftCardMiktar = 0,
                    GiftCardApproval = true,
                    GiftCardDateTime = new DateTime(2023,10,01, 15,35,33),
                    GiftCardLimit = 100
                },
                new GiftCard() {
                    GiftCardId = 2,
                    GiftCardTitle = "HDY2",
                    GiftCardOran = 0,
                    GiftCardMiktar = 100,
                    GiftCardApproval = false,
                    GiftCardDateTime = new DateTime(2023,10,23, 15,35,33),
                    GiftCardLimit = 50
                }
            );
        }
    }
}
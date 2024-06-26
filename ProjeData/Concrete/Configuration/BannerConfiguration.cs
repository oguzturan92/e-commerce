using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasData(
                new Banner() {
                    BannerId=1,
                    BannerName="Banner 1",
                    BannerDescription="Banner 1 açıklama",
                    BannerLink="/",
                    BannerImage="1920-4.jpg",
                    BannerApproval=true,
                    BannerSort=1,
                    HomeDesignTypeId=1
                },
                new Banner() {
                    BannerId=2,
                    BannerName="Banner 2",
                    BannerDescription="Banner 2 açıklama",
                    BannerLink="/",
                    BannerImage="1920-3.jpg",
                    BannerApproval=true,
                    BannerSort=2,
                    HomeDesignTypeId=1
                },
                new Banner() {
                    BannerId=3,
                    BannerName="Banner 3",
                    BannerDescription="Banner 3 açıklama",
                    BannerLink="/",
                    BannerImage="1920-2.jpg",
                    BannerApproval=true,
                    BannerSort=3,
                    HomeDesignTypeId=1
                },
                new Banner() {
                    BannerId=4,
                    BannerName="Banner 4",
                    BannerDescription="Banner 4 açıklama",
                    BannerLink="/",
                    BannerImage="600-2.jpg",
                    BannerApproval=true,
                    BannerSort=4,
                    HomeDesignTypeId=2
                }
            );
        }
    }
}
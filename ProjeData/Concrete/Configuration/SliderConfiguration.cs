using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(
                new Slider() {
                    SliderId=1,
                    SliderName="Tişört",
                    SliderDescription="Güncel Tişörtler",
                    SliderLink="/",
                    SliderImage="750-1.jpg",
                    SliderTime="2000",
                    SliderApproval=true,
                    SliderSort=1
                },
                new Slider() {
                    SliderId=2,
                    SliderName="Mont",
                    SliderDescription="Moda Montlar",
                    SliderLink="/",
                    SliderImage="750-2.jpg",
                    SliderTime="2000",
                    SliderApproval=true,
                    SliderSort=2
                }
            );
        }
    }
}
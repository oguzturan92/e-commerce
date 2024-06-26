using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class HomeDesignTypeConfiguration : IEntityTypeConfiguration<HomeDesignType>
    {
        public void Configure(EntityTypeBuilder<HomeDesignType> builder)
        {
            builder.HasData(
                new HomeDesignType() {
                    HomeDesignTypeId=1,
                    HomeDesignTypeName="Banner 1",
                    HomeDesignTypeOption="Banner",
                    HomeDesignTypeBannerList="Uclu",
                    HomeDesignTypeProductList="",
                    HomeDesignTypeSort=1,
                    HomeDesignTypeApproval=true
                },
                new HomeDesignType() {
                    HomeDesignTypeId=2,
                    HomeDesignTypeName="Banner 2",
                    HomeDesignTypeOption="Banner",
                    HomeDesignTypeBannerList="Tekli",
                    HomeDesignTypeProductList="",
                    HomeDesignTypeSort=2,
                    HomeDesignTypeApproval=true
                },
                new HomeDesignType() {
                    HomeDesignTypeId=3,
                    HomeDesignTypeName="Haftanın Ürünleri",
                    HomeDesignTypeOption="List",
                    HomeDesignTypeBannerList="",
                    HomeDesignTypeProductList="Standart",
                    HomeDesignTypeSort=3,
                    HomeDesignTypeApproval=true
                },
                new HomeDesignType() {
                    HomeDesignTypeId=4,
                    HomeDesignTypeName="En Çok Satanlar",
                    HomeDesignTypeOption="List",
                    HomeDesignTypeBannerList="",
                    HomeDesignTypeProductList="Kaydirmali",
                    HomeDesignTypeSort=4,
                    HomeDesignTypeApproval=true
                }
            );
        }
    }
}
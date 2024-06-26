using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class ProductHomeDesignTypeConfiguration : IEntityTypeConfiguration<ProductHomeDesignType>
    {
        public void Configure(EntityTypeBuilder<ProductHomeDesignType> builder)
        {
            builder.HasData(
                new ProductHomeDesignType() { HomeDesignTypeId=3, ProductId=1},
                new ProductHomeDesignType() { HomeDesignTypeId=3, ProductId=2},
                new ProductHomeDesignType() { HomeDesignTypeId=3, ProductId=3},
                new ProductHomeDesignType() { HomeDesignTypeId=3, ProductId=4},
                new ProductHomeDesignType() { HomeDesignTypeId=3, ProductId=5},
                new ProductHomeDesignType() { HomeDesignTypeId=4, ProductId=12},
                new ProductHomeDesignType() { HomeDesignTypeId=4, ProductId=11},
                new ProductHomeDesignType() { HomeDesignTypeId=4, ProductId=10},
                new ProductHomeDesignType() { HomeDesignTypeId=4, ProductId=9},
                new ProductHomeDesignType() { HomeDesignTypeId=4, ProductId=8},
                new ProductHomeDesignType() { HomeDesignTypeId=4, ProductId=7},
                new ProductHomeDesignType() { HomeDesignTypeId=4, ProductId=6}
            );
        }
    }
}
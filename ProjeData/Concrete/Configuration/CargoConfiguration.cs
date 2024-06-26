using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasData(
                new Cargo() {
                    CargoId = 1,
                    CargoName = "X Kargo",
                    CargoFreePrice = 3000,
                    CargoPrice = 25,
                    CargoApproval = true,
                    CargoSort = 1
                }
            );
        }
    }
}
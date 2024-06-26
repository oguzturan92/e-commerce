using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasData(
                new BankAccount() {
                    BankAccountId = 1,
                    BankAccountName = "X Bankası",
                    BankAccountIban = "TR11 2222 3333 4444 66",
                    BankAccountSort = 1
                }
            );
        }
    }
}
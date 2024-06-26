using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.HasData(
                new Subscribe() {
                    SubscribeId=1,
                    SubscribeMail="ali_06@gmail.com",
                    SubscribeMailApproval=true,
                    SubscribeContactApproval=true,
                    SubscribeDate= new DateTime(2023,02,27, 17,24,00)
                },
                new Subscribe() {
                    SubscribeId=2,
                    SubscribeMail="ayse_06@gmail.com",
                    SubscribeMailApproval=true,
                    SubscribeContactApproval=false,
                    SubscribeDate= new DateTime(2023,03,01, 11,29,00)
                }
            );
        }
    }
}
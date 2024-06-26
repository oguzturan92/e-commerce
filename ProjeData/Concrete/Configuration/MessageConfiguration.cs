using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasData(
                new Message() {
                    MessageId=1,
                    MessageName="Ahmet",
                    MessageSurname="YILMAZ",
                    MessageMail="ahmetyilmaz@gmail.com",
                    MessagePhone="0312 123 45 67",
                    MessageContent="Merhaba ben Ahmet YILMAZ. Daha önce de iletişim kurduk. Proje hakkında bilgi almak istiyorum.",
                    MessageDate= new DateTime(2023,02,27, 12,28,00)
                },
                new Message() {
                    MessageId=2,
                    MessageName="Ayşe",
                    MessageSurname="AYDIN",
                    MessageMail="ayseaydin@gmail.com",
                    MessagePhone="0312 345 67 89",
                    MessageContent="Merhaba ben Ayşe AYDIN. Göndereceğim mail ile ilgili daha fazla bilgi alabilir miyim.",
                    MessageDate= new DateTime(2023,03,01, 09,07,00)
                }
            );
        }
    }
}
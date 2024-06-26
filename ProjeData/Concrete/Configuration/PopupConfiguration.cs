using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class PopupConfiguration : IEntityTypeConfiguration<Popup>
    {
        public void Configure(EntityTypeBuilder<Popup> builder)
        {
            builder.HasData(
                new Popup() {
                    PopupId = 1,
                    PopupTitle = "Hoşgeldiniz",
                    PopupDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Vero dolore debitis nulla ullam ratione aperiam!",
                    PopupImage = "popup.jpg",
                    PopupLink = "/iletisim",
                    PopupSort = 1,
                    PopupApproval = true
                }
            );
        }   
    }
}
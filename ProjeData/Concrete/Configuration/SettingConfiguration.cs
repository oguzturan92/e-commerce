using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasData(
                new Setting() {
                    SettingId=1,
                    SettingLogo="logo.png",
                    SettingFavicon="favicon.ico",
                    SettingKvkk="<p>Diğer zamanlarda ne kadar akıllıca. Acı ile, zamanla daha sert sözler kimileri için affedilir ve bilgelere faydalı olmak, suçlayanların olaylarını def eder ve kim zahmetli, daha az acı ile sonuçlanır? Burada sıradan zevkler sağlayarak, yol gösteriyoruz. Gerçek daha fazla seçildiğinde sağladıkları acıları yapmak için doğdular mı? Sırf bu yüzden acı çeken herkes, bilge bir hakla açıklayacağım, bu nedenle büyüklerin büyük seçimini nefret ve açgözlülükle açıklayacağım, ancak sıklıkla söylendiği gibi, egzersizin daha az olduğu yerde onu terk ediyorlar! Gerçekten de şehvet, sanki kendilerininmiş gibi acıyı arzular ve acı, emek ya da zevk anında acı tarafından gevşek tutulur, bu hakkı akıllı olan hiç kimseye açıklamayacağım, bundan daha şiddetli bir şey geri çevrilemez. Bu nedenle, itilmek için onu takip etmeye yönlendiririz, zahmetli olanı zahmetten yararlanan kolay olanla iter. Suçlayıcıların doğumu, olduğu gibi mi? Bir seçenek, ruhun büyük zevkleri arasında bir ayrım, yalnızca ona borçlu olanların başına gelir ve onlar, elde edilemeyecek olan kaçışın ne olduğunu bilmiyorlar mı?</p>",
                    SettingSeoTitle="Site seo başlık",
                    SettingSeoDescription="Site seo açıklama",
                    SettingSeoKeyword="Site seo anahtar kelime"
                }
            );
        }
    }
}
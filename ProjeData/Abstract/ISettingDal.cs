using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Setting> kısmındaki Setting adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Setting değerini alıyor.
    public interface ISettingDal : IGenericDal<Setting>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/SETTINGDAL dosyasında metotları dolduruyoruz.
    }
}
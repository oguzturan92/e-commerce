using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<HomeDesignType> kısmındaki HomeDesignType adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık HomeDesignType değerini alıyor.
    public interface IHomeDesignTypeDal : IGenericDal<HomeDesignType>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/HOMEDESIGNTYPEDAL dosyasında metotları dolduruyoruz.
        List<HomeDesignType> HomeDesignTypes();
        List<HomeDesignType> AllHomeDesignTypes();
    }
}
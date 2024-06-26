using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Category3> kısmındaki Category adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Category3 değerini alıyor.
    public interface ICategory3Dal : IGenericDal<Category3>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/CATEGORY2DAL dosyasında metotları dolduruyoruz.
        Category3 SeciliKategori3(string url);
        Category3 CategoryFilters3(string url);
    }
}
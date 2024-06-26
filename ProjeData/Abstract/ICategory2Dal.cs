using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Category2> kısmındaki Category adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Category2 değerini alıyor.
    public interface ICategory2Dal : IGenericDal<Category2>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/CATEGORY2DAL dosyasında metotları dolduruyoruz.
        Category2 SeciliKategori2(string url);
        Category2 CategoryFilters2(string url);
    }
}
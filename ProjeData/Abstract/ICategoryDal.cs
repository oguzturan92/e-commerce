using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Category> kısmındaki Category adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Category değerini alıyor.
    public interface ICategoryDal : IGenericDal<Category>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/CATEGORYDAL dosyasında metotları dolduruyoruz.
        Category SeciliKategori(string url);
        List<Category> CategoryMenu();
        List<Category> CategoryIcerikMenu();
        List<Category> AllCategory();
        Category CategoryFilters(string url);
    }
}
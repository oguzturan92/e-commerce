using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<List> kısmındaki List adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık List değerini alıyor.
    public interface IListDal : IGenericDal<List>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/LISTDAL dosyasında metotları dolduruyoruz.
        List ListIdyeGoreProducts(int id);
        void ListeProductCreate(int listId, List<ProductList> productLists);
        void ListtenProductDelete(int listId, int productId);
        List<List> ProductDetailListAndProducts(int id);
    }
}
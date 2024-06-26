using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<OrderIade> kısmındaki OrderIade adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık OrderIade değerini alıyor.
    public interface IOrderIadeDal : IGenericDal<OrderIade>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/ORDERIADEDAL dosyasında metotları dolduruyoruz.
        OrderIade OrderIadeAndOrder(int orderIadeId);
        List<OrderIade> UserAndOrderIades(int userId);
    }
}
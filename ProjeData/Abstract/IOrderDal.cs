using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Order> kısmındaki Order adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Order değerini alıyor.
    public interface IOrderDal : IGenericDal<Order>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/ORDERDAL dosyasında metotları dolduruyoruz.
        Order OrderAndLine(int orderId);
        List<Order> OrdersAndLines(int userId);
        Order OrderDetail(int orderId);
        Order OrderAndLineIade(int orderId, int userId);
        List<Order> OrdersAndIadeLines(int userId);

    }
}
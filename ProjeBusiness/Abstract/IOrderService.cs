using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // ORDER tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/ORDERMANAGER içinde dolduracağız.
    public interface IOrderService
    {
        Order GetById(int id);
        List<Order> GetAll();
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        Order OrderAndLine(int orderId);
        List<Order> OrdersAndLines(int userId);
        Order OrderDetail(int orderId);
        Order OrderAndLineIade(int orderId, int userId);
        List<Order> OrdersAndIadeLines(int userId);

    }
}
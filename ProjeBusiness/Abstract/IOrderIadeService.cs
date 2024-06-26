using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // ORDERIADE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/ORDERIADEMANAGER içinde dolduracağız.
    public interface IOrderIadeService
    {
        OrderIade GetById(int id);
        List<OrderIade> GetAll();
        void Create(OrderIade entity);
        void Update(OrderIade entity);
        void Delete(OrderIade entity);
        OrderIade OrderIadeAndOrder(int orderIadeId);
        List<OrderIade> UserAndOrderIades(int userId);
    }
}
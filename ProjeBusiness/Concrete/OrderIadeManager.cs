using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IORDERIADESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class OrderIadeManager : IOrderIadeService
    {
        private IOrderIadeDal _orderIadeDal;
        public OrderIadeManager(IOrderIadeDal orderIadeDal)
        {
            _orderIadeDal = orderIadeDal;
        }

        // METOTLAR
        public void Create(OrderIade entity)
        {
            _orderIadeDal.Create(entity);
        }

        public void Delete(OrderIade entity)
        {
            _orderIadeDal.Delete(entity);
        }

        public List<OrderIade> GetAll()
        {
            return _orderIadeDal.GetAll().ToList();
        }

        public OrderIade GetById(int id)
        {
            return _orderIadeDal.GetById(id);
        }

        public void Update(OrderIade entity)
        {
            _orderIadeDal.Update(entity);
        }

        public OrderIade OrderIadeAndOrder(int orderIadeId)
        {
            return _orderIadeDal.OrderIadeAndOrder(orderIadeId);
        }

        public List<OrderIade> UserAndOrderIades(int userId)
        {
            return _orderIadeDal.UserAndOrderIades(userId);
        }
    }
}
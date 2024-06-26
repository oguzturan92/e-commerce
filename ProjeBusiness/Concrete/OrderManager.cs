using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IORDERSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        // METOTLAR
        public void Create(Order entity)
        {
            _orderDal.Create(entity);
        }

        public void Delete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll().ToList();
        }

        public Order GetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public void Update(Order entity)
        {
            _orderDal.Update(entity);
        }

        public Order OrderAndLine(int orderId)
        {
            return _orderDal.OrderAndLine(orderId);
        }

        public List<Order> OrdersAndLines(int userId)
        {
            return _orderDal.OrdersAndLines(userId);
        }

        public Order OrderDetail(int orderId)
        {
            return _orderDal.OrderDetail(orderId);
        }

        public Order OrderAndLineIade(int orderId, int userId)
        {
            return _orderDal.OrderAndLineIade(orderId, userId);
        }

        public List<Order> OrdersAndIadeLines(int userId)
        {
            return _orderDal.OrdersAndIadeLines(userId);
        }

    }
}
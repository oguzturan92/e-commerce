using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IORDERDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class OrderDal : GenericDal<Order>, IOrderDal
    {
        public Order OrderAndLine(int orderId)
        {
            using (var context = new ProjeContext())
            {
                return context.Orders
                                .Where(i => i.OrderId == orderId)
                                .Include(i => i.OrderLines)
                                .FirstOrDefault();
            }
        }

        public List<Order> OrdersAndLines(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Orders
                                .Where(i => i.ProjeUserId == userId).OrderByDescending(i => i.OrderDateTime)
                                .Include(i => i.OrderLines)
                                .Include(i => i.OrderAndAdresJuncs)
                                .ThenInclude(i => i.OrderAdres)
                                .ToList();
            }
        }

        public Order OrderDetail(int orderId)
        {
            using (var context = new ProjeContext())
            {
                return context.Orders
                                .Where(i => i.OrderId == orderId)
                                .Include(i => i.OrderLines)
                                .Include(i => i.OrderAndAdresJuncs)
                                .ThenInclude(i => i.OrderAdres)
                                .FirstOrDefault();
            }
        }

        public Order OrderAndLineIade(int orderId, int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Orders
                                .Where(i => i.OrderId == orderId && i.ProjeUserId == userId)
                                .Include(i => i.OrderLines
                                    .Where(i => i.IadeEdilebilirAdet > 0)
                                )
                                .FirstOrDefault();
            }
        }
    
        public List<Order> OrdersAndIadeLines(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Orders
                                .Where(i => i.ProjeUserId == userId && i.OrderIades.Any(i => i.OrderId == i.OrderId)).OrderByDescending(i => i.OrderDateTime)
                                .Include(i => i.OrderIades)
                                // .ThenInclude(i => i.Product)
                                // .Include(i => i.OrderAdress)
                                // .ThenInclude(i => i.Adres)
                                .ToList();
            }
        }

    }
}
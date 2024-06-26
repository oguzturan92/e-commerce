using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IORDERIADEDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class OrderIadeDal : GenericDal<OrderIade>, IOrderIadeDal
    {
        public OrderIade OrderIadeAndOrder(int orderIadeId)
        {
            using (var context = new ProjeContext())
            {
                return context.OrderIades
                                .Where(i => i.OrderIadeId == orderIadeId)
                                .Include(i => i.Order)
                                // .ThenInclude(i => i.Product)
                                // .Include(i => i.OrderAdress)
                                // .ThenInclude(i => i.Adres)
                                .FirstOrDefault();
            }
        }

        public List<OrderIade> UserAndOrderIades(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.OrderIades
                                .Where(i => i.Order.ProjeUserId == userId)
                                .OrderBy(i => i.OrderIadeDate)
                                .ToList();
            }
        }
    }
}
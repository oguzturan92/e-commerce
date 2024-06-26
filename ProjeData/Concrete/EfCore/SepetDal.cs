using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/ISEPETDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class SepetDal : GenericDal<Sepet>, ISepetDal
    {
        public Sepet SepetAndProducts(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Sepets
                                .Where(i => i.ProjeUserId == userId)
                                .Include(i => i.SepetLines)
                                .ThenInclude(i => i.Product)
                                .ThenInclude(i => i.ProductSizes)
                                .ThenInclude(i => i.Size)

                                .FirstOrDefault();
            }
        }

        public Sepet Sepet(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Sepets
                                .Where(i => i.ProjeUserId == userId)
                                .FirstOrDefault();
            }
        }
    
        public Sepet SepetAndProductsIncomplete(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.Sepets
                                .Where(i => i.SepetId == id)
                                .Include(i => i.SepetLines)
                                .ThenInclude(i => i.Product)
                                .ThenInclude(i => i.ProductSizes)
                                .ThenInclude(i => i.Size)

                                .FirstOrDefault();
            }
        }

        public List<Sepet> SepetsAndUserIncomplete()
        {
            using (var context = new ProjeContext())
            {
                return context.Sepets
                                .Include(i => i.ProjeUser)
                                .ToList();
            }
        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/ILISTDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class ListDal : GenericDal<List>, IListDal
    {
        public List ListIdyeGoreProducts(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.Lists
                                .Where(i => i.ListId == id)
                                .Include(i => i.ProductLists
                                    .OrderBy(i => i.Product.ProductSort)
                                )
                                .ThenInclude(i => i.Product)
                                .FirstOrDefault();
            }
        }

        public void ListeProductCreate(int listId, List<ProductList> productLists) // Ortak tabloya List tablosu üzerinden eleman ekler.
        {
            using (var context = new ProjeContext())
            {
                var list = context.Lists
                                    .Where(i => i.ListId == listId)
                                    .FirstOrDefault();
                                    
                if (list != null)
                {
                    list.ProductLists = productLists;
                    
                    context.Lists.Update(list);

                    context.SaveChanges();
                }
            }
        }

        public void ListtenProductDelete(int listId, int productId)
        {
            using (var context = new ProjeContext())
            {
                var list = context.Lists
                                .Where(i => i.ListId == listId)
                                .Include(i => i.ProductLists.Where(i => i.ListId == listId && i.ProductId == productId))
                                .FirstOrDefault();
                                
                if (list != null)
                {
                    context.Remove<ProductList>(list.ProductLists[0]);

                    context.SaveChanges();
                }
            }
        }

        public List<List> ProductDetailListAndProducts(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.Lists
                                .Where(i => i.ProductId == id || i.ListLocation == "Genel" && i.ListApproval)
                                .OrderBy(i => i.ListSort)
                                .Include(i => i.ProductLists
                                    .OrderBy(i => i.Product.ProductSort)
                                    .Where(i => i.Product.ProductApproval)
                                )
                                .ThenInclude(i => i.Product)
                                .ThenInclude(i => i.ProductImages
                                    .Take(2)
                                )
                                .ToList();
            }
        }
    }
}
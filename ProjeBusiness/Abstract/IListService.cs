using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // LIST tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/LISTMANAGER içinde dolduracağız.
    public interface IListService
    {
        List GetById(int id);
        List<List> GetAll();
        void Create(List entity);
        void Update(List entity);
        void Delete(List entity);
        List ListIdyeGoreProducts(int id);
        void ListeProductCreate(int listId, List<ProductList> productLists);
        void ListtenProductDelete(int listId, int productId);
        List<List> ProductDetailListAndProducts(int id);
    }
}
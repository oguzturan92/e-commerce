using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ILISTSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class ListManager : IListService
    {
        private IListDal _listDal;
        public ListManager(IListDal listDal)
        {
            _listDal = listDal;
        }

        // METOTLAR
        public void Create(List entity)
        {
            _listDal.Create(entity);
        }

        public void Delete(List entity)
        {
            _listDal.Delete(entity);
        }

        public List<List> GetAll()
        {
            return _listDal.GetAll().ToList();
        }

        public List GetById(int id)
        {
            return _listDal.GetById(id);
        }

        public void Update(List entity)
        {
            _listDal.Update(entity);
        }

        public List ListIdyeGoreProducts(int id)
        {
            return _listDal.ListIdyeGoreProducts(id);
        }

        public void ListeProductCreate(int listId, List<ProductList> productLists)
        {
            _listDal.ListeProductCreate(listId, productLists);
        }

        public void ListtenProductDelete(int listId, int productId)
        {
            _listDal.ListtenProductDelete(listId, productId);
        }

        public List<List> ProductDetailListAndProducts(int id)
        {
            return _listDal.ProductDetailListAndProducts(id);
        }
    }
}
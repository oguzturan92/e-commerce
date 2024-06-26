using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeData.Concrete;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ICATEGORY2SERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class Category2Manager : ICategory2Service
    {
        // DATA/Abstract/ICategory2Dal dosyasını _category2Dal nesnesi olarak tanımladık. DATA/Abstract ise, DATA/Concrete içindeki dolu metotları alıcak. Bu dosyada _category2Dal çağırdığımızda, DATA/Abstract/ICategory2Dal içindeki metotlar işleyecek. Yani ICategory2Dal da metotları IGenericDal'dan alıyor.
        private ICategory2Dal _category2Dal;
        public Category2Manager(ICategory2Dal category2Dal)
        {
            _category2Dal = category2Dal;
        }

        // METOTLAR
        public void Create(Category2 entity)
        {
            _category2Dal.Create(entity);
        }

        public void Delete(Category2 entity)
        {
            _category2Dal.Delete(entity);
        }

        public List<Category2> GetAll()
        {
            return _category2Dal.GetAll();
        }

        public Category2 GetById(int id)
        {
            return _category2Dal.GetById(id);
        }

        public void Update(Category2 entity)
        {
            _category2Dal.Update(entity);
        }

        public Category2 SeciliKategori2(string url)
        {
            return _category2Dal.SeciliKategori2(url);
        }

        public Category2 CategoryFilters2(string url)
        {
            return _category2Dal.CategoryFilters2(url);
        }
    }
}
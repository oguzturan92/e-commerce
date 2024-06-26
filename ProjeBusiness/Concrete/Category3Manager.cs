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
    // ABSTRACT/ICATEGORY3SERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class Category3Manager : ICategory3Service
    {
        // DATA/Abstract/ICategory3Dal dosyasını _category3Dal nesnesi olarak tanımladık. DATA/Abstract ise, DATA/Concrete içindeki dolu metotları alıcak. Bu dosyada _category3Dal çağırdığımızda, DATA/Abstract/ICategory3Dal içindeki metotlar işleyecek. Yani ICategory3Dal da metotları IGenericDal'dan alıyor.
        private ICategory3Dal _category3Dal;
        public Category3Manager(ICategory3Dal category3Dal)
        {
            _category3Dal = category3Dal;
        }

        // METOTLAR
        public void Create(Category3 entity)
        {
            _category3Dal.Create(entity);
        }

        public void Delete(Category3 entity)
        {
            _category3Dal.Delete(entity);
        }

        public List<Category3> GetAll()
        {
            return _category3Dal.GetAll();
        }

        public Category3 GetById(int id)
        {
            return _category3Dal.GetById(id);
        }

        public void Update(Category3 entity)
        {
            _category3Dal.Update(entity);
        }

        public Category3 SeciliKategori3(string url)
        {
            return _category3Dal.SeciliKategori3(url);
        }

        public Category3 CategoryFilters3(string url)
        {
            return _category3Dal.CategoryFilters3(url);
        }
    }
}
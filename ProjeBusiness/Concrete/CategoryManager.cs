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
    // ABSTRACT/ICATEGORYSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class CategoryManager : ICategoryService
    {
        // DATA/Abstract/ICategoryDal dosyasını _categoryDal nesnesi olarak tanımladık. DATA/Abstract ise, DATA/Concrete içindeki dolu metotları alıcak. Bu dosyada _categoryDal çağırdığımızda, DATA/Abstract/ICategoryDal içindeki metotlar işleyecek. Yani ICategoryDal da metotları IGenericDal'dan alıyor.
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // METOTLAR
        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public Category SeciliKategori(string url)
        {
            return _categoryDal.SeciliKategori(url);
        }

        public List<Category> CategoryMenu()
        {
            return _categoryDal.CategoryMenu();
        }

        public List<Category> CategoryIcerikMenu()
        {
            return _categoryDal.CategoryIcerikMenu();
        }

        public List<Category> AllCategory()
        {
            return _categoryDal.AllCategory();
        }

        public Category CategoryFilters(string url)
        {
            return _categoryDal.CategoryFilters(url);
        }
    }
}
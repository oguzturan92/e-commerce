using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // CATEGORY2 tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/CATEGORY2MANAGER içinde dolduracağız.
    public interface ICategory2Service
    {
        Category2 GetById(int id);
        List<Category2> GetAll();
        void Create(Category2 entity);
        void Update(Category2 entity);
        void Delete(Category2 entity);
        Category2 SeciliKategori2(string url);
        Category2 CategoryFilters2(string url);
    }
}
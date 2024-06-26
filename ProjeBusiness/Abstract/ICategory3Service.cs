using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // CATEGORY3 tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/CATEGORY3MANAGER içinde dolduracağız.
    public interface ICategory3Service
    {
        Category3 GetById(int id);
        List<Category3> GetAll();
        void Create(Category3 entity);
        void Update(Category3 entity);
        void Delete(Category3 entity);
        Category3 SeciliKategori3(string url);
        Category3 CategoryFilters3(string url);
    }
}
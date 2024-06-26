using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // CATEGORY tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/CATEGORYMANAGER içinde dolduracağız.
    public interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category SeciliKategori(string url);
        List<Category> CategoryMenu();
        List<Category> CategoryIcerikMenu();
        List<Category> AllCategory();
        Category CategoryFilters(string url);
    }
}
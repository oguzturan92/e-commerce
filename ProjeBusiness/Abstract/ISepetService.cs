using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // SEPET tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/SEPETMANAGER içinde dolduracağız.
    public interface ISepetService
    {
        Sepet GetById(int id);
        List<Sepet> GetAll();
        void Create(Sepet entity);
        void Update(Sepet entity);
        void Delete(Sepet entity);
        Sepet SepetAndProducts(int userId);
        Sepet Sepet(int userId);
        Sepet SepetAndProductsIncomplete(int id);
        List<Sepet> SepetsAndUserIncomplete();
        
    }
}
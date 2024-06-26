using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // ADRES tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/ADRESMANAGER içinde dolduracağız.
    public interface IAdresService
    {
        Adres GetById(int id);
        List<Adres> GetAll();
        void Create(Adres entity);
        void Update(Adres entity);
        void Delete(Adres entity);
    }
}
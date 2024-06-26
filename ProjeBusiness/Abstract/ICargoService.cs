using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // CARGO tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/CARGOMANAGER içinde dolduracağız.
    public interface ICargoService
    {
        Cargo GetById(int id);
        List<Cargo> GetAll();
        void Create(Cargo entity);
        void Update(Cargo entity);
        void Delete(Cargo entity);
    }
}
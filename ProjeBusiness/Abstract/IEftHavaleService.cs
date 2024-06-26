using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // EFTHAVALE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/EFTHAVALEMANAGER içinde dolduracağız.
    public interface IEftHavaleService
    {
        EftHavale GetById(int id);
        List<EftHavale> GetAll();
        void Create(EftHavale entity);
        void Update(EftHavale entity);
        void Delete(EftHavale entity);
    }
}
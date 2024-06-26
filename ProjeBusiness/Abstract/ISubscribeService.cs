using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // MAILABONE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/MAILABONEMANAGER içinde dolduracağız.
    public interface ISubscribeService
    {
        Subscribe GetById(int id);
        List<Subscribe> GetAll();
        void Create(Subscribe entity);
        void Update(Subscribe entity);
        void Delete(Subscribe entity);
    }
}
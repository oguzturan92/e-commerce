using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // DESCRIPTION tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/DESCRIPTIONMANAGER içinde dolduracağız.
    public interface IDescriptionService
    {
        Description GetById(int id);
        List<Description> GetAll();
        void Create(Description entity);
        void Update(Description entity);
        void Delete(Description entity);
    }
}
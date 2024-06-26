using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // SUPPORT tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/SUPPORTMANAGER içinde dolduracağız.
    public interface ISupportService
    {
        Support GetById(int id);
        List<Support> GetAll();
        void Create(Support entity);
        void Update(Support entity);
        void Delete(Support entity);
        List<Support> SupportsAndLines(int userId);
        List<Support> SupportsAndUsers();
        Support SupportAndLines(int id);
    }
}
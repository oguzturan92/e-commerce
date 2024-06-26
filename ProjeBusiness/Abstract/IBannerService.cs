using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // BANNER tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/BANNERMANAGER içinde dolduracağız.
    public interface IBannerService
    {
        Banner GetById(int id);
        List<Banner> GetAll();
        void Create(Banner entity);
        void Update(Banner entity);
        void Delete(Banner entity);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // FOOTER tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/FOOTERMANAGER içinde dolduracağız.
    public interface IFooterService
    {
        Footer GetById(int id);
        List<Footer> GetAll();
        void Create(Footer entity);
        void Update(Footer entity);
        void Delete(Footer entity);
        List<Footer> FooterAndAltList();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // FOOTERALT tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/FOOTERALTMANAGER içinde dolduracağız.
    public interface IFooterAltService
    {
        FooterAlt GetById(int id);
        List<FooterAlt> GetAll();
        void Create(FooterAlt entity);
        void Update(FooterAlt entity);
        void Delete(FooterAlt entity);
        FooterAlt FooterAltDetail(string url);
    }
}
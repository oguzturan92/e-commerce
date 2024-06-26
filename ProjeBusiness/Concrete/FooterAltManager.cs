using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IFOOTERALTSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class FooterAltManager : IFooterAltService
    {
        private IFooterAltDal _footerAltDal;
        public FooterAltManager(IFooterAltDal footerAltDal)
        {
            _footerAltDal = footerAltDal;
        }

        // METOTLAR
        public void Create(FooterAlt entity)
        {
            _footerAltDal.Create(entity);
        }

        public void Delete(FooterAlt entity)
        {
            _footerAltDal.Delete(entity);
        }

        public List<FooterAlt> GetAll()
        {
            return _footerAltDal.GetAll().ToList();
        }

        public FooterAlt GetById(int id)
        {
            return _footerAltDal.GetById(id);
        }

        public void Update(FooterAlt entity)
        {
            _footerAltDal.Update(entity);
        }

        public FooterAlt FooterAltDetail(string url)
        {
            return _footerAltDal.FooterAltDetail(url);
        }
    }
}
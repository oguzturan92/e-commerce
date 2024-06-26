using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IFOOTERSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class FooterManager : IFooterService
    {
        private IFooterDal _footerDal;
        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

        // METOTLAR
        public void Create(Footer entity)
        {
            _footerDal.Create(entity);
        }

        public void Delete(Footer entity)
        {
            _footerDal.Delete(entity);
        }

        public List<Footer> GetAll()
        {
            return _footerDal.GetAll().ToList();
        }

        public Footer GetById(int id)
        {
            return _footerDal.GetById(id);
        }

        public void Update(Footer entity)
        {
            _footerDal.Update(entity);
        }

        public List<Footer> FooterAndAltList()
        {
            return _footerDal.FooterAndAltList();
        }
    }
}
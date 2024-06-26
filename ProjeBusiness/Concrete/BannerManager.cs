using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IBANNERSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class BannerManager : IBannerService
    {
        private IBannerDal _bannerDal;
        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        // METOTLAR
        public void Create(Banner entity)
        {
            _bannerDal.Create(entity);
        }

        public void Delete(Banner entity)
        {
            _bannerDal.Delete(entity);
        }

        public List<Banner> GetAll()
        {
            return _bannerDal.GetAll().ToList();
        }

        public Banner GetById(int id)
        {
            return _bannerDal.GetById(id);
        }

        public void Update(Banner entity)
        {
            _bannerDal.Update(entity);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ISEPETSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SepetManager : ISepetService
    {
        private ISepetDal _sepetDal;
        public SepetManager(ISepetDal sepetDal)
        {
            _sepetDal = sepetDal;
        }

        // METOTLAR
        public void Create(Sepet entity)
        {
            _sepetDal.Create(entity);
        }

        public void Delete(Sepet entity)
        {
            _sepetDal.Delete(entity);
        }

        public List<Sepet> GetAll()
        {
            return _sepetDal.GetAll().ToList();
        }

        public Sepet GetById(int id)
        {
            return _sepetDal.GetById(id);
        }

        public void Update(Sepet entity)
        {
            _sepetDal.Update(entity);
        }

        public Sepet SepetAndProducts(int userId)
        {
            return _sepetDal.SepetAndProducts(userId);
        }

        public Sepet Sepet(int userId)
        {
            return _sepetDal.Sepet(userId);
        }

        public Sepet SepetAndProductsIncomplete(int id)
        {
            return _sepetDal.SepetAndProductsIncomplete(id);
        }
        
        public List<Sepet> SepetsAndUserIncomplete()
        {
            return _sepetDal.SepetsAndUserIncomplete();
        }
    }
}
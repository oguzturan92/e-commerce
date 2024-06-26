using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IADRESSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class AdresManager : IAdresService
    {
        private IAdresDal _adresDal;
        public AdresManager(IAdresDal adresDal)
        {
            _adresDal = adresDal;
        }

        // METOTLAR
        public void Create(Adres entity)
        {
            _adresDal.Create(entity);
        }

        public void Delete(Adres entity)
        {
            _adresDal.Delete(entity);
        }

        public List<Adres> GetAll()
        {
            return _adresDal.GetAll().ToList();
        }

        public Adres GetById(int id)
        {
            return _adresDal.GetById(id);
        }

        public void Update(Adres entity)
        {
            _adresDal.Update(entity);
        }
    }
}
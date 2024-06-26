using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IEFTHAVALESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class EftHavaleManager : IEftHavaleService
    {
        private IEftHavaleDal _eftHavaleDal;
        public EftHavaleManager(IEftHavaleDal eftHavaleDal)
        {
            _eftHavaleDal = eftHavaleDal;
        }

        // METOTLAR
        public void Create(EftHavale entity)
        {
            _eftHavaleDal.Create(entity);
        }

        public void Delete(EftHavale entity)
        {
            _eftHavaleDal.Delete(entity);
        }

        public List<EftHavale> GetAll()
        {
            return _eftHavaleDal.GetAll().ToList();
        }

        public EftHavale GetById(int id)
        {
            return _eftHavaleDal.GetById(id);
        }

        public void Update(EftHavale entity)
        {
            _eftHavaleDal.Update(entity);
        }
    }
}
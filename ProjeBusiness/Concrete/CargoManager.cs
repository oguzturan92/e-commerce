using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ICARGOSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class CargoManager : ICargoService
    {
        private ICargoDal _cargoDal;
        public CargoManager(ICargoDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        // METOTLAR
        public void Create(Cargo entity)
        {
            _cargoDal.Create(entity);
        }

        public void Delete(Cargo entity)
        {
            _cargoDal.Delete(entity);
        }

        public List<Cargo> GetAll()
        {
            return _cargoDal.GetAll().ToList();
        }

        public Cargo GetById(int id)
        {
            return _cargoDal.GetById(id);
        }

        public void Update(Cargo entity)
        {
            _cargoDal.Update(entity);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IVARIANTSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class VariantManager : IVariantService
    {
        private IVariantDal _variantDal;
        public VariantManager(IVariantDal variantDal)
        {
            _variantDal = variantDal;
        }

        // METOTLAR
        public void Create(Variant entity)
        {
            _variantDal.Create(entity);
        }

        public void Delete(Variant entity)
        {
            _variantDal.Delete(entity);
        }

        public List<Variant> GetAll()
        {
            return _variantDal.GetAll().ToList();
        }

        public Variant GetById(int id)
        {
            return _variantDal.GetById(id);
        }

        public void Update(Variant entity)
        {
            _variantDal.Update(entity);
        }
    }
}
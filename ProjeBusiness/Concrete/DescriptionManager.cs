using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IDESCRIPTIONSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class DescriptionManager : IDescriptionService
    {
        private IDescriptionDal _descriptionDal;
        public DescriptionManager(IDescriptionDal descriptionDal)
        {
            _descriptionDal = descriptionDal;
        }

        // METOTLAR
        public void Create(Description entity)
        {
            _descriptionDal.Create(entity);
        }

        public void Delete(Description entity)
        {
            _descriptionDal.Delete(entity);
        }

        public List<Description> GetAll()
        {
            return _descriptionDal.GetAll().ToList();
        }

        public Description GetById(int id)
        {
            return _descriptionDal.GetById(id);
        }

        public void Update(Description entity)
        {
            _descriptionDal.Update(entity);
        }
    }
}
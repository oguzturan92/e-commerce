using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ISIZETYPESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SizeManager : ISizeService
    {
        private ISizeDal _sizeDal;
        public SizeManager(ISizeDal sizeDal)
        {
            _sizeDal = sizeDal;
        }

        // METOTLAR
        public void Create(Size entity)
        {
            _sizeDal.Create(entity);
        }

        public void Delete(Size entity)
        {
            _sizeDal.Delete(entity);
        }

        public List<Size> GetAll()
        {
            return _sizeDal.GetAll().ToList();
        }

        public Size GetById(int id)
        {
            return _sizeDal.GetById(id);
        }

        public void Update(Size entity)
        {
            _sizeDal.Update(entity);
        }
    }
}
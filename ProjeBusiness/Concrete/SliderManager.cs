using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ISLIDERSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SliderManager : ISliderService
    {
        private ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        // METOTLAR
        public void Create(Slider entity)
        {
            _sliderDal.Create(entity);
        }

        public void Delete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetAll().ToList();
        }

        public Slider GetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public void Update(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
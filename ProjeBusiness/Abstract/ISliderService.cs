using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // SLIDER tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/SLIDERMANAGER içinde dolduracağız.
    public interface ISliderService
    {
        Slider GetById(int id);
        List<Slider> GetAll();
        void Create(Slider entity);
        void Update(Slider entity);
        void Delete(Slider entity);
    }
}
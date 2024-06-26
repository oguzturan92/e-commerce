using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // POPUP tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/POPUPMANAGER içinde dolduracağız.
    public interface IPopupService
    {
        Popup GetById(int id);
        List<Popup> GetAll();
        void Create(Popup entity);
        void Update(Popup entity);
        void Delete(Popup entity);
    }
}
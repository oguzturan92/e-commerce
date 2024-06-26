using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IPOPUPSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class PopupManager : IPopupService
    {
        // DATA/Abstract/IPopupDal dosyasını _popupDal nesnesi olarak tanımladık. DATA/Abstract ise, DATA/Concrete içindeki dolu metotları alıcak. Bu dosyada _popupDal çağırdığımızda, DATA/Abstract/IPopupDal içindeki metotlar işleyecek. Yani IPopupDal da metotları IGenericDal'dan alıyor.
        private IPopupDal _popupDal;
        public PopupManager(IPopupDal popupDal)
        {
            _popupDal = popupDal;
        }

        // METOTLAR
        public void Create(Popup entity)
        {
            _popupDal.Create(entity);
        }

        public void Delete(Popup entity)
        {
            _popupDal.Delete(entity);
        }

        public List<Popup> GetAll()
        {
            return _popupDal.GetAll().ToList();
        }

        public Popup GetById(int id)
        {
            return _popupDal.GetById(id);
        }

        public void Update(Popup entity)
        {
            _popupDal.Update(entity);
        }
    }
}
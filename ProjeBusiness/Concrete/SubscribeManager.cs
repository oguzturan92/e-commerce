using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IMAILABONESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SubscribeManager : ISubscribeService
    {
        // DATA/Abstract/IMailAboneDal dosyasını _mailAboneDal nesnesi olarak tanımladık. DATA/Abstract ise, DATA/Concrete içindeki dolu metotları alıcak. Bu dosyada _mailAboneDal çağırdığımızda, DATA/Abstract/IMailAboneDal içindeki metotlar işleyecek. Yani IMailAboneDal da metotları IGenericDal'dan alıyor.
        private ISubscribeDal _subscribeDal;
        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        // METOTLAR
        public void Create(Subscribe entity)
        {
            _subscribeDal.Create(entity);
        }

        public void Delete(Subscribe entity)
        {
            _subscribeDal.Delete(entity);
        }

        public List<Subscribe> GetAll()
        {
            return _subscribeDal.GetAll().ToList();
        }

        public Subscribe GetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public void Update(Subscribe entity)
        {
            _subscribeDal.Update(entity);
        }
    }
}
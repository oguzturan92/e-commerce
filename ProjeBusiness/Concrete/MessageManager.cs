using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IMESAJSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class MessageManager : IMessageService
    {
        // DATA/Abstract/IMesajDal dosyasını _mesajDal nesnesi olarak tanımladık. DATA/Abstract ise, DATA/Concrete içindeki dolu metotları alıcak. Bu dosyada _mesajDal çağırdığımızda, DATA/Abstract/IMesajDal içindeki metotlar işleyecek. Yani IMesajDal da metotları IGenericDal'dan alıyor.
        private IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        // METOTLAR
        public void Create(Message entity)
        {
            _messageDal.Create(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll().ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
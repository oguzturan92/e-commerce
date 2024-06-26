using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // MESAJ tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/MESAJMANAGER içinde dolduracağız.
    public interface IMessageService
    {
        Message GetById(int id);
        List<Message> GetAll();
        void Create(Message entity);
        void Update(Message entity);
        void Delete(Message entity);
    }
}
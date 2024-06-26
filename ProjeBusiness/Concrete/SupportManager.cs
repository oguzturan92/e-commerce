using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ISUPPORTSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SupportManager : ISupportService
    {
        private ISupportDal _supportDal;
        public SupportManager(ISupportDal supportDal)
        {
            _supportDal = supportDal;
        }

        // METOTLAR
        public void Create(Support entity)
        {
            _supportDal.Create(entity);
        }

        public void Delete(Support entity)
        {
            _supportDal.Delete(entity);
        }

        public List<Support> GetAll()
        {
            return _supportDal.GetAll().ToList();
        }

        public Support GetById(int id)
        {
            return _supportDal.GetById(id);
        }

        public void Update(Support entity)
        {
            _supportDal.Update(entity);
        }

        public List<Support> SupportsAndLines(int userId)
        {
            return _supportDal.SupportsAndLines(userId);
        }

        public List<Support> SupportsAndUsers()
        {
            return _supportDal.SupportsAndUsers();
        }

        public Support SupportAndLines(int id)
        {
            return _supportDal.SupportAndLines(id);
        }
    }
}
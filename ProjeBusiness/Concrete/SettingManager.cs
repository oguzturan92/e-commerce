using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ISETTINGSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SettingManager : ISettingService
    {
        private ISettingDal _settingDal;
        public SettingManager(ISettingDal settingDal)
        {
            _settingDal = settingDal;
        }

        // METOTLAR
        public void Create(Setting entity)
        {
            _settingDal.Create(entity);
        }

        public void Delete(Setting entity)
        {
            _settingDal.Delete(entity);
        }

        public List<Setting> GetAll()
        {
            return _settingDal.GetAll().ToList();
        }

        public Setting GetById(int id)
        {
            return _settingDal.GetById(id);
        }

        public void Update(Setting entity)
        {
            _settingDal.Update(entity);
        }
    }
}
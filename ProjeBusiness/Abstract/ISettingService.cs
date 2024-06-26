using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // SETTING tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/SETTINGMANAGER içinde dolduracağız.
    public interface ISettingService
    {
        Setting GetById(int id);
        List<Setting> GetAll();
        void Create(Setting entity);
        void Update(Setting entity);
        void Delete(Setting entity);
    }
}
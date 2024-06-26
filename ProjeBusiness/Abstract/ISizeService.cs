using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // SIZE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/SIZEMANAGER içinde dolduracağız.
    public interface ISizeService
    {
        Size GetById(int id);
        List<Size> GetAll();
        void Create(Size entity);
        void Update(Size entity);
        void Delete(Size entity);
    }
}
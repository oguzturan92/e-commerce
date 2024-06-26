using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // SIZETYPE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/SIZETYPEMANAGER içinde dolduracağız.
    public interface ISizeTypeService
    {
        SizeType GetById(int id);
        List<SizeType> GetAll();
        void Create(SizeType entity);
        void Update(SizeType entity);
        void Delete(SizeType entity);
        List<SizeType> SizeTypeAndSize();
        SizeType ProductDetailSize(int id);
        List<SizeType> SizeTypeAndSizeFilters(string url);
        List<SizeType> SizeTypeAndSizeFilters2(string url);
        List<SizeType> SizeTypeAndSizeFilters3(string url);
    }
}
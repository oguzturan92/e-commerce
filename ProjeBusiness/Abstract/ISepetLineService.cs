using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // SEPETLINE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/SEPETLINEMANAGER içinde dolduracağız.
    public interface ISepetLineService
    {
        SepetLine GetById(int id);
        List<SepetLine> GetAll();
        void Create(SepetLine entity);
        void Update(SepetLine entity);
        void Delete(SepetLine entity);
        SepetLine SepetLineAndProduct(int id);
        SepetLine SepetLineAndProductAndSize(int proId, int proSizeId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // VARIANT tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/VARIANTMANAGER içinde dolduracağız.
    public interface IVariantService
    {
        Variant GetById(int id);
        List<Variant> GetAll();
        void Create(Variant entity);
        void Update(Variant entity);
        void Delete(Variant entity);
    }
}
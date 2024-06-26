using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // PRODUCTIMAGE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/PRODUCTIMAGEMANAGER içinde dolduracağız.
    public interface IProductImageService
    {
        ProductImage GetById(int id);
        List<ProductImage> GetAll();
        void Create(ProductImage entity);
        void Update(ProductImage entity);
        void Delete(ProductImage entity);
    }
}
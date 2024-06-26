using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // PRODUCTSIZE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/PRODUCTSIZEMANAGER içinde dolduracağız.
    public interface IProductSizeService
    {
        ProductSize GetById(int id);
        List<ProductSize> GetAll();
        void Create(ProductSize entity);
        void Update(ProductSize entity);
        void Delete(ProductSize entity);
        List<ProductSize> ProductSizeGet(int id);
    }
}
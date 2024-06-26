using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IPRODUCTSIZETYPESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class ProductSizeManager : IProductSizeService
    {
        private IProductSizeDal _productSizeDal;
        public ProductSizeManager(IProductSizeDal productSizeDal)
        {
            _productSizeDal = productSizeDal;
        }

        // METOTLAR
        public void Create(ProductSize entity)
        {
            _productSizeDal.Create(entity);
        }

        public void Delete(ProductSize entity)
        {
            _productSizeDal.Delete(entity);
        }

        public List<ProductSize> GetAll()
        {
            return _productSizeDal.GetAll().ToList();
        }

        public ProductSize GetById(int id)
        {
            return _productSizeDal.GetById(id);
        }

        public void Update(ProductSize entity)
        {
            _productSizeDal.Update(entity);
        }

        public List<ProductSize> ProductSizeGet(int id)
        {
            return _productSizeDal.ProductSizeGet(id);
        }
    }
}
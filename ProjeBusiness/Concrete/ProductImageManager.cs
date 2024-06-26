using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IPRODUCTIMAGESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        // METOTLAR
        public void Create(ProductImage entity)
        {
            _productImageDal.Create(entity);
        }

        public void Delete(ProductImage entity)
        {
            _productImageDal.Delete(entity);
        }

        public List<ProductImage> GetAll()
        {
            return _productImageDal.GetAll().ToList();
        }

        public ProductImage GetById(int id)
        {
            return _productImageDal.GetById(id);
        }

        public void Update(ProductImage entity)
        {
            _productImageDal.Update(entity);
        }
    }
}
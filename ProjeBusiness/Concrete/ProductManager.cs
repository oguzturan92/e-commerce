using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeData.Concrete;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IBLOGSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class ProductManager : IProductService
    {
        // DATA/ABSTRACT/IBLOGDAL dosyasını _blogDal nesnesi olarak tanımladık. DATA/ABSTRACT ise, DATA/CONCRETE içindeki dolu metotları alıcak. Bu dosyada _blogDal çağırdığımızda, DATA/ABSTRACT/IBLOGDAL içindeki metotlar işlenecek. IBLOGDAL da metotları IGENERICDAL'dan alıyor.
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        // METOTLAR
        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public void Create(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3) // Product oluştururken Category ekler
        {
            _productDal.Create(entity, categoryIds, designIds, categoryIds2, categoryIds3);
        }

        public void Update(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3) // Product düzenlerken Category ekler
        {
            _productDal.Update(entity, categoryIds, designIds, categoryIds2, categoryIds3);
        }

        public List<Product> GetProductList(string url)
        {
            return _productDal.GetProductList(url);
        }

        public List<Product> GetProductList2(string url)
        {
            return _productDal.GetProductList2(url);
        }

        public List<Product> GetProductList3(string url)
        {
            return _productDal.GetProductList3(url);
        }
        
        public List<Product> GetProductFilters(string url, int[] filters)
        {
            return _productDal.GetProductFilters(url, filters);
        }

        public List<Product> GetProductFilters2(string url, int[] filters)
        {
            return _productDal.GetProductFilters2(url, filters);
        }

        public List<Product> GetProductFilters3(string url, int[] filters)
        {
            return _productDal.GetProductFilters3(url, filters);
        }

        public Product GetProductDetails(int id) // Product detay metodu. Bloğun bağlı olduğu Kategorileri ortak tablodan getirir.
        {
            return _productDal.GetProductDetails(id);
        }

        public Product GetProductDetailClient(string url) // Product detay metodu. Bloğun bağlı olduğu Kategorileri ortak tablodan getirir.
        {
            return _productDal.GetProductDetailClient(url);
        }

        public List<Product> ProductImages()
        {
            return _productDal.ProductImages();
        }
        
        public Product GetByIdCategoriesAtProduct(int id) // Product Edit içinde kategoriyi çağırır
        {
            return _productDal.GetByIdCategoriesAtProduct(id);
        }

        public int GetCountByCategory(string url) // Sayfalama ile ilgili. Şu an kullanılmıyor.
        {
            return _productDal.GetCountByCategory(url);
        }

        public List<Product> Search(string searchKelimesi)
        {
            return _productDal.Search(searchKelimesi);
        }

        public Product CategoryListNameProduct(int id)
        {
            return _productDal.CategoryListNameProduct(id);
        }
        
        public Product ProductAndProductSizesAndSize(int id)
        {
            return _productDal.ProductAndProductSizesAndSize(id);
        }
    }
}
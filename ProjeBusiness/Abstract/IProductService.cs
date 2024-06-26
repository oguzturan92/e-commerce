using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{   
    // BLOG tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/BLOGMANAGER içinde dolduracağız.
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        void Create(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3); // Product oluştururken Category ekler
        void Update(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3); // Product düzenlerken Category ekler
        List<Product> GetProductList(string url); // Kategoriye göre Onaylı Product'ları getirir
        List<Product> GetProductList2(string url);
        List<Product> GetProductList3(string url);
        List<Product> GetProductFilters(string url, int[] filters);
        List<Product> GetProductFilters2(string url, int[] filters);
        List<Product> GetProductFilters3(string url, int[] filters);
        Product GetProductDetails(int id); // Product detay metodu. Bloğun bağlı olduğu Kategorileri ortak tablodan getirir.
        Product GetProductDetailClient(string url);
        List<Product> ProductImages();
        Product GetByIdCategoriesAtProduct(int id); // Product Edit içinde kategoriyi çağırır
        int GetCountByCategory(string url); // Sayfalama ile ilgili. Şu an kullanılmıyor.
        List<Product> Search(string searchKelimesi);
        Product CategoryListNameProduct(int id);
        public Product ProductAndProductSizesAndSize(int id);
    }
}
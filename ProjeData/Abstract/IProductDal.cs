using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{   
    // Burdaki IGenericDal<Product> kısmındaki Product adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Product değerini alıyor.
    public interface IProductDal : IGenericDal<Product>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/BLOGDAL dosyasında metotları dolduruyoruz.

        void Create(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3); // Product oluştururken Category ekler
        void Update(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3); // Product düzenlerken Category ekler
        List<Product> GetProductList(string url); // Kategoriye göre Onaylı productları getirir
        List<Product> GetProductList2(string url);
        List<Product> GetProductList3(string url);
        List<Product> GetProductFilters(string url, int[] filters); // Kategoriye göre Onaylı productları getirir
        List<Product> GetProductFilters2(string url, int[] filters);
        List<Product> GetProductFilters3(string url, int[] filters);
        Product GetProductDetails(int id); // Product detay metodu. Bloğun bağlı olduğu Kategorileri ortak tablodan getirir. Admin Edit içinde kullanılıyor
        Product GetProductDetailClient(string url); // Product detay metodu. Client detayda kullanılıyor.
        List<Product> ProductImages();
        Product GetByIdCategoriesAtProduct(int id); // Product Edit içinde kategoriyi çağırır
        int GetCountByCategory(string url); // Sayfalama ile ilgili. Şu an kullanılmıyor.
        List<Product> Search(string searchKelimesi);
        Product CategoryListNameProduct(int id);
        public Product ProductAndProductSizesAndSize(int id);

    }
}
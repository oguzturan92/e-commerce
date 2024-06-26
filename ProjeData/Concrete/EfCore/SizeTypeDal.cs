using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/ISizeTYPEDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class SizeTypeDal : GenericDal<SizeType>, ISizeTypeDal
    {
        public List<SizeType> SizeTypeAndSize()
        { // Product'tan varyasyon ekleme alanında, Varyasyonları listelemek için
            using (var context = new ProjeContext())
            {
                return context.SizeTypes
                                .OrderBy(i => i.SizeTypeSort)
                                .Include(i => i.Sizes
                                    .OrderBy(i => i.SizeSort)
                                )
                                .ToList();
            }
        }

        public SizeType ProductDetailSize(int id)
        { // Product varyasyon ekleme alanında, Varyasyonları listelemek için
            using (var context = new ProjeContext())
            {
                // İlk Where sorgusunda, SizeType tablosundan Size tablosuna ve ordan ProductSize tablosuna geçip gelen id(ProductId) ile eşit olan SizeType tablo değerlerini aldık. Böylelikle, ProductSize tablosunda, ProductId ile eşleşmeyen SizeType(Varyasyon Başlığı örn:RENK) bilgisi gelmeyecek.
                // İkinci sırada, Include ile Size tablosuna geçip, ikinci Where sorgusunda ise ProductSize tablosunun ProductId alanı ile eşleşen id bilgisi olan Size tablo bilgilerini aldık. Yani Product'a eklenmiş olan Size bilgilerini(Mavi renk, M meden, 42 numara gibi)
                return context.SizeTypes
                                .OrderBy(i => i.SizeTypeSort)
                                .Where(i => i.Sizes.Any(i => i.ProductSizes.Any(i => i.ProductId == id)))
                                
                                .Include(i => i.Sizes
                                    .OrderBy(i => i.SizeSort)
                                    .Where(i => i.ProductSizes.Any(i => i.ProductId == id))
                                )

                                .ThenInclude(i => i.ProductSizes
                                    .Where(i => i.ProductId == id)
                                )
                                .FirstOrDefault();
            }
        }

        public List<SizeType> SizeTypeAndSizeFilters(string url)
        { // O anki kategori ve alt kategorisinde bulunan ürünlerin SizeType ve Size bilgilerini getirir
            using (var context = new ProjeContext())
            {
                return context.SizeTypes
                .OrderBy(i => i.SizeTypeSort)
                .Where(i => i.Sizes.Any(i => i.ProductSizes.Any(i =>
                    i.Product.ProductCategories.Any(i => i.Category.CategoryUrl.ToLower() == url.ToLower()) ||
                    i.Product.ProductCategory2s.Any(i => i.Category2.Category.CategoryUrl.ToLower() == url.ToLower()) ||
                    i.Product.ProductCategory3s.Any(i => i.Category3.Category2.Category.CategoryUrl.ToLower() == url.ToLower())
                )))
                                
                .Include(i => i.Sizes
                    .OrderBy(i => i.SizeSort)
                    .Where(i => i.ProductSizes.Any(i =>
                        i.Product.ProductCategories.Any(i => i.Category.CategoryUrl.ToLower() == url.ToLower()) ||
                        i.Product.ProductCategory2s.Any(i => i.Category2.Category.CategoryUrl.ToLower() == url.ToLower()) ||
                        i.Product.ProductCategory3s.Any(i => i.Category3.Category2.Category.CategoryUrl.ToLower() == url.ToLower())
                    ))
                )

                .ThenInclude(i => i.ProductSizes)
                .ToList();
            }
        }

        public List<SizeType> SizeTypeAndSizeFilters2(string url)
        { // O anki kategori ve alt kategorisinde bulunan ürünlerin SizeType ve Size bilgilerini getirir
            using (var context = new ProjeContext())
            {
                return context.SizeTypes
                .OrderBy(i => i.SizeTypeSort)
                .Where(i => i.Sizes.Any(i => i.ProductSizes.Any(i =>
                    i.Product.ProductCategory2s.Any(i => i.Category2.Category2Url.ToLower() == url.ToLower()) ||
                    i.Product.ProductCategory3s.Any(i => i.Category3.Category2.Category2Url.ToLower() == url.ToLower())
                )))
                                
                .Include(i => i.Sizes
                    .OrderBy(i => i.SizeSort)
                    .Where(i => i.ProductSizes.Any(i =>
                        i.Product.ProductCategory2s.Any(i => i.Category2.Category2Url.ToLower() == url.ToLower()) ||
                        i.Product.ProductCategory3s.Any(i => i.Category3.Category2.Category2Url.ToLower() == url.ToLower())
                    ))
                )

                .ThenInclude(i => i.ProductSizes)
                .ToList();
            }
        }
    
        public List<SizeType> SizeTypeAndSizeFilters3(string url)
        { // O anki kategori ve alt kategorisinde bulunan ürünlerin SizeType ve Size bilgilerini getirir
            using (var context = new ProjeContext())
            {
                return context.SizeTypes
                .OrderBy(i => i.SizeTypeSort)
                .Where(i => i.Sizes.Any(i => i.ProductSizes.Any(i =>
                    i.Product.ProductCategory3s.Any(i => i.Category3.Category3Url.ToLower() == url.ToLower())
                )))
                                
                .Include(i => i.Sizes
                    .OrderBy(i => i.SizeSort)
                    .Where(i => i.ProductSizes.Any(i =>
                        i.Product.ProductCategory3s.Any(i => i.Category3.Category3Url.ToLower() == url.ToLower())
                    ))
                )

                .ThenInclude(i => i.ProductSizes)
                .ToList();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IBLOGDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class ProductDal : GenericDal<Product>, IProductDal
    {
        public void Create(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3)
        {
            using (var context = new ProjeContext())
            {
                var product = new Product(); // Product tablosundan Product adında yeni bir nesne oluşturduk.
                
                    product.ProductCode = entity.ProductCode;
                    product.ProductName = entity.ProductName;
                    product.ProductShortName = entity.ProductShortName;
                    product.ProductColor = entity.ProductColor;
                    product.ProductUrl = entity.ProductUrl;
                    product.ProductStock = entity.ProductStock;
                    product.ProductPrice = entity.ProductPrice;
                    product.ProductSalePrice = entity.ProductSalePrice;
                    product.ProductKdv = entity.ProductKdv;
                    product.ProductImage = entity.ProductImage;
                    product.ProductImages = entity.ProductImages;
                    product.ProductApproval = entity.ProductApproval;
                    product.ProductSort = entity.ProductSort;
                    product.ProductNew = entity.ProductNew;
                    product.ProductSale = entity.ProductSale;
                    product.ProductSeoTitle = entity.ProductSeoTitle;
                    product.ProductSeoDescription = entity.ProductSeoDescription;
                    product.ProductSeoKeyword = entity.ProductSeoKeyword;

                    product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                    {
                        CategoryId = catId, // catId bilgisini ProductCategories tablosunun CategoryId ve
                        ProductId = entity.ProductId // entity'nin ProductId bilgisini ProductCategories tablosunun ProductId alanına atıyoruz
                    }).ToList();

                    product.ProductHomeDesignTypes = designIds.Select(designId => new ProductHomeDesignType()
                    {
                        HomeDesignTypeId = designId,
                        ProductId = entity.ProductId
                    }).ToList();

                    product.ProductCategory2s = categoryIds2.Select(cat2Id => new ProductCategory2()
                    {
                        Category2Id = cat2Id,
                        ProductId = entity.ProductId
                    }).ToList();

                    product.ProductCategory3s = categoryIds3.Select(cat3Id => new ProductCategory3()
                    {
                        Category3Id = cat3Id,
                        ProductId = entity.ProductId
                    }).ToList();

                    context.Products.Add(product); // Product nesnesini Products tablosuna Add(ekledik)

                    context.SaveChanges();
            }
        }
        
        public void Update(Product entity, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3)
        {
            using (var context = new ProjeContext())
            {
                var product = context.Products
                                    .Include(i => i.ProductCategories)
                                    .Where(i => i.ProductId == entity.ProductId)
                                    .Include(i => i.ProductCategory2s)
                                    .Where(i => i.ProductId == entity.ProductId)
                                    .Include(i => i.ProductCategory3s)
                                    .Where(i => i.ProductId == entity.ProductId)
                                    .Include(i => i.ProductHomeDesignTypes)
                                    .Where(i => i.ProductId == entity.ProductId)
                                    .FirstOrDefault();

                if (product != null)
                {
                    product.ProductCode = entity.ProductCode;
                    product.ProductName = entity.ProductName;
                    product.ProductShortName = entity.ProductShortName;
                    product.ProductColor = entity.ProductColor;
                    product.ProductUrl = entity.ProductUrl;
                    product.ProductStock = entity.ProductStock;
                    product.ProductPrice = entity.ProductPrice;
                    product.ProductSalePrice = entity.ProductSalePrice;
                    product.ProductKdv = entity.ProductKdv;
                    product.ProductImage = entity.ProductImage;
                    product.ProductImages = entity.ProductImages;
                    product.ProductApproval = entity.ProductApproval;
                    product.ProductSort = entity.ProductSort;
                    product.ProductNew = entity.ProductNew;
                    product.ProductSale = entity.ProductSale;
                    product.ProductSeoTitle = entity.ProductSeoTitle;
                    product.ProductSeoDescription = entity.ProductSeoDescription;
                    product.ProductSeoKeyword = entity.ProductSeoKeyword;

                    product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                    {
                        CategoryId = catId,
                        ProductId = entity.ProductId
                    }).ToList();

                    product.ProductHomeDesignTypes = designIds.Select(designId => new ProductHomeDesignType()
                    {
                        HomeDesignTypeId = designId,
                        ProductId = entity.ProductId
                    }).ToList();

                    product.ProductCategory2s = categoryIds2.Select(cat2Id => new ProductCategory2()
                    {
                        Category2Id = cat2Id,
                        ProductId = entity.ProductId
                    }).ToList();

                    product.ProductCategory3s = categoryIds3.Select(cat3Id => new ProductCategory3()
                    {
                        Category3Id = cat3Id,
                        ProductId = entity.ProductId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }

        public List<Product> GetProductList(string url)
        {
            // Seçilen Category bilgisi ile eşit, Category bilgisine sahip olan Product'ları ve Product'ların bağlı olduğu Image'leri getirir.
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    .Where(i => i.ProductApproval)
                                    .OrderBy(i => i.ProductSort)
                                    .AsQueryable(); // ToList'ten farkı, alıp tekrar sorgulama yapabiliyor olmamız. En sonunda ToList diyecez.

                if (!string.IsNullOrEmpty(url))
                { // Product'tan ProductCategories ve orda Category tablosuna geçtik. Category tablosunu başlangıç alıp ProductCategories tablosunda Any() içindeki koşulu sağlayan Product'ları aldık
                    products = products
                            .Include(i => i.ProductCategories)
                            .ThenInclude(i => i.Category)
                            .Where(i => 
                                i.ProductCategories.Any(a => a.Category.CategoryUrl.ToLower() == url.ToLower()) ||
                                i.ProductCategory2s.Any(a => a.Category2.Category.CategoryUrl.ToLower() == url.ToLower() && a.Category2.Category2Approval) || 
                                i.ProductCategory3s.Any(a => a.Category3.Category2.Category.CategoryUrl.ToLower() == url.ToLower())
                            )
                            .Include(i => i.ProductSizes)
                            .ThenInclude(i => i.Size)
                            .ThenInclude(i => i.SizeType)
                            .OrderBy(i => i.ProductSort)
                            .Include(i => i.ProductImages
                                .OrderBy(i => i.ProductImageSort)
                                .Take(2)
                            );
                }
                return products.ToList();
            }
        }

        public List<Product> GetProductList2(string url)
        {
            // Seçilen Category bilgisi ile eşit, Category bilgisine sahip olan Product'ları ve Product'ların bağlı olduğu Image'leri getirir.
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    .Where(i => i.ProductApproval)
                                    .OrderBy(i => i.ProductSort)
                                    .AsQueryable(); // ToList'ten farkı, alıp tekrar sorgulama yapabiliyor olmamız. En sonunda ToList diyecez.

                if (!string.IsNullOrEmpty(url))
                {
                    products = products
                            .Include(i => i.ProductCategory2s)
                            .ThenInclude(i => i.Category2)
                            .Where(i =>
                                i.ProductCategory2s.Any(a => a.Category2.Category2Url.ToLower() == url.ToLower()) || 
                                i.ProductCategory3s.Any(a => a.Category3.Category2.Category2Url.ToLower() == url.ToLower())
                            )
                            .OrderBy(i => i.ProductSort)
                            .Include(i => i.ProductImages // Product'larla ilişkili olan Image'leri de aldık
                                .OrderBy(i => i.ProductImageSort)
                                .Take(2)
                            );
                }
                return products.ToList();
            }
        }

        public List<Product> GetProductList3(string url)
        {
            // Seçilen Category bilgisi ile eşit, Category bilgisine sahip olan Product'ları ve Product'ların bağlı olduğu Image'leri getirir.
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    .Where(i => i.ProductApproval)
                                    .OrderBy(i => i.ProductSort)
                                    .AsQueryable(); // ToList'ten farkı, alıp tekrar sorgulama yapabiliyor olmamız. En sonunda ToList diyecez.

                if (!string.IsNullOrEmpty(url))
                {
                    products = products
                            .Include(i => i.ProductCategory3s)
                            .ThenInclude(i => i.Category3)
                            .Where(i =>
                                i.ProductCategory3s.Any(a => a.Category3.Category3Url.ToLower() == url.ToLower())
                            )
                            .OrderBy(i => i.ProductSort)
                            .Include(i => i.ProductImages // Product'larla ilişkili olan Image'leri de aldık
                                .OrderBy(i => i.ProductImageSort)
                                .Take(2)
                            );
                }
                return products.ToList();
            }
        }

        public List<Product> GetProductFilters(string url, int[] filters)
        {
            // Seçilen Category bilgisi ile eşit, Category bilgisine sahip olan Product'ları ve Product'ların bağlı olduğu Image'leri getirir.
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    .Where(i =>
                                        i.ProductApproval && 
                                        i.ProductSizes.Any(i => filters.Contains(i.SizeId))
                                    )
                                    .Where(i => 
                                        i.ProductCategories.Any(a => a.Category.CategoryUrl.ToLower() == url.ToLower())
                                        ||
                                        i.ProductCategory2s.Any(a => a.Category2.Category.CategoryUrl.ToLower() == url.ToLower())
                                        ||
                                        i.ProductCategory3s.Any(a => a.Category3.Category2.Category.CategoryUrl.ToLower() == url.ToLower())
                                    )
                                    .OrderBy(i => i.ProductSort)
                                    .Include(i => i.ProductImages
                                        .OrderBy(i => i.ProductImageSort)
                                        .Take(2)
                                    )
                                    .AsQueryable(); // ToList'ten farkı, alıp tekrar sorgulama yapabiliyor olmamız. En sonunda ToList diyecez.

                // if (!string.IsNullOrEmpty(url))
                // { // Product'tan ProductCategories ve orda Category tablosuna geçtik. Category tablosunu başlangıç alıp ProductCategories tablosunda Any() içindeki koşulu sağlayan Product'ları aldık
                //     products = products
                //             // .Include(i => i.ProductCategories)
                //             // .ThenInclude(i => i.Category)
                //             .Where(i => 
                //                 i.ProductCategories.Any(a => a.Category.CategoryUrl.ToLower() == url.ToLower()) ||
                //                 i.ProductCategory2s.Any(a => a.Category2.Category.CategoryUrl.ToLower() == url.ToLower()) ||
                //                 i.ProductCategory3s.Any(a => a.Category3.Category2.Category.CategoryUrl.ToLower() == url.ToLower())
                //             // )
                //             // .Include(i => i.ProductSizes)
                //             // .ThenInclude(i => i.Size)
                //             // .ThenInclude(i => i.SizeType)
                //             // .OrderBy(i => i.ProductSort)
                //             // .Include(i => i.ProductImages
                //             //     .OrderBy(i => i.ProductImageSort)
                //             //     .Take(2)
                //             );
                // }
                return products.ToList();
            }
        }

        public List<Product> GetProductFilters2(string url, int[] filters)
        {
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    .Where(i =>
                                        i.ProductApproval && 
                                        i.ProductSizes.Any(i => filters.Contains(i.SizeId))
                                    )
                                    .Where(i =>
                                        i.ProductCategory2s.Any(a => a.Category2.Category2Url.ToLower() == url.ToLower())
                                        ||
                                        i.ProductCategory3s.Any(a => a.Category3.Category2.Category2Url.ToLower() == url.ToLower())
                                    )
                                    .OrderBy(i => i.ProductSort)
                                    .Include(i => i.ProductImages
                                        .OrderBy(i => i.ProductImageSort)
                                        .Take(2)
                                    )
                                    .AsQueryable();
                                    
                    // products = products
                    //         .Where(i =>
                    //             i.ProductCategory2s.Any(a => a.Category2.Category2Url.ToLower() == url.ToLower()) ||
                    //             i.ProductCategory3s.Any(a => a.Category3.Category2.Category2Url.ToLower() == url.ToLower())
                    //         );
                return products.ToList();
            }
        }

        public List<Product> GetProductFilters3(string url, int[] filters)
        {
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    .Where(i =>
                                        i.ProductApproval && 
                                        i.ProductSizes.Any(i => filters.Contains(i.SizeId))
                                    )
                                    .Where(i =>
                                        i.ProductCategory3s.Any(a => a.Category3.Category3Url.ToLower() == url.ToLower())
                                    )
                                    .OrderBy(i => i.ProductSort)
                                    .Include(i => i.ProductImages
                                        .OrderBy(i => i.ProductImageSort)
                                        .Take(2)
                                    )
                                    .AsQueryable();

                    // products = products
                    //         .Where(i =>
                    //             i.ProductCategory3s.Any(a => a.Category3.Category3Url.ToLower() == url.ToLower())
                    //         );
                return products.ToList();
            }
        }

        public Product GetProductDetails(int id) // Product Admin detay metodu. Product'ın bağlı olduğu Kategorileri ortak tablodan getirir. ProductEdit içinde kullanıyoruz.
        {
            using (var context = new ProjeContext())
            {
                return context.Products // context üzerinden Products tablosuna gidip
                                .Where(i => i.ProductId == id) // Gelen id'ye eşit olan ProductId elemanını alır
                                .Include(i => i.ProductCategories) // ProductCategories'e geçiş yapıp
                                .ThenInclude(i => i.Category) // Category'i getiriyoruz
                                .Include(i => i.ProductHomeDesignTypes) // Ortak tabloya geçiş yapıp
                                .ThenInclude(i => i.HomeDesignType) // HomeDesignType'i getirir
                                .Include(i => i.ProductCategory2s) // ProductCategory2s'e geçiş yapıp
                                .ThenInclude(i => i.Category2) // Category2'i getiriyoruz
                                .Include(i => i.ProductCategory3s)
                                .ThenInclude(i => i.Category3)
                                .FirstOrDefault(); // Tek bir kayıt döndürür
            }
        }

        public Product GetProductDetailClient(string url) // Product detay metodu. Product'ın bağlı olduğu Kategorileri ortak tablodan getirir. ProductClientDetail içinde kullanıyoruz.
        {
            using (var context = new ProjeContext())
            {
                var product = context.Products.Where(i => i.ProductUrl.ToLower() == url.ToLower() && i.ProductApproval).FirstOrDefault();
                
                if (product != null)
                {
                    return context.Products // context üzerinden Products tablosuna gidip
                                    .Where(i => i.ProductApproval && i.ProductUrl.ToLower() == url.ToLower()) // Gelen id'ye eşit olan ProductId elemanını alır
                                    // .Include(i => i.ProductCategories)
                                    // .ThenInclude(i => i.Category)
                                    .Include(i => i.Descriptions // Product ile ilişkili olanları aldık
                                        .Where(i => i.ProductId == product.ProductId && i.DescriptionApproval).OrderBy(i => i.DescriptionSort)
                                    )
                                    .Include(i => i.Variants
                                        .Where(i => i.ProductId == product.ProductId)
                                        .OrderBy(i => i.VariantId)
                                    )
                                    .Include(i => i.ProductImages
                                        .OrderBy(i => i.ProductImageSort)
                                    )
                                    .FirstOrDefault();
                }
                return new Product(){};
            }
        }

        public List<Product> ProductImages() // Product ve ona bağlı olan Image'leri getirir
        {
            using (var context = new ProjeContext())
            {
                return context.Products
                                .Where(i => i.ProductApproval).OrderBy(i => i.ProductSort)
                                .Include(i => i.ProductImages
                                    .OrderBy(i => i.ProductImageSort)
                                )
                                .ToList();
            }
        }

        public Product GetByIdCategoriesAtProduct(int id) // id ile eşit olan product elemanını ve onun bağlı olduğu ortak tablo bilgilerini çağırır.
        {
            // Products tablosu üzerinden ProductCategories ortak tablosuna bağlanıp, Categories tablosuna geçiş yapıcaz. Hem Product, hem de Category bilgilerini alabiliyoruz bu metot ile. GetProductDetails metodu ile aynı.
            using (var context = new ProjeContext())
            {
                return context.Products // context üzerinden Products tablosuna gidip
                                .Where(i => i.ProductId == id) // Gelen id'ye eşit olan ProductId elemanını alır
                                .Include(i => i.ProductCategories) // ProductCategories'e geçiş yapıp
                                .ThenInclude(i => i.Category) // Category'i getiriyoruz
                                .Include(i => i.ProductHomeDesignTypes) // Ortak tabloya geçiş yapıp
                                .ThenInclude(i => i.HomeDesignType) // HomeDesignType'i getirir
                                .Include(i => i.ProductCategory2s) // ProductCategories'e geçiş yapıp
                                .ThenInclude(i => i.Category2) // Category'i getiriyoruz
                                .FirstOrDefault(); // Tek bir kayıt döndürür
            }
        }

        public int GetCountByCategory(string url) // Sayfalama ile ilgili. Seçilen kategoriye ait elemanların sayılarını alır bu metodun sonundaki Count ile.
        {
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    .Where(i => i.ProductApproval == true)
                                    .AsQueryable();

                if (!string.IsNullOrEmpty(url))
                {
                    products = products
                            .Include(i => i.ProductCategories)
                            .ThenInclude(i => i.Category)
                            .Where(i => i.ProductCategories.Any(a => a.Category.CategoryUrl.ToLower() == url
                            .ToLower()));
                }
                return products.Count();
            }
        }

        public List<Product> Search(string searchKelimesi)
        {
            using (var context = new ProjeContext())
            {
                var products = context.Products
                                    // .Where(i => i.ProductOnay == true && (i.ProductName.ToLower().Contains(searchKelimesi) || i.ProductShortName.ToLower().Contains(searchKelimesi))) -- Birden fazla arama seçeneği
                                    .Where(i => i.ProductApproval && i.ProductName.ToLower().Contains(searchKelimesi.ToLower()))
                                    .Include(i => i.ProductImages.OrderBy(i => i.ProductImageSort))
                                    .OrderBy(i => i.ProductSort)
                                    .AsQueryable();

                return products.ToList();
            }
        }

        public Product CategoryListNameProduct(int id)
        {
            using (var context = new ProjeContext())
            {
                var product = context.Products
                                    .Where(i => i.ProductId == id)

                                    .Include(i => i.ProductCategories
                                        .OrderBy(i => i.Category.CategorySort).Take(1)
                                    )
                                    .ThenInclude(i => i.Category)

                                    .Include(i => i.ProductCategory2s
                                        .OrderBy(i => i.Category2.Category2Sort).Take(1)
                                    )
                                    .ThenInclude(i => i.Category2)

                                    .Include(i => i.ProductCategory3s
                                        .OrderBy(i => i.Category3.Category3Sort).Take(1)
                                    )
                                    .ThenInclude(i => i.Category3)

                                    .FirstOrDefault();                                    

                return product;
            }
        }
    
        public Product ProductAndProductSizesAndSize(int id) // Sepet sessionda product listesine bu metottan gelen product'ı atıyoruz.
        {
            using (var context = new ProjeContext())
            {
                return context.Products
                                .Where(i => i.ProductId == id)
                                .Include(i => i.ProductSizes)
                                .ThenInclude(i => i.Size)
                                .FirstOrDefault();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // BLOG İLE İLGİLİ MODELLER BU DOSYADA YER ALIR

    // Admin/EditProduct içinde kullanılıyor
    // Admin/CreateProduct içinde kullanılıyor
    public class ProductModel
    {
        public int ProductId { get; set; }
        public int ProductCode { get; set; }

        // [Required(ErrorMessage = "Zorunlu alan.")]
        public string ProductName { get; set; }

        // [Required(ErrorMessage = "Zorunlu alan.")]
        public string ProductShortName { get; set; }

        // [Required(ErrorMessage = "Zorunlu alan.")]
        // [RegularExpression(@"^(?=.*[a-z$-])[a-z$-]{0,}", ErrorMessage = "Bu alanda küçük harf, ingilizce karakter ve boşluk yerine ' - ' kullanabilirsiniz.")]
        public string ProductUrl { get; set; }
        public string ProductColor { get; set; }
        public int ProductStock { get; set; }
        public int ProductKdv { get; set; }
        
        // [RegularExpression(@"(?=.*\d,)[\d,]{1,}", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [DataType(DataType.Currency)]
        public double ProductPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public string ProductImage { get; set; }
        public bool ProductApproval { get; set; }
        public bool ProductDetailRandom { get; set; }
        public bool ProductHomeList { get; set; }
        public int? ProductSort { get; set; }
        public bool ProductNew { get; set; }
        public bool ProductSale { get; set; }
        public string ProductSeoTitle { get; set; }
        public string ProductSeoDescription { get; set; }
        public string ProductSeoKeyword { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Description> Descriptions { get; set; }
        public List<Category> ListCategories { get; set; }
        public List<Category> SelectedCategories { get; set; }
        public List<Category2> SelectedCategory2s { get; set; }
        public List<Category3> SelectedCategory3s { get; set; }
        public List<HomeDesignType> ListHomeDesignTypes { get; set; }
        public List<HomeDesignType> SelectedListHomeDesignTypes { get; set; }
        public List<List> Lists { get; set; }
    }

    // Sayfalama için oluşturuldu.
    // Product/List içinde kullanılıyor
    // Admin/IndexProduct içinde kullanılıyor
    // AdminAccount/Index içinde kullanılıyor
    public class PageInfo
    {
        public int TotalItems { get; set; } // Toplam eleman sayısı
        public int ItemsPerPage { get; set; } // Sayfabaşına gösterilmek istenen eleman adedi
        public int CurrentPage { get; set; } // O an gösterilen sayfa
        public string CurrentCategory { get; set; } // O an gösterilen kategori

        public int TotalPages() // Kaç adet sayfa oluşturulacağı bilgisi
        {
            return (int)Math.Ceiling((double)TotalItems/ItemsPerPage);
        }
    }

    // Product/List içinde kullanılıyor
    // Product/Search içinde kullanılıyor
    public class ProductListModel
    {
        public PageInfo PageInfo { get; set; } // Product/List içinde, burdaki PageInfo nesnesine, yukarıdaki PageInfo Model'ini gönderiyoruz.
        public List<Product> Products { get; set; }
        public List<string> ProdutsSelect { get; set; }
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public Category2 Category2 { get; set; }
        public Category3 Category3 { get; set; }
        public Category CategoryFilters { get; set; }
        public Category2 CategoryFilters2 { get; set; }
        public Category3 CategoryFilters3 { get; set; }
        public List<SizeType> SizeTypes { get; set; }
        public int[] SelectedFilters { get; set; }
        public string CategoryBackUrlUst { get; set; }
        public string CategoryBackUrl { get; set; }
    }

    // Product/Details içinde kullanılıyor
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Product> VariantProducts { get; set; }
        public SizeType SizeType { get; set; }
        public List<List> Lists { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Category> Categories { get; set; }
        public List<Description> Descriptions { get; set; }
        public Product CategoryTree { get; set; }
        public List<Favorite> Favorites { get; set; }
        public bool ProductinFavorite { get; set; }
    }

    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public List<Product> VariantProducts { get; set; }
        public SizeType SizeType { get; set; }
        public List<List> Lists { get; set; }
        public Product CategoryTree { get; set; }
    }
}
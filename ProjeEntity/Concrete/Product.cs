using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductShortName { get; set; }
        public string ProductColor { get; set; }
        public int ProductStock { get; set; }
        public int ProductKdv { get; set; }
        public double ProductPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public string ProductUrl { get; set; }
        public string ProductImage { get; set; }
        public bool ProductApproval { get; set; }
        public int? ProductSort { get; set; }
        public bool ProductNew { get; set; }
        public bool ProductSale { get; set; }
        public string ProductSeoTitle { get; set; }
        public string ProductSeoDescription { get; set; }
        public string ProductSeoKeyword { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductCategory2> ProductCategory2s { get; set; }
        public List<ProductCategory3> ProductCategory3s { get; set; }
        public List<ProductHomeDesignType> ProductHomeDesignTypes { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductList> ProductLists { get; set; }
        public List<Description> Descriptions { get; set; }
        public List<Variant> Variants { get; set; }
        
        [JsonIgnore]
        [IgnoreDataMember]
        public List<ProductSize> ProductSizes { get; set; }
        public List<FavoriteProduct> FavoriteProducts { get; set; }
        public List<SepetLine> SepetLines { get; set; }
    }
}
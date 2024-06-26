using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class Cart
    {
        // Sepete eklenen ürünleri barındıracak
        private List<CartLine> products = new List<CartLine>();

        // Sepetteki ürünler, görüntülenmek istendiğinde, burdan göndereceğiz.
        public List<CartLine> Product => products;


        public void AddProduct(Product product, int quantity, int productSizeId)
        {
            // products listesi içinde yani sepette daha önce eklenmiş ürün sorguluyoruz.
            var productSorgula = products.Where(i => i.Product.ProductId == product.ProductId && i.ProductSizeId == productSizeId).FirstOrDefault();        

            // Daha önce eklenmiş ürün yoksa yeni ürün ekliyoruz. Varsa, quantity değerini artırıyoruz.
            if (productSorgula == null)
            {  
                // ürün bedeni varsa, beden fiyatından işlem yaparız
                if (productSizeId > 0)
                {
                    var productSizePrice = product.ProductSizes.Where(i => i.ProductSizeId == productSizeId).FirstOrDefault().ProductSizePrice;
                    var sizeName = product.ProductSizes.Where(i => i.ProductSizeId == productSizeId).FirstOrDefault().Size.SizeTitle;
                    if (productSizePrice != 0)
                    {   // Beden fiyatı girilmişse beden fiyatını alırız
                        var cartLine = new CartLine(){
                            Product = product, 
                            ProductQuantity = quantity,
                            ProductSizeId = productSizeId,
                            ProductPrice = productSizePrice,
                            SizeName = sizeName
                        };
                        products.Add(cartLine);
                    } else
                    {   // Beden fiyatı girilmemişse, ürün fiyatından işlem yaparız
                        if (product.ProductSalePrice > 0)
                        {
                            var cartLine = new CartLine(){
                                Product = product, 
                                ProductQuantity = quantity,
                                ProductSizeId = productSizeId,
                                ProductPrice = product.ProductSalePrice,
                                SizeName = sizeName
                            };
                            products.Add(cartLine);
                        } else
                        {
                            var cartLine = new CartLine(){
                                Product = product, 
                                ProductQuantity = quantity,
                                ProductSizeId = productSizeId,
                                ProductPrice = product.ProductPrice,
                                SizeName = sizeName
                            };
                            products.Add(cartLine);
                        }
                    }
                } else
                {   // ürün bedeni yoksa ana fiyattan işlem yaparız
                    if (product.ProductSalePrice > 0)
                    {
                        var cartLine = new CartLine(){
                            Product = product, 
                            ProductQuantity = quantity,
                            ProductSizeId = productSizeId,
                            ProductPrice = product.ProductSalePrice,
                            SizeName = product.ProductColor
                        };
                        products.Add(cartLine);
                    } else
                    {
                        var cartLine = new CartLine(){
                            Product = product, 
                            ProductQuantity = quantity,
                            ProductSizeId = productSizeId,
                            ProductPrice = product.ProductPrice,
                            SizeName = product.ProductColor
                        };
                        products.Add(cartLine);
                    }
                }
            } else
            {
                productSorgula.ProductQuantity += quantity;
            }
        }

        public void ProductQuantity(Product product, int quantity, int productSizeId)
        {
            var productSorgula = products.Where(i => i.Product.ProductId == product.ProductId && i.ProductSizeId == productSizeId).FirstOrDefault();
            
            if (productSorgula != null)
            {
                productSorgula.ProductQuantity = quantity;

                if (productSizeId > 0)
                {   // Ürün bedeni varsa ürün beden fiyatından işlem yaparız

                    var productSize = product.ProductSizes.Where(i => i.ProductSizeId == productSizeId).FirstOrDefault();

                    if (productSize.ProductSizePrice > 0)
                    {   // Ürün bedenine fiyat girilmişse beden fiyatını alırız.
                        productSorgula.ProductPrice = productSize.ProductSizePrice;
                    } else
                    {   // Ürün beden bilgisine fiyat girilmemişse ana fiyattan işlem yaparız
                        if (product.ProductSalePrice > 0)
                        {
                            productSorgula.ProductPrice = product.ProductSalePrice;
                        } else
                        {
                            productSorgula.ProductPrice = product.ProductPrice;
                        }
                    }
                } else
                {   // Ürün bedeni yoksa ürün ana fiyatından işlem yaparız
                    if (product.ProductSalePrice > 0)
                    {
                        productSorgula.ProductPrice = product.ProductSalePrice;
                    } else
                    {
                        productSorgula.ProductPrice = product.ProductPrice;
                    }
                }
            }
        }

        public void RemoveProduct(Product product, int productSizeId)
        {
            var productSorgula = products.Where(i => i.Product.ProductId == product.ProductId && i.ProductSizeId == productSizeId).FirstOrDefault();
            
            if (productSorgula != null)
            {
                products.Remove(productSorgula);
            }
        }

        public void RemoveProductId(int productId)
        {
            // Product False olduğunda o ürünün tüm varyantlarını sepetten siler.
            var productSorgula = products.Where(i => i.Product.ProductId == productId).FirstOrDefault();

            if (productSorgula != null)
            {
                products.Remove(productSorgula);
            }
        }

        public void RemoveProductAll()
        {
            products.Clear();
        }

        public double TotalPrice()
        {
            // return products.Sum(i => i.Product.ProductPrice * i.ProductQuantity);
            return products.Sum(i => i.ProductPrice * i.ProductQuantity);
        }
    }

    public class CartLine
    {
        public int CartLineId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductSizeId { get; set; }
        public int ProductKdvPrice { get; set; }
        public double ProductPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public string SizeName { get; set; }
    }
}
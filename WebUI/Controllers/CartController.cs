using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        ProductManager _productService = new ProductManager(new ProductDal());
        ProductSizeManager _productSizeService = new ProductSizeManager(new ProductSizeDal());
        AdresManager _adresService = new AdresManager(new AdresDal());
        OrderManager _orderService = new OrderManager(new OrderDal());
        SepetManager _sepetService = new SepetManager(new SepetDal());
        BankAccountManager _bankAccountService = new BankAccountManager(new BankAccountDal());
        SepetLineManager _sepetLineService = new SepetLineManager(new SepetLineDal());
        GiftCardManager _giftCardService = new GiftCardManager(new GiftCardDal());
        CargoManager _cargoService = new CargoManager(new CargoDal());
        private UserManager<ProjeUser> _userManager;
        public CartController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }
        
        // METOTLAR ------------------------------------------------------------
        public async Task<IActionResult> AddToCart(int productId, int productSizeId = 0, int quantity = 1)
        {
            var product = _productService.ProductAndProductSizesAndSize(productId);
            if (productSizeId > 0)
            {
                if (!product.ProductSizes.Select(i => i.ProductSizeId).Contains(productSizeId))
                {
                    TempData["iconOK"] = "warning";
                    TempData["iconText"] = "Başka ürüne ait özelliği ekleyemezsiniz.";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl, id = product.ProductId });
                }
                
                var productSize = _productSizeService.GetById(productSizeId);
                if (productSize.ProductSizeStock < 1)
                {
                    TempData["iconOK"] = "warning";
                    TempData["iconText"] = "Yeterli stok olmayan ürünü ekleyemezsiniz.";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl, id = product.ProductId });
                }
            }
            
            if (product.ProductSizes.Count() > 0 && productSizeId < 1)
            {
                    TempData["iconOK"] = "warning";
                    TempData["iconText"] = "Beden bilgisi eksik.";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl, id = product.ProductId });
            }

            var prices = new List<double>();
            if (productSizeId > 0)
            {
                var productSize = _productSizeService.GetById(productSizeId);
                if (productSize.ProductSizeStock < quantity)
                {
                    TempData["iconOK"] = "warning";
                    TempData["iconText"] = "Yeterli stok mevcut değil.";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl, id = product.ProductId });
                }
                prices.Add(productSize.ProductSizePrice * quantity);
            } else
            {
                if (product.ProductStock < quantity)
                {
                    TempData["iconOK"] = "warning";
                    TempData["iconText"] = "Yeterli stok mevcut değil.";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl, id = product.ProductId });
                }
                prices.Add(product.ProductPrice * quantity);
            }

            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var price = prices.Sum(i => i);
                    
                    var sepet = _sepetService.SepetAndProducts(user.Id);
                    if (sepet == null)
                    {
                        var newSepet = new Sepet()
                        {
                            SepetLines = new List<SepetLine>() {
                                new SepetLine() {
                                    ProductId = product.ProductId,
                                    ProductQuantity = quantity,
                                    ProductSizeId = productSizeId
                                }
                            },
                            ProjeUserId = user.Id,
                            SiparisToplam = price,
                            GenelToplam = price
                        };
                        _sepetService.Create(newSepet);
                    } else
                    {
                        var eklenmisProductSepetLine = _sepetService.SepetAndProducts(user.Id).SepetLines.Where(i => i.ProductId == product.ProductId && i.ProductSizeId == productSizeId).FirstOrDefault();
                        
                        if (eklenmisProductSepetLine != null)
                        { // Sepette olan ürün ise, adedini günceller
                            eklenmisProductSepetLine.ProductQuantity += quantity;
                            _sepetLineService.Update(eklenmisProductSepetLine);

                            sepet.SiparisToplam = price + sepet.SiparisToplam;
                            sepet.GenelToplam = price + sepet.GenelToplam;
                            _sepetService.Update(sepet);
                        } else
                        { // Sepette olan ürün değilse yeni ürün olarak ekler.
                            var sepetLine = new SepetLine()
                            {
                                SepetId = sepet.SepetId,
                                ProductId = productId,
                                ProductQuantity = quantity,
                                ProductSizeId = productSizeId
                            };
                            
                            _sepetLineService.Create(sepetLine);

                            sepet.SiparisToplam = price + sepet.SiparisToplam;
                            sepet.GenelToplam = price + sepet.GenelToplam;
                            _sepetService.Update(sepet);
                        }
                    }
                    TempData["sepet"] = "success";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl, id = product.ProductId });
                }
            } else
            {
                if (product != null)
                {
                    var cart = GetCart();
                    cart.AddProduct(product, quantity, productSizeId);
                    SaveCart(cart);

                    TempData["sepet"] = "success";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl, id = product.ProductId });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveFromCart(int productId, int sepetLineId, int productSizeId = 0)
        {
            var product = _productService.GetById(productId);
            if (product != null)
            {
                var userName = User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    if (user != null)
                    {
                        var sepetLine = _sepetLineService.SepetLineAndProductAndSize(sepetLineId, productSizeId);
                        if (sepetLine != null)
                        {
                            var sepet = _sepetService.Sepet(user.Id);

                            double price = 0;
                            if (productSizeId > 0)
                            {
                                price = sepet.SiparisToplam - (sepetLine.Product.ProductSizes.Where(i => i.ProductSizeId == productSizeId).FirstOrDefault().ProductSizePrice * sepetLine.ProductQuantity);
                            } else
                            {
                                price = sepet.SiparisToplam - (sepetLine.Product.ProductPrice * sepetLine.ProductQuantity);
                            }

                            sepet.SiparisToplam = price; 
                            sepet.GenelToplam = price;

                            _sepetLineService.Delete(sepetLine);

                            if (_sepetService.SepetAndProducts(user.Id).SepetLines.Count() == 0)
                            {
                                _sepetService.Delete(sepet);
                            } else
                            {
                                _sepetService.Update(sepet);
                            }
                        }
                        return RedirectToAction("CartIndex", "Cart");
                    }
                }
                
                var cart = GetCart();
                cart.RemoveProduct(product, productSizeId);
                SaveCart(cart);
            }
            return RedirectToAction("CartIndex", "Cart");
        }

        public async Task<IActionResult> RemoveFromCartAll()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var sepet = _sepetService.SepetAndProducts(user.Id);
                    if (sepet != null)
                    {
                        _sepetService.Delete(sepet);
                        return RedirectToAction("CartIndex", "Cart");
                    }
                }
            }

            var cart = GetCart();
            cart.RemoveProductAll();
            SaveCart(cart);

            return RedirectToAction("CartIndex", "Cart");
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }


        // SEPET METOTLARI ------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> CartItemNumber(SepetModel model, int quantity = 1)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var sepet = _sepetService.SepetAndProducts(user.Id);
                    if (sepet == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    var sepetLine = _sepetLineService.SepetLineAndProduct(model.SepetLineId);
                    if (sepetLine == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    sepetLine.ProductQuantity = model.ProductQuantity;
                    _sepetLineService.Update(sepetLine);

                    var sepet1 = _sepetService.SepetAndProducts(user.Id);

                    var prices = new List<double>();
                    foreach (var sepetline in sepet1.SepetLines)
                    {
                        if (sepetline.ProductSizeId == 0)
                        {
                            prices.Add(sepetline.Product.ProductPrice * sepetline.ProductQuantity);
                        } else
                        {
                            var sizePrice = sepetline.Product.ProductSizes.Where(i => i.ProductSizeId == sepetline.ProductSizeId).FirstOrDefault().ProductSizePrice;
                            prices.Add(sizePrice * sepetline.ProductQuantity);
                        }
                    }

                    var price = prices.Sum(i => i);

                    sepet1.SiparisToplam = price;
                    sepet1.GenelToplam = price;
                    _sepetService.Update(sepet1);
                    
                    return RedirectToAction("CartIndex", "Cart");
                }
            }
            
            var product = _productService.ProductAndProductSizesAndSize(model.ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.ProductQuantity(product, model.ProductQuantity, model.ProductSizeId);
                SaveCart(cart);
            }

            return RedirectToAction("CartIndex", "Cart");
        }

        public async Task<IActionResult> CartIndex(SepetModel model3, string giftCardTitle)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var sepet3 = _sepetService.SepetAndProducts(user.Id);
                    if (sepet3 != null)
                    {
                        // Stoğu tükenen ve onaylı olmayan ürünlerin sepetten çıkarılması
                        foreach (var sepetLine in sepet3.SepetLines)
                        {
                            if (sepetLine.Product.ProductApproval == false)
                            {
                                _sepetLineService.Delete(sepetLine);

                                if (_sepetService.SepetAndProducts(user.Id).SepetLines.Count() == 0)
                                {
                                    _sepetService.Delete(sepet3);
                                }
                                
                                TempData["iconOK"] = "warning";
                                TempData["iconText"] = "Stoğu tükenen ürünler sepetinizden çıkarılmıştır.";
                                return RedirectToAction("CartIndex", "Cart");
                            }
                        }

                        var kargo = _cargoService.GetAll().Where(i => i.CargoApproval).FirstOrDefault();

                        var sepet = _sepetService.SepetAndProducts(user.Id);
                        sepet.GiftCardTitle = "";
                        var prices = new List<double>();
                        var kdv = new List<double>();
                        foreach (var sepetline in sepet.SepetLines)
                        {
                            sepetline.ProductPrice = 0;
                            sepetline.ProductCampaignPrice = 0;
                            _sepetLineService.Update(sepetline);

                            if (sepetline.ProductSizeId != 0)
                            { // Ürün beden bilgisi varsa

                                // Ürün beden'i aldık
                                var sizeLineProduct = sepetline.Product.ProductSizes.Where(i => i.ProductSizeId == sepetline.ProductSizeId).FirstOrDefault();
                                if (sizeLineProduct != null)
                                {
                                    // Girilen stok, ürün stoğundan fazla ise, sepetteki stoğu, ürün stoğu ile güncelledik.
                                    if (sizeLineProduct.ProductSizeStock < sepetline.ProductQuantity)
                                    {
                                        sepetline.ProductQuantity = sizeLineProduct.ProductSizeStock;
                                    }

                                    // Ürün beden fiyat bilgisi yoksa, ana fiyatı aldık. Varsa, ürün beden fiyatını aldık.
                                    var productSizePrice = sizeLineProduct.ProductSizePrice;
                                    if (productSizePrice != 0)
                                    { // Ürün beden fiyat bilgisi varsa aldık
                                        sepetline.ProductPrice = sizeLineProduct.ProductSizePrice;
                                        prices.Add(productSizePrice * sepetline.ProductQuantity);

                                        // Kdv
                                        sepetline.ProductKdv = ((sizeLineProduct.ProductSizePrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                        kdv.Add(sepetline.ProductKdv);
                                    } else
                                    { // Ürün beden fiyat bilgisi yoksa ürün ana fiyatına geçtik
                                        if (sepetline.Product.ProductSalePrice == 0)
                                        { // Ürün ana fiyatında indirim fiyatı varsa aldık, yoksa, ana fiyatı aldık
                                            sepetline.ProductPrice = sepetline.Product.ProductPrice;
                                            prices.Add(sepetline.Product.ProductPrice * sepetline.ProductQuantity);

                                            // Kdv
                                            sepetline.ProductPrice = ((sepetline.Product.ProductPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                            kdv.Add(sepetline.ProductKdv);
                                        } else
                                        {
                                            sepetline.ProductPrice = sepetline.Product.ProductSalePrice;
                                            prices.Add(sepetline.Product.ProductSalePrice * sepetline.ProductQuantity);

                                            // Kdv
                                            sepetline.ProductKdv = ((sepetline.Product.ProductPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                            kdv.Add(sepetline.ProductKdv);
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    var silinenUrun = _sepetLineService.GetAll().Where(i => i.ProductSizeId == sepetline.ProductSizeId).FirstOrDefault();
                                    _sepetLineService.Delete(silinenUrun);

                                    TempData["iconOK"] = "warning";
                                    TempData["iconText"] = "Stoğu tükenen ürünler sepetinizden çıkarılmıştır.";
                                    return RedirectToAction("CartIndex", "Cart");
                                }
                                _sepetLineService.Update(sepetline);
                            } else
                            { // ProductSizeId 0 ise, ürünün bedeni yoktur.
                                if (sepetline.Product.ProductStock < sepetline.ProductQuantity)
                                { // sepetteki ürünün stoğu, sepete eklenmek istenen stok adedinden küçük ise, ürün stok miktarını, sepet miktarına eşitleriz.
                                    sepetline.ProductQuantity = sepetline.Product.ProductStock;
                                }

                                if (sepetline.Product.ProductSalePrice == 0)
                                { // Ürün ana fiyatında indirim fiyatı varsa aldık, yoksa, ana fiyatı aldık
                                    sepetline.ProductPrice = sepetline.Product.ProductPrice;
                                    prices.Add(sepetline.Product.ProductPrice * sepetline.ProductQuantity);

                                    // Kdv
                                    sepetline.ProductKdv = ((sepetline.Product.ProductPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                    kdv.Add(sepetline.ProductKdv);
                                } else
                                {
                                    sepetline.ProductPrice = sepetline.Product.ProductSalePrice;
                                    prices.Add(sepetline.Product.ProductSalePrice * sepetline.ProductQuantity);

                                    // Kdv
                                    sepetline.ProductKdv = ((sepetline.Product.ProductSalePrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                    kdv.Add(sepetline.ProductKdv);
                                }

                                _sepetLineService.Update(sepetline);
                            }
                        }
                        var price = prices.Sum(i => i);
                        sepet.SiparisToplam = price;

                        // Kdv
                        var kdvPrice = kdv.Sum(i => i);
                        sepet.SiparisKdv = kdvPrice;
                        
                        if (price >= kargo.CargoFreePrice )
                        {
                            sepet.GenelToplam = price;
                            sepet.CargoPrice = 0;
                        } else
                        {
                            sepet.GenelToplam = price + kargo.CargoPrice;
                            sepet.CargoPrice = kargo.CargoPrice;
                        }
                        _sepetService.Update(sepet);

                        //HEDİYE ÇEKİ İŞLEMİ -----------------------------------------------
                        if (!string.IsNullOrEmpty(giftCardTitle))
                        {
                            var sepet4 = _sepetService.SepetAndProducts(user.Id);
                            var pricesGiftCard = new List<double>();
                            var kdvGiftCard = new List<double>();

                            var giftCard = _giftCardService.GiftCardAndUser(giftCardTitle);
                            if (giftCard.GiftCardLimit == 0)
                            {
                                ModelState.AddModelError("giftCardTitle", "Kullanım hakkı dolmuştur.");
                            } else
                            {
                                if (giftCard != null)
                                {
                                    if (giftCard.GiftCardUsers.Any(i => i.ProjeUserId == user.Id) || giftCard.GiftCardUsers.Count() == 0)
                                    {
                                        if (giftCard.GiftCardOran > 0)
                                        { // Hediye çeki oranı sıfırdan büyük ise, oransal indirim vardır.
                                            
                                            foreach (var sepetline in sepet4.SepetLines)
                                            {
                                                if (sepetline.ProductSizeId == 0)
                                                { // ProductSizeId 0 ise, ürünün bedeni yoktur.
                                                    if (sepetline.Product.ProductSalePrice != 0)
                                                    {
                                                        var newPrice = sepetline.Product.ProductSalePrice - ((sepetline.Product.ProductSalePrice * giftCard.GiftCardOran) / 100);

                                                        sepetline.ProductCampaignPrice = newPrice;

                                                        pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                        // Kdv
                                                        sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                        kdvGiftCard.Add(sepetline.ProductKdv);

                                                        _sepetLineService.Update(sepetline);
                                                    } else
                                                    {
                                                        var newPrice = sepetline.Product.ProductPrice - ((sepetline.Product.ProductPrice * giftCard.GiftCardOran) / 100);

                                                        sepetline.ProductCampaignPrice = newPrice;

                                                        pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                        // Kdv
                                                        sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                        kdvGiftCard.Add(sepetline.ProductKdv);

                                                        _sepetLineService.Update(sepetline);
                                                    }
                                                } else
                                                {   // Ürün bedeni var ise
                                                    // Ürün beden'i aldık
                                                    var sizeLineProduct = sepetline.Product.ProductSizes.Where(i => i.ProductSizeId == sepetline.ProductSizeId).FirstOrDefault();

                                                    var productSizePrice = sizeLineProduct.ProductSizePrice;
                                                    if (productSizePrice != 0)
                                                    {   // Ürün bedenine fiyat girilmişse ürün beden fiyatından işlem yaparız.
                                                        var newPrice = productSizePrice - ((productSizePrice * giftCard.GiftCardOran) / 100);
                                                        
                                                        sepetline.ProductCampaignPrice = newPrice;

                                                        pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                        // Kdv
                                                        sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                        kdvGiftCard.Add(sepetline.ProductKdv);

                                                        _sepetLineService.Update(sepetline);
                                                    } else
                                                    {   // ProductLine'a fiyat girilmemişse Product fiyatından işlem yaparız.
                                                        if (sepetline.Product.ProductSalePrice != 0)
                                                        {
                                                            var newPrice = sepetline.Product.ProductSalePrice - ((sepetline.Product.ProductSalePrice * giftCard.GiftCardOran) / 100);

                                                            sepetline.ProductCampaignPrice = newPrice;

                                                            pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                            // Kdv
                                                            sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;   
                                                            kdvGiftCard.Add(sepetline.ProductKdv);

                                                            _sepetLineService.Update(sepetline);
                                                        } else
                                                        {
                                                            var newPrice = sepetline.Product.ProductPrice - ((sepetline.Product.ProductPrice * giftCard.GiftCardOran) / 100);

                                                            sepetline.ProductCampaignPrice = newPrice;

                                                            pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                            // Kdv
                                                            sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                            kdvGiftCard.Add(sepetline.ProductKdv);

                                                            _sepetLineService.Update(sepetline);
                                                        }
                                                    }
                                                }
                                            }
                                            
                                        } else
                                        { // Hediye çeki oranı 0'dan büyük değilse, miktar olarak indirim yapıyordur.

                                            foreach (var sepetline in sepet4.SepetLines)
                                            {
                                                if (sepetline.ProductSizeId == 0)
                                                { // ProductSizeId 0 ise, ürünün bedeni yoktur.

                                                    // Hediye çeki miktarının, ürün başı yüzde kaçına tekabül edeceğini buluyoruz.
                                                    var urunBasiYuzdeIndirim = giftCard.GiftCardMiktar / (sepet4.SiparisToplam / 100);

                                                    if (sepetline.Product.ProductSalePrice != 0)
                                                    { // Ürün bedeni olmadığından, indirimli fiyatı varsa indirimli fiyattan işlem yapıyoruz. İndirimli fiyatı yoksa, ana fiyattan işlem yapıyoruz.
                                                        var newPrice = sepetline.Product.ProductSalePrice - ((sepetline.Product.ProductSalePrice * urunBasiYuzdeIndirim) / 100);

                                                        sepetline.ProductCampaignPrice = newPrice;

                                                        pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                        // Kdv
                                                        sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                        kdvGiftCard.Add(sepetline.ProductKdv);

                                                        _sepetLineService.Update(sepetline);
                                                    } else
                                                    {
                                                        var newPrice = sepetline.Product.ProductPrice - ((sepetline.Product.ProductPrice * urunBasiYuzdeIndirim) / 100);

                                                        sepetline.ProductCampaignPrice = newPrice;

                                                        pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                        // Kdv
                                                        sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                        kdvGiftCard.Add(sepetline.ProductKdv);

                                                        _sepetLineService.Update(sepetline);
                                                    }
                                                } else
                                                { // Ürün bedeni varsa
                                                    // Hediye çeki miktarının, ürün başı yüzde kaçına tekabül edeceğini buluyoruz.
                                                    var urunBasiYuzdeIndirim = giftCard.GiftCardMiktar / (sepet4.SiparisToplam / 100);

                                                    // Ürün bedenini aldık
                                                    var sizeLineProduct = sepetline.Product.ProductSizes.Where(i => i.ProductSizeId == sepetline.ProductSizeId).FirstOrDefault();

                                                    if (sizeLineProduct.ProductSizePrice != 0)
                                                    {   // Ürün beden bilgisine fiyat girilmişse, beden fiyatını alırız.
                                                        var newPrice = sizeLineProduct.ProductSizePrice - ((sizeLineProduct.ProductSizePrice * urunBasiYuzdeIndirim) / 100);
                                                        
                                                        sepetline.ProductCampaignPrice = newPrice;

                                                        pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);
                                                        
                                                        // Kdv
                                                        sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                        kdvGiftCard.Add(sepetline.ProductKdv);

                                                        _sepetLineService.Update(sepetline);
                                                    } else
                                                    { // Ürün beden bilgisine fiyat girilmemişse, ürün ana fiyatlarını alırız.

                                                        if (sepetline.Product.ProductSalePrice != 0)
                                                        { // Ürün bedeni olmadığından, indirimli fiyatı varsa indirimli fiyattan işlem yapıyoruz. İndirimli fiyatı yoksa, ana fiyattan işlem yapıyoruz.
                                                            var newPrice = sepetline.Product.ProductSalePrice - ((sepetline.Product.ProductSalePrice * urunBasiYuzdeIndirim) / 100);

                                                            sepetline.ProductCampaignPrice = newPrice;

                                                            pricesGiftCard.Add(newPrice * sepetline.ProductQuantity);

                                                            // Kdv
                                                            sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                            kdvGiftCard.Add(sepetline.ProductKdv);

                                                            _sepetLineService.Update(sepetline);
                                                        } else
                                                        {
                                                            var newPrice = sepetline.Product.ProductPrice - ((sepetline.Product.ProductPrice * urunBasiYuzdeIndirim) / 100);

                                                            sepetline.ProductCampaignPrice = newPrice;

                                                            pricesGiftCard.Add(newPrice * sepetline.ProductQuantity); 

                                                            // Kdv
                                                            sepetline.ProductKdv = ((newPrice / 100) * sepetline.ProductQuantity) * sepetline.Product.ProductKdv;
                                                            kdvGiftCard.Add(sepetline.ProductKdv);

                                                            _sepetLineService.Update(sepetline);
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                        sepet4.GiftCardTitle = giftCard.GiftCardTitle;

                                        if (giftCard.GiftCardMiktar != 0 )
                                        {   
                                            sepet4.GiftCardContent = giftCard.GiftCardMiktar.ToString("c") + " uygulandı";
                                        }if (giftCard.GiftCardOran != 0 )
                                        {
                                            sepet4.GiftCardContent = "%" + giftCard.GiftCardOran.ToString() + " uygulandı";
                                        }
                                        
                                        var priceGiftCard = pricesGiftCard.Sum(i => i);

                                        // Kdv
                                        var kdvPriceGift = kdvGiftCard.Sum(i => i);
                                        sepet4.SiparisKdv = kdvPriceGift;
                                        
                                        if (priceGiftCard >= kargo.CargoFreePrice )
                                        {
                                            sepet4.GenelToplam = priceGiftCard;
                                            sepet4.CargoPrice = 0;
                                        } else
                                        {
                                            sepet4.GenelToplam = priceGiftCard + kargo.CargoPrice;
                                            sepet4.CargoPrice = kargo.CargoPrice;
                                        }
                                        _sepetService.Update(sepet4);
                                    }
                                } else
                                {
                                    ModelState.AddModelError("giftCardTitle", "Hediye çeki bulunamadı.");
                                }
                            }
                        }

                        var sepet5 = _sepetService.SepetAndProducts(user.Id);
                        var model = new SepetModel()
                        {
                            Sepet = sepet5,
                            CartGet = null
                        };
                        return View(model);
                    }
                    
                    // Sepet null ise, Sepet'e boş sepet göndeririz.
                    var model1 = new SepetModel()
                    {
                        Sepet = new Sepet(){
                            SepetLines = new List<SepetLine>(){}
                        },
                        CartGet = null
                    };
                    return View(model1);
                }
            }

            foreach (var item in GetCart().Product)
            {
                var product = _productService.GetById(item.Product.ProductId);
                if (product.ProductApproval == false)
                {
                    var cart = GetCart();
                    cart.RemoveProductId(product.ProductId);
                    SaveCart(cart);

                    TempData["iconOK"] = "warning";
                    TempData["iconText"] = "Stoğu tükenen ürünler sepetinizden çıkarılmıştır.";
                }
            }

            var model2 = new SepetModel()
            {
                CartGet = GetCart(),
                Sepet = null
            };
            return View(model2);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CartAdres()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var sepet = _sepetService.SepetAndProducts(user.Id);
                    if (sepet != null)
                    {
                        var model = new CartAdresModel()
                        {
                            Adreses = _adresService.GetAll().Where(i => i.ProjeUserId == user.Id).OrderByDescending(i => i.AdresId).ToList(),
                            SeciliAdresId = user.SeciliAdresId
                        };
                        return View(model);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CartAdres(CartAdresModel model)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (model.AdresId > 0)
                    {
                        var userAdres = _adresService.GetAll().Where(i => i.ProjeUserId == user.Id && i.AdresId == model.AdresId).FirstOrDefault();
                        
                        if (userAdres != null)
                        {                            
                            user.SeciliAdresId = model.AdresId;
                            if (model.AdresFatura)
                            {
                                user.SeciliAdresIdFatura = model.AdresIdFatura;
                            } else {
                                user.SeciliAdresIdFatura = model.AdresId;
                            }
                            
                            await _userManager.UpdateAsync(user);
                            return RedirectToAction("Odeme", "Cart");
                        }
                    }
                    // adres seçin
                    return RedirectToAction("CartAdres", "Cart");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Odeme()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var sepet = _sepetService.GetAll().Where(i => i.ProjeUserId == user.Id).FirstOrDefault();
                    if (sepet != null)
                    {
                        var model = new CreditCardModel()
                        {
                            SiparisToplam = sepet.SiparisToplam,
                            GenelToplam = sepet.GenelToplam,
                            BankAccounts = _bankAccountService.GetAll()
                        };
                        return View(model);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Odeme(CreditCardModel model)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var sepet = _sepetService.SepetAndProducts(user.Id);
                    if (sepet != null)
                    {
                        var prices = new List<double>();
                        foreach (var sepetline in sepet.SepetLines)
                        {
                            if (sepetline.ProductSizeId == 0)
                            { // ProductSizeId 0 ise, ürünün bedeni yoktur.
                                if (sepetline.Product.ProductStock < sepetline.ProductQuantity)
                                {   // Ürün stoğu, sepetteki miktardan az ise, ürün stoğunda azalma olmuştur.
                                    sepetline.ProductQuantity = sepetline.Product.ProductStock;
                                    TempData["iconOK"] = "warning";
                                    TempData["iconText"] = $"Sepetinizdeki {sepetline.Product.ProductName} ürünün stoğunda değişiklik olmuştur. Lütfen sepetinizi kontrol edip tekrar deneyiniz.";
                                    return RedirectToAction("CartIndex", "Cart");
                                }

                                if (sepetline.Product.ProductSalePrice != 0)
                                {
                                    prices.Add(sepetline.Product.ProductSalePrice * sepetline.ProductQuantity);
                                } else
                                {
                                    prices.Add(sepetline.Product.ProductPrice * sepetline.ProductQuantity);
                                }
                            } else
                            {
                                // Ürün bedenini aldık
                                var sizeLineProduct = sepetline.Product.ProductSizes.Where(i => i.ProductSizeId == sepetline.ProductSizeId).FirstOrDefault();

                                if (sizeLineProduct != null)
                                {
                                    // Girilen stok, ürün stoğundan fazla ise, ürün stoğunu, sepetteki ürün stoğu olarak güncelledik
                                    if (sizeLineProduct.ProductSizeStock < sepetline.ProductQuantity)
                                    {
                                        sepetline.ProductQuantity = sizeLineProduct.ProductSizeStock;
                                        TempData["iconOK"] = "warning";
                                        TempData["iconText"] = $"Sepetinizdeki {sepetline.Product.ProductName} ürünün stoğunda değişiklik olmuştur. Lütfen sepetinizi kontrol edip tekrar deneyiniz.";
                                        return RedirectToAction("CartIndex", "Cart");
                                    }
                                    
                                    // Ürün bedeni fiyat bilgisi varsa beden fiyatını, beden fiyatı yoksa ana fiyatı aldık.
                                    var productSizePrice = sizeLineProduct.ProductSizePrice;
                                    if (productSizePrice != 0)
                                    {
                                        prices.Add(productSizePrice * sepetline.ProductQuantity);
                                    } else
                                    {
                                        if (sepetline.Product.ProductSalePrice != 0)
                                        {
                                            prices.Add(sepetline.Product.ProductSalePrice * sepetline.ProductQuantity);
                                        } else
                                        {
                                            prices.Add(sepetline.Product.ProductPrice * sepetline.ProductQuantity);
                                        }
                                    }
                                }
                                else
                                {
                                    var silinenUrun = _sepetLineService.GetAll().Where(i => i.ProductSizeId == sepetline.ProductSizeId).FirstOrDefault();
                                    _sepetLineService.Delete(silinenUrun);
                                    
                                    TempData["iconOK"] = "warning";
                                    TempData["iconText"] = "Stoğu tükenen ürünler sepetinizden çıkarılmıştır. Lütfen sepetinizi kontrol edip tekrar ilerleyiniz.";
                                    return RedirectToAction("CartIndex", "Cart");
                                }
                            }
                        }
                        var price = prices.Sum(i => i);
                        
                        if (price != sepet.SiparisToplam)
                        {
                            TempData["iconOK"] = "warning";
                            TempData["iconText"] = "Sepetinizdeki ürünlerin fiyat/kampanya bilgisinde değişiklik yaşandığından ödeme ALINAMADI. Lütfen sepetinizi kontrol edip tekrar deneyiniz.";
                            return RedirectToAction("CartIndex", "Cart");
                        }

                        if (model.PaymentType == "EftHavale")
                        {
                            SaveOrderEftHavale(sepet, user);

                            TempData["icon"] = "success";
                            TempData["text"] = "Siparişiniz başarıyla alınmıştır.";
                            return RedirectToAction("Index", "Home");
                        }

                        if (ModelState.IsValid)
                        {
                            var payment = PaymentProcess(model, sepet, user);
                            if (payment.Status == "success")
                            {
                                SaveOrderCreditCard(sepet, payment, user);

                                TempData["icon"] = "success";
                                TempData["text"] = "Siparişiniz başarıyla alınmıştır.";
                                return RedirectToAction("Index", "Home");
                            } else
                            {
                                Console.WriteLine(payment.ErrorMessage);
                                Console.WriteLine(payment.ErrorCode);
                            }
                        }
                        model.SiparisToplam = sepet.SiparisToplam;
                        model.GenelToplam = sepet.GenelToplam;
                        model.BankAccounts = _bankAccountService.GetAll();
                        // return RedirectToAction("Index", "Home");
                        return View(model);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        private void SaveOrderEftHavale(Sepet sepet, ProjeUser user)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            foreach (var sepetLine in sepet.SepetLines)
            {
                if (sepetLine.ProductSizeId != 0)
                {
                    // Stok düşer
                    var productSize = sepetLine.Product.ProductSizes.Where(i => i.ProductSizeId == sepetLine.ProductSizeId).FirstOrDefault();
                    var entity = new ProductSize()
                    {
                        ProductSizeId = productSize.ProductSizeId,
                        ProductSizePrice = productSize.ProductSizePrice,
                        ProductSizeStock = productSize.ProductSizeStock - sepetLine.ProductQuantity,
                        SizeId = productSize.SizeId,
                        ProductId = productSize.ProductId

                    };
                    _productSizeService.Update(entity);
                    
                    var orderLine = new OrderLine() {
                        ProductId = sepetLine.ProductId,
                        ProductCode = sepetLine.Product.ProductCode,
                        ProductName = sepetLine.Product.ProductName,
                        ProductImage = sepetLine.Product.ProductImage,
                        ProductUrl = sepetLine.Product.ProductUrl,
                        OrderLineQuantity = sepetLine.ProductQuantity,
                        IadeEdilebilirAdet = sepetLine.ProductQuantity,
                        OrderLineProductPrice = sepetLine.ProductPrice,
                        OrderLineCampaignPrice = sepetLine.ProductCampaignPrice,
                        OrderLineKdv = sepetLine.ProductKdv,
                        ProductSize = sepetLine.Product.ProductSizes.Where(i => i.ProductSizeId == sepetLine.ProductSizeId).FirstOrDefault().Size.SizeWrite
                    };
                    orderLines.Add(orderLine);
                } else
                {
                    // Stok düşer
                    var product = sepetLine.Product;
                    var entity = new Product()
                    {
                        ProductId = product.ProductId,
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName,
                        ProductShortName = product.ProductShortName,
                        ProductColor = product.ProductColor,
                        ProductStock = product.ProductStock - sepetLine.ProductQuantity,
                        ProductKdv = product.ProductKdv,
                        ProductPrice = product.ProductPrice,
                        ProductSalePrice = product.ProductSalePrice,
                        ProductUrl = product.ProductUrl,
                        ProductImage = product.ProductImage,
                        ProductApproval = product.ProductApproval,
                        ProductSort = product.ProductSort,
                        ProductNew = product.ProductNew,
                        ProductSale = product.ProductSale,
                        ProductSeoTitle = product.ProductSeoTitle,
                        ProductSeoDescription = product.ProductSeoDescription,
                        ProductSeoKeyword = product.ProductSeoKeyword                        
                    };
                    _productService.Update(entity);

                    var orderLine = new OrderLine() {
                        ProductId = sepetLine.ProductId,
                        ProductCode = sepetLine.Product.ProductCode,
                        ProductName = sepetLine.Product.ProductName,
                        ProductImage = sepetLine.Product.ProductImage,
                        ProductUrl = sepetLine.Product.ProductUrl,
                        OrderLineQuantity = sepetLine.ProductQuantity,
                        IadeEdilebilirAdet = sepetLine.ProductQuantity,
                        OrderLineProductPrice = sepetLine.ProductPrice,
                        OrderLineCampaignPrice = sepetLine.ProductCampaignPrice,
                        OrderLineKdv = sepetLine.ProductKdv,
                        ProductSize = ""
                    };
                    orderLines.Add(orderLine);
                }
            }
            // Adres bilgisini, sabit adres tablosuna ekliyoruz
            var adres = _adresService.GetById(user.SeciliAdresId);
            if (adres == null)
            {
                
            }
            var orderAdres = new OrderAdres() {
                OrderAdresTitle = adres.AdresTitle,
                OrderAdresFaturaType = adres.AdresFaturaType,
                OrderAdresNameSurname = adres.AdresNameSurname,
                OrderAdresPhoneNumber = adres.AdresPhoneNumber,
                OrderAdresContent = adres.AdresContent,
                OrderAdresTcNo = adres.AdresTcNo,
                OrderAdresCounty = adres.AdresCounty,
                OrderAdresCity = adres.AdresCity,
                OrderAdresPostCode = adres.AdresPostCode

            };
            var adresFatura = _adresService.GetById(user.SeciliAdresIdFatura);
            if (adresFatura == null)
            {
                
            }
            var orderAdresFatura = new OrderAdres() {
                OrderAdresTitle = adresFatura.AdresTitle,
                OrderAdresFaturaType = adresFatura.AdresFaturaType,
                OrderAdresNameSurname = adresFatura.AdresNameSurname,
                OrderAdresPhoneNumber = adresFatura.AdresPhoneNumber,
                OrderAdresContent = adresFatura.AdresContent,
                OrderAdresTcNo = adresFatura.AdresTcNo,
                OrderAdresCounty = adresFatura.AdresCounty,
                OrderAdresCity = adresFatura.AdresCity,
                OrderAdresPostCode = adresFatura.AdresPostCode
            };
            
            if (!string.IsNullOrEmpty(sepet.GiftCardTitle))
            {
                var giftCard = _giftCardService.GetGiftCardName(sepet.GiftCardTitle);
                giftCard.GiftCardLimit = giftCard.GiftCardLimit - 1;
                _giftCardService.Update(giftCard);
            }
            
            var order = new Order() {
                OrderAndAdresJuncs = new List<OrderAndAdresJunc> {
                    new OrderAndAdresJunc() {
                        OrderAdres = orderAdres
                    },
                    new OrderAndAdresJunc() {
                        OrderAdres = orderAdresFatura
                    }
                },
                ProjeUserId = user.Id,
                OrderNumber = "A" + (new Random()).Next(111111,999999).ToString(),
                OrderTotalPrice = sepet.SiparisToplam,
                OrderGenelPrice = sepet.GenelToplam,
                OrderGiftCard = sepet.GiftCardTitle,
                CargoPrice = sepet.CargoPrice,
                OrderKdv = sepet.SiparisKdv,
                OrderDateTime = DateTime.Now,
                OrderState = "Ödeme Bekliyor",
                OrderPaymentType = "Eft/Havale",
                // OrderPaymentId = payment.PaymentId,
                // OrderConversationId = payment.ConversationId,
                OrderLines = orderLines
            };
            _orderService.Create(order);

            _sepetService.Delete(sepet);
        }

        private void SaveOrderCreditCard(Sepet sepet, Payment payment, ProjeUser user)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            foreach (var sepetLine in sepet.SepetLines)
            {
                if (sepetLine.ProductSizeId != 0)
                {
                    // Stok düşer
                    var productSize = sepetLine.Product.ProductSizes.Where(i => i.ProductSizeId == sepetLine.ProductSizeId).FirstOrDefault();
                    var entity = new ProductSize()
                    {
                        ProductSizeId = productSize.ProductSizeId,
                        ProductSizePrice = productSize.ProductSizePrice,
                        ProductSizeStock = productSize.ProductSizeStock - sepetLine.ProductQuantity,
                        SizeId = productSize.SizeId,
                        ProductId = productSize.ProductId

                    };
                    _productSizeService.Update(entity);

                    var orderLine = new OrderLine() {
                        ProductId = sepetLine.ProductId,
                        ProductCode = sepetLine.Product.ProductCode,
                        ProductName = sepetLine.Product.ProductName,
                        ProductImage = sepetLine.Product.ProductImage,
                        ProductUrl = sepetLine.Product.ProductUrl,
                        OrderLineQuantity = sepetLine.ProductQuantity,
                        IadeEdilebilirAdet = sepetLine.ProductQuantity,
                        OrderLineProductPrice = sepetLine.ProductPrice,
                        OrderLineCampaignPrice = sepetLine.ProductCampaignPrice,
                        OrderLineKdv = sepetLine.ProductKdv,
                        ProductSize = sepetLine.Product.ProductSizes.Where(i => i.ProductSizeId == sepetLine.ProductSizeId).FirstOrDefault().Size.SizeWrite
                    };
                    orderLines.Add(orderLine);
                } else
                {
                    // Stok düşer
                    var product = sepetLine.Product;
                    var entity = new Product()
                    {
                        ProductId = product.ProductId,
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName,
                        ProductShortName = product.ProductShortName,
                        ProductColor = product.ProductColor,
                        ProductStock = product.ProductStock - sepetLine.ProductQuantity,
                        ProductKdv = product.ProductKdv,
                        ProductPrice = product.ProductPrice,
                        ProductSalePrice = product.ProductSalePrice,
                        ProductUrl = product.ProductUrl,
                        ProductImage = product.ProductImage,
                        ProductApproval = product.ProductApproval,
                        ProductSort = product.ProductSort,
                        ProductNew = product.ProductNew,
                        ProductSale = product.ProductSale,
                        ProductSeoTitle = product.ProductSeoTitle,
                        ProductSeoDescription = product.ProductSeoDescription,
                        ProductSeoKeyword = product.ProductSeoKeyword                        
                    };
                    _productService.Update(entity);
                    
                    var orderLine = new OrderLine() {
                        ProductId = sepetLine.ProductId,
                        ProductCode = sepetLine.Product.ProductCode,
                        ProductName = sepetLine.Product.ProductName,
                        ProductImage = sepetLine.Product.ProductImage,
                        ProductUrl = sepetLine.Product.ProductUrl,
                        OrderLineQuantity = sepetLine.ProductQuantity,
                        IadeEdilebilirAdet = sepetLine.ProductQuantity,
                        OrderLineProductPrice = sepetLine.ProductPrice,
                        OrderLineCampaignPrice = sepetLine.ProductCampaignPrice,
                        OrderLineKdv = sepetLine.ProductKdv,
                        ProductSize = ""
                    };
                    orderLines.Add(orderLine);
                }
            }

            // Adres bilgisini, sabit adres tablosuna ekliyoruz
            var adres = _adresService.GetById(user.SeciliAdresId);
            if (adres == null)
            {
                
            }
            var orderAdres = new OrderAdres() {
                OrderAdresTitle = adres.AdresTitle,
                OrderAdresFaturaType = adres.AdresFaturaType,
                OrderAdresNameSurname = adres.AdresNameSurname,
                OrderAdresPhoneNumber = adres.AdresPhoneNumber,
                OrderAdresContent = adres.AdresContent,
                OrderAdresTcNo = adres.AdresTcNo,
                OrderAdresCounty = adres.AdresCounty,
                OrderAdresCity = adres.AdresCity,
                OrderAdresPostCode = adres.AdresPostCode

            };
            var adresFatura = _adresService.GetById(user.SeciliAdresIdFatura);
            if (adresFatura == null)
            {
                
            }
            var orderAdresFatura = new OrderAdres() {
                OrderAdresTitle = adresFatura.AdresTitle,
                OrderAdresFaturaType = adresFatura.AdresFaturaType,
                OrderAdresNameSurname = adresFatura.AdresNameSurname,
                OrderAdresPhoneNumber = adresFatura.AdresPhoneNumber,
                OrderAdresContent = adresFatura.AdresContent,
                OrderAdresTcNo = adresFatura.AdresTcNo,
                OrderAdresCounty = adresFatura.AdresCounty,
                OrderAdresCity = adresFatura.AdresCity,
                OrderAdresPostCode = adresFatura.AdresPostCode

            };
            
            if (!string.IsNullOrEmpty(sepet.GiftCardTitle))
            {
                var giftCard = _giftCardService.GetGiftCardName(sepet.GiftCardTitle);
                giftCard.GiftCardLimit = giftCard.GiftCardLimit - 1;
                _giftCardService.Update(giftCard);
            }

            var order = new Order() {
                OrderAndAdresJuncs = new List<OrderAndAdresJunc> {
                    new OrderAndAdresJunc() {
                        OrderAdres = orderAdres
                    },
                    new OrderAndAdresJunc() {
                        OrderAdres = orderAdresFatura
                    }
                },
                ProjeUserId = user.Id,
                OrderNumber = "A" + (new Random()).Next(111111,999999).ToString(),
                OrderTotalPrice = sepet.SiparisToplam,
                OrderGenelPrice = sepet.GenelToplam,
                OrderGiftCard = sepet.GiftCardTitle,
                CargoPrice = sepet.CargoPrice,
                OrderKdv = sepet.SiparisKdv,
                OrderDateTime = DateTime.Now,
                OrderState = "Sipariş Alındı",
                OrderPaymentType = "Kredi Kartı",
                OrderPaymentId = payment.PaymentId,
                OrderConversationId = payment.ConversationId,
                OrderLines = orderLines
            };
            _orderService.Create(order);

            _sepetService.Delete(sepet);
        }

        private Payment PaymentProcess(CreditCardModel model, Sepet sepet, ProjeUser user)
        {
            // Bu bölümde fiyatları virgül ile kabul etmediğinden, nokta ile Replace ettik.

            Options options = new Options();
            options.ApiKey = "sandbox-QWClrRiK94pnbIvzEJt5x77A0cZPVygs";
            options.SecretKey = "sandbox-bpZwtFQWHp44nIlFnnj2P0j2cggtM1Y2";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = (new Random()).Next(111111111,999999999).ToString();
            request.Price = sepet.SiparisToplam.ToString().Replace(",",".");
            request.PaidPrice = sepet.SiparisToplam.ToString().Replace(",",".");
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            
            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CreditCardName;
            paymentCard.CardNumber = model.CreditCardNumber;
            paymentCard.ExpireMonth = model.CreditCardMonth;
            paymentCard.ExpireYear = "20" + model.CreditCardYear;
            paymentCard.Cvc = model.CreditCardCvc;
            // paymentCard.CardHolderName = "OĞUZHAN TURAN";
            // paymentCard.CardNumber = "5528790000000008";
            // paymentCard.ExpireMonth = "12";
            // paymentCard.ExpireYear = "2030";
            // paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            var adres = _adresService.GetById(user.SeciliAdresId);
            var faturaAdres = _adresService.GetById(user.SeciliAdresIdFatura);

            Buyer buyer = new Buyer();
            buyer.Id = user.Id.ToString();
            buyer.Name = user.UserAdi;
            buyer.Surname = user.UserSoyadi;
            buyer.GsmNumber = user.PhoneNumber;
            buyer.Email = user.Email;
            buyer.IdentityNumber = adres.AdresTcNo;
            // buyer.LastLoginDate = "2015-10-05 12:43:35";
            // buyer.RegistrationDate = "2015-10-05 12:43:35";
            buyer.RegistrationAddress = adres.AdresContent;
            // buyer.Ip = "85.34.78.112";
            buyer.City = adres.AdresCity;
            buyer.Country = "Turkey";
            // buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = adres.AdresNameSurname;
            shippingAddress.City = adres.AdresCity;
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = adres.AdresContent;
            shippingAddress.ZipCode = adres.AdresPostCode;
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = faturaAdres.AdresNameSurname;
            billingAddress.City = faturaAdres.AdresCity;
            billingAddress.Country = "Turkey";
            billingAddress.Description = faturaAdres.AdresContent;
            billingAddress.ZipCode = faturaAdres.AdresPostCode;
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            
            foreach (var sepetLine in sepet.SepetLines)
            {
                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = sepetLine.ProductId.ToString();
                firstBasketItem.Name = sepetLine.Product.ProductName;
                firstBasketItem.Category1 = "Kategori Adı";
                // firstBasketItem.Category2 = "Accessories";
                firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                // firstBasketItem.Price = "12";
                if (sepetLine.ProductSizeId != 0)
                { // Ürünün bedeni var ise
                    // Ürün bedenini aldık
                    var size = sepetLine.Product.ProductSizes.Where(i => i.ProductSizeId == sepetLine.ProductSizeId).FirstOrDefault();

                    if (size.ProductSizePrice != 0)
                    { // Ürün bedenine fiyat bilgisi girilmişse, beden fiyatını alırız
                        firstBasketItem.Price = (size.ProductSizePrice * sepetLine.ProductQuantity).ToString().Replace(",",".");
                    } else
                    { // Ürün bedenine fiyat bilgisi girilmemişse, ürün ana fiyatlarını alırız.
                        if (sepetLine.Product.ProductSalePrice != 0)
                        {
                            firstBasketItem.Price = (sepetLine.Product.ProductSalePrice * sepetLine.ProductQuantity).ToString().Replace(",",".");
                        } else
                        {
                            firstBasketItem.Price = (sepetLine.Product.ProductPrice * sepetLine.ProductQuantity).ToString().Replace(",",".");
                        }
                    }
                } else
                { // Ürünün bedeni yok ise ürün ana fiyatını alırız.
                    if (sepetLine.Product.ProductSalePrice != 0)
                    {
                        firstBasketItem.Price = (sepetLine.Product.ProductSalePrice * sepetLine.ProductQuantity).ToString().Replace(",",".");
                    } else
                    {
                        firstBasketItem.Price = (sepetLine.Product.ProductPrice * sepetLine.ProductQuantity).ToString().Replace(",",".");
                    }
                }
                
                basketItems.Add(firstBasketItem);
            }

            request.BasketItems = basketItems;
            
            // Payment payment =  Payment.Create(request, options);
            // if (payment.Status == "success")
            // {
            //     Console.WriteLine("ÖDEME BAŞARILI");
            // } else
            // {  
            //     Console.WriteLine("ÖDEME BAŞARISIZ");
            // }

            return Payment.Create(request, options);
        }
        
    }
}
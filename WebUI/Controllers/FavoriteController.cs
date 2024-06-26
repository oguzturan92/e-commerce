using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class FavoriteController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        FavoriteManager _favoriteService = new FavoriteManager(new FavoriteDal());
        ProductManager _productService = new ProductManager(new ProductDal());
        private UserManager<ProjeUser> _userManager;
        public FavoriteController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }

        // METOTLAR ------------------------------------------------------------
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> FavoriteList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var model = new FavoriteModel()
                {
                    Favorites = _favoriteService.UserIdyeGoreFavorilerVeProductlar(user.Id)
                };
                return View(model);
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [Authorize]
        public async Task<IActionResult> FavoriteDelete(int favoriId, int productId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var favori = _favoriteService.GetById(favoriId);
                if (favori != null)
                {
                    _favoriteService.FavoridenProductSil(favoriId, productId);
                }
                TempData["iconSuccess"] = "success";
                TempData["iconSuccessText"] = "Favori grubundan silindi.";
                return RedirectToAction("FavoriteList", "Favorite");
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [Authorize]
        public async Task<IActionResult> FavoriGroupDelete(int favoriId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var favori = _favoriteService.GetById(favoriId);
                if (favori != null)
                {
                    _favoriteService.Delete(favori);
                }
                TempData["iconSuccess"] = "success";
                TempData["iconSuccessText"] = "Favori grubu silindi.";
                return RedirectToAction("FavoriteList", "Favorite");
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        // FAVORİ EKLEME METOTLAR PRODUCT DETAIL ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> FavoriteDefaultAdnAdd(int proId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var userId = user.Id;
                var sorgula = _favoriteService.UserIdyeGoreDefaultFavorite(userId);
                if (sorgula != null)
                {
                    var id = sorgula.FavoriteId;
                    var favoriteProducts = new List<FavoriteProduct>() {
                        new FavoriteProduct() {
                            FavoriteId = id,
                            ProductId = proId
                        }
                    };
                    
                    if (!sorgula.FavoriteProducts.Select(i => i.ProductId == proId).FirstOrDefault())
                    {
                        _favoriteService.FavoriteAdd(id, favoriteProducts);
                    }
                    var sonuc = JsonConvert.SerializeObject(favoriteProducts);
                    return Json(sonuc);
                    // TempData["iconSuccess"] = "success";
                    // TempData["iconSuccessText"] = "Favori grubuna eklendi.";
                    // return RedirectToAction("ProductDetail", "Product", new { id = proId});
                } else
                {
                    var entity = new Favorite()
                    {
                        FavoriteTitle = "Favorilerim",
                        ProjeUserId = user.Id,
                        FavoriteProducts = new List<FavoriteProduct>(){
                            new FavoriteProduct() {
                                ProductId = proId}
                        }
                    };
                    _favoriteService.Create(entity);
                    var sonuc = JsonConvert.SerializeObject(entity);
                    return Json(sonuc);
                    // TempData["iconSuccess"] = "success";
                    // TempData["iconSuccessText"] = "Favori grubuna eklendi.";
                    // return RedirectToAction("ProductDetail", "Product", new { id = proId});
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpGet]
        public async Task<IActionResult> FavoriteCreateAndAdd(int proId, string favoriteName)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var product = _productService.GetById(proId);
                if (!string.IsNullOrEmpty(favoriteName))
                {
                    var favorite = _favoriteService.GetAll().Where(i => i.ProjeUserId == user.Id && i.FavoriteTitle.ToLower() == favoriteName.ToLower()).FirstOrDefault();
                    if (favorite == null)
                    {
                        var entity = new Favorite()
                        {
                            FavoriteTitle = favoriteName,
                            ProjeUserId = user.Id,
                            FavoriteProducts = new List<FavoriteProduct>(){
                                new FavoriteProduct() {
                                    ProductId = proId
                                }
                            }
                        };
                        _favoriteService.Create(entity);
                        var sonuc = JsonConvert.SerializeObject(entity);
                        return Json(sonuc);
                        // AJAX KULLANDIĞIMIZ İÇİN, BURDAN SONRAKİ RETURN VİEW'LER ÇALIŞMAZ
                        // TempData["iconSuccess"] = "success";
                        // TempData["iconSuccessText"] = "Favori grubuna eklendi.";
                        // return RedirectToAction("ProductDetail", "Product", new { id = proId});
                    }
                    TempData["iconError"] = "error";
                    TempData["iconErrorText"] = "Bu isimde bir favori grubuna zaten sahipsiniz.";
                    return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl});
                }
                TempData["iconError"] = "error";
                TempData["iconErrorText"] = "Favori adı boş geçilemez.";
                return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl});
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpGet]
        public async Task<IActionResult> FavoriteAddProduct(int id, int proId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var product = _productService.GetById(proId);
                var favori = _favoriteService.GetFavoriteAndFavoriteProduct(id);
                if (favori != null)
                {
                    var favoriteProducts = new List<FavoriteProduct>() {
                        new FavoriteProduct() {
                            FavoriteId = id,
                            ProductId = proId
                        }
                    };
                    if (!favori.FavoriteProducts.Select(i => i.ProductId == proId).FirstOrDefault())
                    {
                        _favoriteService.FavoriteAdd(id, favoriteProducts);
                    }
                    var sonuc = JsonConvert.SerializeObject(favoriteProducts);
                    return Json(sonuc);
                    // AJAX KULLANDIĞIMIZ İÇİN, BURDAN SONRAKİ RETURN VİEW'LER ÇALIŞMAZ
                    // TempData["iconSuccess"] = "success";
                    // TempData["iconSuccessText"] = "Favori grubuna eklendi.";
                    // return RedirectToAction("ProductDetail", "Product", new { id = proId});
                }
                TempData["iconError"] = "error";
                TempData["iconErrorText"] = "Favori grubu bulunamadı. Lütfen tekrar deneyin.";
                return RedirectToAction("ProductDetail", "Product", new { url = product.ProductUrl});
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
    
        [HttpGet]
        public async Task<IActionResult> FavoriteGetList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var favorites = _favoriteService.GetAll().Where(i => i.ProjeUserId == user.Id).ToList();
                var sonuc = JsonConvert.SerializeObject(favorites);
                return Json(sonuc);
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

    }
}
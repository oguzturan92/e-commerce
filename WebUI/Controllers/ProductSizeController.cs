using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Ürün")]
    public class ProductSizeController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        ProductSizeManager _productSizeService = new ProductSizeManager(new ProductSizeDal());
        SizeTypeManager _sizeTypeService = new SizeTypeManager(new SizeTypeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult ProductSizeEdit(int id)
        {
            var model = new ProductSizeModel() {
                SizeTypes = _sizeTypeService.SizeTypeAndSize(),
                ProductIdGelen = id,
                EklenmisSizes = _productSizeService.ProductSizeGet(id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ProductSizeEdit(ProductSizeModel model, int[] sizeIds)
        {
            var eklenmisSize = _productSizeService.GetAll().Where(i => i.ProductId == model.ProductIdGelen).ToList();

            List<ProductSize> productSize = new List<ProductSize>();
            foreach (var item in sizeIds)
            {
                var entity = new ProductSize() {
                    SizeId = item,
                    ProductId = model.ProductIdGelen,
                    ProductSizePrice = model.ProductSizePrice,
                    ProductSizeStock = model.ProductSizeStock
                };
                if (!eklenmisSize.Select(i => i.SizeId).Contains(entity.SizeId))
                {
                    productSize.Add(entity);
                }
            }
            var context = new ProjeContext();
            context.ProductSizes.AddRange(productSize);
            context.SaveChanges();
            
            TempData["icon"] = "success";
            TempData["title"] = "Ekleme başarılı.";
            return RedirectToAction("ProductSizeEdit", "ProductSize", new { id = model.ProductIdGelen });
        }

        [HttpPost]
        public IActionResult ProductSizeDelete(int id)
        {

            var entity = _productSizeService.GetById(id);
            if (entity != null)
            {
                _productSizeService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Varyasyon silindi.";
                return RedirectToAction("ProductSizeEdit", "ProductSize", new { id = entity.ProductId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductSizeEdit", "ProductSize", new { id = entity.ProductId });
        }
    }
}
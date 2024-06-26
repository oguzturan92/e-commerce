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
    public class VariantController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        VariantManager _variantService = new VariantManager(new VariantDal());
        ProductManager _productService = new ProductManager(new ProductDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult VariantEdit(int id, string searchName, int? searchId)
        {
            var entities = _variantService.GetAll().Where(i => i.ProductId == id).ToList();
            if (entities != null)
            {
                List<Product> variantProducts = new List<Product>();
                foreach (var item in entities)
                {
                    var product = _productService.GetAll().Where(i => i.ProductId == item.VariantSecond).FirstOrDefault();
                    variantProducts.Add(product);
                }

                if (searchName != null)
                {   // Arama yapılmışsa listelenen Products olarak bu model döner, arama yapılmamışsa alttaki model döner
                    var modelSearch = new VariantModel() {
                        Products = _productService.GetAll().Where(i => i.ProductName.ToLower().Contains(searchName.ToLower())).Take(10).ToList(),
                        VariantSelected = variantProducts,
                        ProductId = id
                    };
                    return View(modelSearch);
                }

                if (searchId != null)
                {   // Arama yapılmışsa listelenen Products olarak bu model döner, arama yapılmamışsa alttaki model döner
                    var modelSearch = new VariantModel() {
                        Products = _productService.GetAll().Where(i => i.ProductId == searchId).ToList(),
                        VariantSelected = variantProducts,
                        ProductId = id
                    };
                    return View(modelSearch);
                }
                

                var model = new VariantModel() {
                    Products = _productService.GetAll().OrderBy(i => i.ProductSort).Take(10).ToList(),
                    VariantSelected = variantProducts,
                    ProductId = id
                };
                return View(model);
            }
            return RedirectToAction("ProductList", "Product");
        }

        [HttpPost]
        public IActionResult VariantEdit(VariantModel model, int[] selectIds, int[] allProId)
        {
            foreach (var item in allProId)
            { // O an listelenen tüm Product'ları aldık
              // Variant tablosundan, o an listelenenleri sildik.
                var delEntities = _variantService.GetAll().Where(i => i.VariantSecond == item && i.ProductId == model.ProductId).FirstOrDefault();
                if (delEntities != null)
                {
                    _variantService.Delete(delEntities);
                }
            }

            foreach (var item in selectIds)
            {
                // var sorgu = _variantService.GetAll().Where(i => i.ProductId == model.ProductId && i.VariantSecond == item).FirstOrDefault();
                // if (sorgu == null)
                // { // Daha önce eklenmemişse eklenir
                //     var entity = new Variant()
                //     {
                //         VariantSecond = item,
                //         ProductId = model.ProductId
                //     };
                //     _variantService.Create(entity);
                // }
                var entity = new Variant()
                { // Variant tablosuna eklenir
                    VariantSecond = item,
                    ProductId = model.ProductId
                };
                _variantService.Create(entity);
            }
            
            return RedirectToAction("VariantEdit", "Variant", new { id = model.ProductId });
        }

    }
}
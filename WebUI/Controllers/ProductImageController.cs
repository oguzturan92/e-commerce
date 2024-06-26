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
    public class ProductImageController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        ProductImageManager _productImageService = new ProductImageManager(new ProductImageDal());
        ProductManager _productService = new ProductManager(new ProductDal()); 


        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult ProductImageList(int id)
        {
            var model = new ProductImageModel()
            {   
                Product = _productService.GetById(id),
                ProductImages = _productImageService.GetAll().Where(i => i.ProductId == id).OrderBy(i => i.ProductImageSort).ToList(),
                ProductId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ProductImageList(ProductImageModel model)
        {
            var entity = _productImageService.GetById(model.ProductImageId);
            entity.ProductImageSort = model.ProductImageSort;
            _productImageService.Update(entity);

            TempData["icon"] = "success";
            TempData["title"] = "Sıralama güncellendi.";
            return RedirectToAction("ProductImageList", "ProductImage");
        }

        [HttpPost]
        public IActionResult ProductImageCreate(ProductImageModel model, List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var uzantiBul = Path.GetExtension(file.FileName);
                if (uzantiBul != ".jpg")
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Lütfen .jpg uzantılı dosya yükleyiniz.";
                    return RedirectToAction("ProductImageList", "ProductImage", new { id = model.ProductId });
                }
            }
            
            List<ProductImage> images = new List<ProductImage>();
            foreach (var file in files)
            {
                var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

                if (System.IO.File.Exists(dosyaYolu) == false)
                {
                    images.Add(new ProductImage(){ProductId = model.ProductId, ProductImageName = file.FileName});
                }

                var sayi = 1;
                while (System.IO.File.Exists(dosyaYolu))
                {
                    var yeniAd = sayi + "-" + file.FileName;
                    dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", yeniAd);
                    sayi++;
                    if (System.IO.File.Exists(dosyaYolu) == false)
                    {
                        images.Add(new ProductImage(){ProductId = model.ProductId, ProductImageName = yeniAd});
                    }
                }

                var stream = new FileStream(dosyaYolu, FileMode.Create);
                file.CopyTo(stream);
                stream.Flush();
                stream.Close();
            }

            // _productImageService.Create() ile de yapılabilirdi ancak bu şekilde tercih ettim deneme olarak.
            var context = new ProjeContext(); // ProjeContext: Temel DatabaseContext'imiz
            context.ProductImages.AddRange(images); // Context altındaki ProductImages tablosuna AddRange ile listeyi kaydet. images listesini yukarıda oluşturdum.
            context.SaveChanges(); // Yapılan işlemi Database'e kayıt eder

            TempData["icon"] = "success";
            TempData["title"] = "Resim eklendi.";
            return RedirectToAction("ProductImageList", "ProductImage", new { id = model.ProductId });
        }

        [HttpPost]
        public IActionResult ProductImageVitrin(ProductImageModel model)
        {
            var entity = _productService.GetById(model.ProductId);
            entity.ProductImage = model.ProductImageName;
            _productService.Update(entity);

            TempData["icon"] = "success";
            TempData["title"] = "Vitrin resmi güncellendi.";
            return RedirectToAction("ProductImageList", "ProductImage", new { id = model.ProductId });
        }

        [HttpPost]
        public IActionResult ProductImageDelete(ProductImageModel model)
        {
            // Vitrin resmi olan ProductImage entity'sini silemeyecek. Img ve Product entity'lerine ulaşıp, ProductImage isimleri aynı ise vitrin resmi anlamını taşıdığından dolayı, silme işlemi yapılamaz.
            var entityImg = _productImageService.GetById(model.ProductImageId);
            var entityProduct = _productService.GetById(entityImg.ProductId);
            if (entityImg.ProductImageName != entityProduct.ProductImage)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/" + entityImg.ProductImageName);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }
                _productImageService.Delete(entityImg);
                
                TempData["icon"] = "success";
                TempData["title"] = "Resim silindi.";
                return RedirectToAction("ProductImageList", "ProductImage", new { id = model.ProductId });
            } else
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Vitrin resmi silinemez. Lütfen vitrin resmini değiştirip tekrar deneyin.";
                return RedirectToAction("ProductImageList", "ProductImage", new { id = model.ProductId });
            }
        }

        [HttpPost]
        public IActionResult ProductImageDeleteAll(int id)
        {
            var entityAll = _productImageService.GetAll().Where(i => i.ProductId == id);
            var entityProduct = _productService.GetById(id);
            foreach (var entity in entityAll)
            {
                if (entity.ProductImageName != entityProduct.ProductImage)
                {
                    Console.WriteLine("id");
                    var dosyaYolu = Path.Combine("wwwroot/img/" + entity.ProductImageName);
                    if (System.IO.File.Exists(dosyaYolu))
                    {
                        System.IO.File.Delete(dosyaYolu);
                        _productImageService.Delete(entity);
                    }
                }
            }
            TempData["icon"] = "success";
            TempData["title"] = "Resimler silindi.";
            return RedirectToAction("ProductImageList", "ProductImage", new { id = id });
        }
    }
}
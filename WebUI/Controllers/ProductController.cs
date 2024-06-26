using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeBusiness.Validators;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Ürün")]
    public class ProductController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        ProductManager _productService = new ProductManager(new ProductDal());
        ProductImageManager _productImageService = new ProductImageManager(new ProductImageDal());
        CategoryManager _categoryService = new CategoryManager(new CategoryDal());
        HomeDesignTypeManager _homeDesignTypeService = new HomeDesignTypeManager(new HomeDesignTypeDal());
        SizeTypeManager _sizeTypeService = new SizeTypeManager(new SizeTypeDal());
        ListManager _listService = new ListManager(new ListDal());
        FavoriteManager _favoriteService = new FavoriteManager(new FavoriteDal());
        private UserManager<ProjeUser> _userManager;
        public ProductController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult ProductList(int page = 1)
        {
            const int pageSize = 15;
            var model = new AdminProductIndexModel(){
                PageInfo = new PageInfo(){ // Farklı bir modeli, bir başka model içine nesne olarak gönderdik.
                    TotalItems = _productService.GetAll().Count(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                },
                Products = _productService.GetAll().OrderBy(i => i.ProductSort).Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ProductList(AdminProductIndexModel model, int id)
        {
            var entity = _productService.GetById(id);
            if (entity != null)
            {
                entity.ProductSort = model.ProductSort;
                _productService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("ProductList", "Product");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            var model = new ProductModel()
            {
                ListCategories = _categoryService.AllCategory(),
                ListHomeDesignTypes = _homeDesignTypeService.AllHomeDesignTypes()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ProductCreate(ProductModel model, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3, List<IFormFile> files)
        {
            if(model.ProductSort == null)
            {
                model.ProductSort = 0;
            }

            if (files != null)
            {
                foreach (var file in files)
                {
                    var uzantiBul = Path.GetExtension(file.FileName);
                    if (uzantiBul != ".jpg")
                    {
                        ModelState.AddModelError("ProductImages", "Lütfen .jpg uzantılı dosya yükleyiniz.");
                        model.ListCategories = _categoryService.AllCategory();
                        model.ListHomeDesignTypes = _homeDesignTypeService.AllHomeDesignTypes();
                        return View(model);
                    }
                }
            }
            
            List<ProductImage> ValiImg = new List<ProductImage>();
            foreach (var file in files)
            {
                ValiImg.Add(new ProductImage(){ProductImageName = file.FileName});
            }

            if (model.ProductSalePrice > 0)
            {   // İndirim fiyatı girilmişse, indirim etiketi true yapılır
                model.ProductSale = true;
            } else
            {
                model.ProductSale = false;
            }

            var entity = new Product()
            {
                ProductCode = model.ProductCode,
                ProductName = model.ProductName,
                ProductShortName = model.ProductShortName,
                ProductColor = model.ProductColor,
                ProductUrl = model.ProductUrl,
                ProductStock = model.ProductStock,
                ProductPrice = model.ProductPrice,
                ProductSalePrice = model.ProductSalePrice,
                ProductKdv = model.ProductKdv,
                ProductApproval = model.ProductApproval,
                ProductSort = model.ProductSort,
                ProductNew = model.ProductNew,
                ProductSale = model.ProductSale,
                ProductSeoTitle = model.ProductSeoTitle,
                ProductSeoDescription = model.ProductSeoDescription,
                ProductSeoKeyword = model.ProductSeoKeyword,
                ProductImages = ValiImg
            };
            
            ProductModelValidator ProductModelValidator = new ProductModelValidator();
            ValidationResult results = ProductModelValidator.Validate(entity);

            if (results.IsValid)
            {
                List<string> entityImage = new List<string>();
                List<ProductImage> images = new List<ProductImage>();

                foreach (var file in files)
                {
                    entity.ProductImage = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.ProductImage);

                    if (System.IO.File.Exists(dosyaYolu) == false)
                    {
                        entityImage.Add(file.FileName);
                        images.Add(new ProductImage(){ProductImageName = file.FileName});
                    }

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        var yeniAd = sayi + "-" + entity.ProductImage;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", yeniAd);
                        sayi++;
                        if (System.IO.File.Exists(dosyaYolu) == false)
                        {
                            entityImage.Add(yeniAd);
                            images.Add(new ProductImage(){ProductImageName = yeniAd});
                        }
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                
                entity.ProductImages = images;
                entity.ProductImage = entityImage[0];
                _productService.Create(entity, categoryIds, designIds, categoryIds2, categoryIds3);

                TempData["icon"] = "success";
                TempData["title"] = "Ürün oluşturuldu.";
                return RedirectToAction("ProductList", "Product");
            } else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                // ListCategories bilgisi yani tüm kategori bilgisi, entity içinde bulunmadığı için, model içine bu şekilde gönderiyoruz. Çünkü validation geçersiz olduğunda, sayfa tekrar model üzerinden geri döndürüleceğinden, kategori bilgisi gitmiyor ve null hatası veriyor.
                model.ListCategories = _categoryService.AllCategory();
                model.ListHomeDesignTypes = _homeDesignTypeService.AllHomeDesignTypes();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ProductEdit(int id)
        {
            var entity = _productService.GetProductDetails(id);
            if (entity != null)
            {
                var model = new ProductModel()
                {
                    ProductId = entity.ProductId,
                    ProductCode = entity.ProductCode,
                    ProductName = entity.ProductName,
                    ProductShortName = entity.ProductShortName,
                    ProductColor = entity.ProductColor,
                    ProductUrl = entity.ProductUrl,
                    ProductStock = entity.ProductStock,
                    ProductPrice = entity.ProductPrice,
                    ProductSalePrice = entity.ProductSalePrice,
                    ProductKdv = entity.ProductKdv,
                    ProductImage = entity.ProductImage,
                    ProductApproval = entity.ProductApproval,
                    ProductSort = entity.ProductSort,
                    ProductNew = entity.ProductNew,
                    ProductSale = entity.ProductSale,
                    ProductSeoTitle = entity.ProductSeoTitle,
                    ProductSeoDescription = entity.ProductSeoDescription,
                    ProductSeoKeyword = entity.ProductSeoKeyword,
                    ProductImages = _productImageService.GetAll().Where(i => i.ProductId == id).OrderBy(i => i.ProductImageSort).ToList(),
                        // Tüm kategori bilgisini getirir.
                    ListCategories = _categoryService.AllCategory(),
                        // Seçilmiş olan kategori bilgisini getirir.
                    SelectedCategories = entity.ProductCategories.Select(c => c.Category).OrderBy(i => i.CategorySort).ToList(),
                    SelectedCategory2s = entity.ProductCategory2s.Select(c => c.Category2).OrderBy(i => i.Category2Sort).ToList(),
                    SelectedCategory3s = entity.ProductCategory3s.Select(c => c.Category3).OrderBy(i => i.Category3Sort).ToList(),
                        // Tüm dizayn bilgisi list olan HomeDesignType verilerini getirir.
                    ListHomeDesignTypes =  _homeDesignTypeService.AllHomeDesignTypes(),
                        // Bu entitye ait seçilmiş HomeDesignType verilerini getirir.
                    SelectedListHomeDesignTypes = entity.ProductHomeDesignTypes.Select(h => h.HomeDesignType).OrderBy(h => h.HomeDesignTypeSort).ToList()
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductModel model, int[] categoryIds, int[] designIds, int[] categoryIds2, int[] categoryIds3, List<IFormFile> files)
        {
            if (model.ProductSalePrice > 0)
            {   // İndirim fiyatı girilmişse, indirim etiketi true yapılır
                model.ProductSale = true;
            } else
            {
                model.ProductSale = false;
            }

            var entity = new Product()
            {
                ProductId = model.ProductId,
                ProductCode = model.ProductCode,
                ProductName = model.ProductName,
                ProductShortName = model.ProductShortName,
                ProductColor = model.ProductColor,
                ProductUrl = model.ProductUrl,
                ProductStock = model.ProductStock,
                ProductPrice = model.ProductPrice,
                ProductSalePrice = model.ProductSalePrice,
                ProductKdv = model.ProductKdv,
                ProductImage = model.ProductImage,
                ProductApproval = model.ProductApproval,
                ProductSort = model.ProductSort,
                ProductNew = model.ProductNew,
                ProductSale = model.ProductSale,
                ProductSeoTitle = model.ProductSeoTitle,
                ProductSeoDescription = model.ProductSeoDescription,
                ProductSeoKeyword = model.ProductSeoKeyword
            };

            ProductModelValidator productModelValidator = new ProductModelValidator();
            ValidationResult results = productModelValidator.Validate(entity);

            if (results.IsValid)
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        var uzantiBul = Path.GetExtension(file.FileName);
                        if (uzantiBul != ".jpg")
                        {
                            ModelState.AddModelError("ProductImages", "Lütfen .jpg uzantılı dosya yükleyiniz.");
                            model.SelectedCategories = _productService.GetProductDetails(model.ProductId).ProductCategories.Select(c => c.Category).ToList();
                            model.SelectedCategory2s = _productService.GetProductDetails(model.ProductId).ProductCategory2s.Select(c => c.Category2).ToList();
                            model.SelectedCategory3s = _productService.GetProductDetails(model.ProductId).ProductCategory3s.Select(c => c.Category3).ToList();
                            model.ProductImages = _productImageService.GetAll().Where(i => i.ProductId == model.ProductId).OrderBy(i => i.ProductImageSort).ToList();
                            model.ListCategories = _categoryService.AllCategory();
                            model.ListHomeDesignTypes = _homeDesignTypeService.AllHomeDesignTypes();
                            return View(model);
                        }
                    }

                    List<ProductImage> images = new List<ProductImage>();
                    foreach (var file in files)
                    {
                        var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

                        if (System.IO.File.Exists(dosyaYolu) == false)
                        {
                            images.Add(new ProductImage(){ProductImageName = file.FileName});
                        }
                        
                        var sayi = 1;
                        while (System.IO.File.Exists(dosyaYolu))
                        {
                            var yeniAd = sayi + "-" + file.FileName;
                            dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", yeniAd);
                            sayi++;
                            if (System.IO.File.Exists(dosyaYolu) == false)
                            {
                                images.Add(new ProductImage(){ProductImageName = yeniAd});
                            }
                        }

                        var stream = new FileStream(dosyaYolu, FileMode.Create);
                        file.CopyTo(stream);
                        stream.Flush();
                        stream.Close();
                    }
                    entity.ProductImages = images;
                }
                _productService.Update(entity, categoryIds, designIds, categoryIds2, categoryIds3);

                TempData["icon"] = "success";
                TempData["title"] = "Ürün güncellendi.";
                return RedirectToAction("ProductEdit", "Product", new { id = model.ProductId });
            } else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                model.ListCategories = _categoryService.AllCategory();
                model.ListHomeDesignTypes = _homeDesignTypeService.AllHomeDesignTypes();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult ProductDelete(int id)
        {
            var entity = _productService.GetById(id);
            if (entity != null)
            {
                var images = _productImageService.GetAll().Where(i => i.ProductId == id).ToList();
                foreach (var item in images)
                {
                    var dosyaYolu = Path.Combine("wwwroot/img/" + item.ProductImageName);
                    if (System.IO.File.Exists(dosyaYolu))
                    {
                        System.IO.File.Delete(dosyaYolu);
                    }
                }

                _productService.Delete(entity); // ve sonra entity'i de siliyoruz yani elemanı

                TempData["icon"] = "success";
                TempData["title"] = "Ürün silindi.";
                return RedirectToAction("ProductList", "Product");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

        // CLIENT METOTLARI ------------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ProductDetail(string url)
        {
            var entity = _productService.GetProductDetailClient(url);
            
            if (entity != null)
            {
                if (entity.ProductId != 0)
                {
                    List<Product> variantProducts = new List<Product>();
                    foreach (var item in entity.Variants)
                    {
                        var variantproduct = _productService.GetAll().Where(i => i.ProductId == item.VariantSecond).FirstOrDefault();
                        variantProducts.Add(variantproduct);
                    }
                    
                    var categoryTree = _productService.CategoryListNameProduct(entity.ProductId);

                    var model = new ProductDetailModel(){
                        Product = entity,
                        VariantProducts = variantProducts,
                        SizeType = _sizeTypeService.ProductDetailSize(entity.ProductId),
                        Lists = _listService.ProductDetailListAndProducts(entity.ProductId),
                        CategoryTree = categoryTree
                    };
                    return View(model);
                }
            }
            return NotFound();
        }
    
    }
}
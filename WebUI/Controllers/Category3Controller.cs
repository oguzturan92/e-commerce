using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeBusiness.Validators;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Kategori")]
    public class Category3Controller : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        Category3Manager _category3Service = new Category3Manager(new Category3Dal());
        Category2Manager _category2Service = new Category2Manager(new Category2Dal());
        CategoryManager _categoryService = new CategoryManager(new CategoryDal());
        ProductManager _productService = new ProductManager(new ProductDal());
        SizeTypeManager _sizeTypeService = new SizeTypeManager(new SizeTypeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult Category3List(int id, int categoryId)
        {
            var model = new Category3Model(){
                Category3s = _category3Service.GetAll().Where(i => i.Category2Id == id).OrderBy(i => i.Category3Sort).ToList(),
                Category2Id = id,
                CategoryId = categoryId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Category3List(Category3Model model)
        {
            var entity = _category3Service.GetById(model.Category3Id);
            if (entity != null)
            {
                entity.Category3Sort = model.Category3Sort;
                _category3Service.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("Category3List", "Category3", new { id = entity.Category2Id, categoryId = model.CategoryId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpGet]
        public IActionResult Category3Create(int id, int categoryId)
        {
            var model = new Category3Model(){
                Category2Id = id,
                CategoryId = categoryId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Category3Create(Category3Model model, IFormFile file)
        {
            if(model.Category3Sort == null)
            {
                model.Category3Sort = 0;
            }

            var entity = new Category3()
            {
                Category3Name = model.Category3Name,
                Category3Url = model.Category3Url,
                Category3Description = model.Category3Description,
                Category3Image = model.Category3Image,
                Category3Approval = model.Category3Approval,
                Category3Visibility = model.Category3Visibility,
                Category3Sort = model.Category3Sort,
                Category3ListType = model.Category3ListType,
                Category3SeoTitle = model.Category3SeoTitle,
                Category3SeoDescription = model.Category3SeoDescription,
                Category3SeoKeyword = model.Category3SeoKeyword,
                Category2Id = model.Category2Id
            };

            Category3ModelValidator category3ModelValidator = new Category3ModelValidator();
            ValidationResult results = category3ModelValidator.Validate(entity);

            if (results.IsValid)
            {
                if (file != null)
                {
                    entity.Category3Image = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category3Image);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.Category3Image = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category3Image);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _category3Service.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kategori oluşturuldu.";
                return RedirectToAction("Category3List", "Category3", new { id = model.Category2Id, CategoryId = model.CategoryId });
            } else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Category3Edit(int id, int categoryId)
        {
            var entity = _category3Service.GetById(id);
            if (entity != null)
            {
                var model = new Category3Model()
                {
                    Category3Id = entity.Category3Id,
                    Category3Name = entity.Category3Name,
                    Category3Url = entity.Category3Url,
                    Category3Description = entity.Category3Description,
                    Category3Image = entity.Category3Image,
                    Category3Approval = entity.Category3Approval,
                    Category3Visibility = entity.Category3Visibility,
                    Category3Sort = entity.Category3Sort,
                    Category3ListType = entity.Category3ListType,
                    Category3SeoTitle = entity.Category3SeoTitle,
                    Category3SeoDescription = entity.Category3SeoDescription,
                    Category3SeoKeyword = entity.Category3SeoKeyword,
                    Category2Id = entity.Category2Id,
                    CategoryId = categoryId
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpPost]
        public IActionResult Category3Edit(Category3Model model, IFormFile file)
        {
            var entity = new Category3()
            {
                Category3Id = model.Category3Id,
                Category3Name = model.Category3Name,
                Category3Url = model.Category3Url,
                Category3Description = model.Category3Description,
                Category3Image = model.Category3Image,
                Category3Approval = model.Category3Approval,
                Category3Visibility = model.Category3Visibility,
                Category3Sort = model.Category3Sort,
                Category3ListType = model.Category3ListType,
                Category3SeoTitle = model.Category3SeoTitle,
                Category3SeoDescription = model.Category3SeoDescription,
                Category3SeoKeyword = model.Category3SeoKeyword,
                Category2Id = model.Category2Id
            };

            Category3ModelValidator category3ModelValidator = new Category3ModelValidator();
            ValidationResult results = category3ModelValidator.Validate(entity);
            
            if (results.IsValid)
            {
                if (file != null)
                {
                    var dosyaYoluSil = Path.Combine("wwwroot/img/" + model.Category3Image);
                    if (System.IO.File.Exists(dosyaYoluSil))
                    {
                        System.IO.File.Delete(dosyaYoluSil);
                    }
                    
                    entity.Category3Image = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category3Image);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.Category3Image = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category3Image);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _category3Service.Update(entity);
                
                TempData["icon"] = "success";
                TempData["title"] = "Kategori güncellendi.";
                return RedirectToAction("Category3Edit", "Category3", new { id = model.Category3Id, categoryId = model.CategoryId });
            } else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Category3Delete(int id, int categoryId)
        {
            var entity = _category3Service.GetById(id);
 
            if (entity != null)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/" + entity.Category3Image);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }
                _category3Service.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kategori silindi.";
                return RedirectToAction("Category3List", "Category3", new { id = entity.Category2Id, categoryId = categoryId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }
    
        // CLIENT METOTLARI ------------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        // [Route("{ek1}/{ek2}/{url}")]
        public IActionResult Category3ListClient(string url, int[] filters)
        {
            var category3 = _category3Service.SeciliKategori3(url);
            var categoryBackUrl = _category2Service.GetAll().Where(i => i.Category2Id == category3.Category2Id).Select(i => i.Category2Url).FirstOrDefault();
            var categoryBackUrlUst = _categoryService.GetAll().Where(i => i.CategoryId == category3.Category2.Category.CategoryId).Select(i => i.CategoryUrl).FirstOrDefault();

            List<Product> products = new List<Product>();
            if (filters.Count() == 0)
            {
                products = _productService.GetProductList3(url);
            } else
            {
                products = _productService.GetProductFilters3(url, filters);
            }

            if (category3 != null)
            {
                var model = new ProductListModel() {
                    Products = products,
                    Category3 = category3,
                    CategoryBackUrl = categoryBackUrl,
                    CategoryBackUrlUst = categoryBackUrlUst,
                    SizeTypes = _sizeTypeService.SizeTypeAndSizeFilters3(url),
                    CategoryFilters3 = _category3Service.CategoryFilters3(url),
                    SelectedFilters = filters
                };
                return View(model);
            }
            return NotFound();
        }
    }
}
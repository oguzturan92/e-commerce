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
    public class Category2Controller : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        Category2Manager _category2Service = new Category2Manager(new Category2Dal());
        CategoryManager _categoryService = new CategoryManager(new CategoryDal());
        ProductManager _productService = new ProductManager(new ProductDal());
        SizeTypeManager _sizeTypeService = new SizeTypeManager(new SizeTypeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult Category2List(int id)
        {
            var model = new Category2Model(){
                Category2s = _category2Service.GetAll().Where(i => i.CategoryId == id).OrderBy(i => i.Category2Sort).ToList(),
                CategoryId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Category2List(Category2Model model)
        {
            var entity = _category2Service.GetById(model.Category2Id);
            if (entity != null)
            {
                entity.Category2Sort = model.Category2Sort;
                _category2Service.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("Category2List", "Category2", new { id = entity.CategoryId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpGet]
        public IActionResult Category2Create(int id)
        {
            var model = new Category2Model(){
                CategoryId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Category2Create(Category2Model model, IFormFile file)
        {
            if(model.Category2Sort == null)
            {
                model.Category2Sort = 0;
            }

            var entity = new Category2()
            {
                Category2Name = model.Category2Name,
                Category2Url = model.Category2Url,
                Category2Description = model.Category2Description,
                Category2Image = model.Category2Image,
                Category2Approval = model.Category2Approval,
                Category2Visibility = model.Category2Visibility,
                Category2Sort = model.Category2Sort,
                Category2ListType = model.Category2ListType,
                Category2SeoTitle = model.Category2SeoTitle,
                Category2SeoDescription = model.Category2SeoDescription,
                Category2SeoKeyword = model.Category2SeoKeyword,
                CategoryId = model.CategoryId
            };

            Category2ModelValidator category2ModelValidator = new Category2ModelValidator();
            ValidationResult results = category2ModelValidator.Validate(entity);

            if (results.IsValid)
            {
                if (file != null)
                {
                    entity.Category2Image = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category2Image);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.Category2Image = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category2Image);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _category2Service.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kategori oluşturuldu.";
                return RedirectToAction("Category2List", "Category2", new { id = model.CategoryId });
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
        public IActionResult Category2Edit(int id)
        {
            var entity = _category2Service.GetById(id);
            if (entity != null)
            {
                var model = new Category2Model()
                {
                    Category2Id = entity.Category2Id,
                    Category2Name = entity.Category2Name,
                    Category2Url = entity.Category2Url,
                    Category2Description = entity.Category2Description,
                    Category2Image = entity.Category2Image,
                    Category2Approval = entity.Category2Approval,
                    Category2Visibility = entity.Category2Visibility,
                    Category2Sort = entity.Category2Sort,
                    Category2ListType = entity.Category2ListType,
                    Category2SeoTitle = entity.Category2SeoTitle,
                    Category2SeoDescription = entity.Category2SeoDescription,
                    Category2SeoKeyword = entity.Category2SeoKeyword,
                    CategoryId = entity.CategoryId
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpPost]
        public IActionResult Category2Edit(Category2Model model, IFormFile file)
        {
            var entity = new Category2()
            {
                Category2Id = model.Category2Id,
                Category2Name = model.Category2Name,
                Category2Url = model.Category2Url,
                Category2Description = model.Category2Description,
                Category2Image = model.Category2Image,
                Category2Approval = model.Category2Approval,
                Category2Visibility = model.Category2Visibility,
                Category2Sort = model.Category2Sort,
                Category2ListType = model.Category2ListType,
                Category2SeoTitle = model.Category2SeoTitle,
                Category2SeoDescription = model.Category2SeoDescription,
                Category2SeoKeyword = model.Category2SeoKeyword,
                CategoryId = model.CategoryId
            };

            Category2ModelValidator category2ModelValidator = new Category2ModelValidator();
            ValidationResult results = category2ModelValidator.Validate(entity);

            if (results.IsValid)
            {
                if (file != null)
                {
                    var dosyaYoluSil = Path.Combine("wwwroot/img/" + model.Category2Image);
                    if (System.IO.File.Exists(dosyaYoluSil))
                    {
                        System.IO.File.Delete(dosyaYoluSil);
                    }
                    
                    entity.Category2Image = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category2Image);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.Category2Image = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.Category2Image);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _category2Service.Update(entity);
                
                TempData["icon"] = "success";
                TempData["title"] = "Kategori güncellendi.";
                return RedirectToAction("Category2Edit", "Category2", new { id = model.Category2Id });
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
        public IActionResult Category2Delete(int id)
        {
            var entity = _category2Service.GetById(id);
 
            if (entity != null)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/" + entity.Category2Image);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }
                _category2Service.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kategori silindi.";
                return RedirectToAction("Category2List", "Category2", new { id = entity.CategoryId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }
    
        // CLIENT METOTLARI ------------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Category2ListClient(string url, int[] filters)
        {
            var category2 = _category2Service.SeciliKategori2(url);
            var categoryBackUrl = _categoryService.GetAll().Where(i => i.CategoryId == category2.CategoryId).Select(i => i.CategoryUrl).FirstOrDefault();

            List<Product> products = new List<Product>();
            if (filters.Count() == 0)
            {
                products = _productService.GetProductList2(url);
            } else
            {
                products = _productService.GetProductFilters2(url, filters);
            }
            if (category2 != null)
            {
                var model = new ProductListModel() {
                    Products = products,
                    Category2 = category2,
                    CategoryBackUrl = categoryBackUrl,
                    SizeTypes = _sizeTypeService.SizeTypeAndSizeFilters2(url),
                    CategoryFilters2 = _category2Service.CategoryFilters2(url),
                    SelectedFilters = filters,
                    Categories = _categoryService.CategoryIcerikMenu()
                };
                return View(model);
            }
            return NotFound();
        }
    }
}
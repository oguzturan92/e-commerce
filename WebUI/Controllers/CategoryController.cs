using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class CategoryController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        CategoryManager _categoryService = new CategoryManager(new CategoryDal());
        ProductManager _productService = new ProductManager(new ProductDal());
        SizeTypeManager _sizeTypeService = new SizeTypeManager(new SizeTypeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult CategoryList()
        {
            var model = new CategoryModel(){
                Categories = _categoryService.GetAll().OrderBy(i => i.CategorySort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryList(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.CategoryId);
            if (entity != null)
            {
                entity.CategorySort = model.CategorySort;
                _categoryService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("CategoryList", "Category");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model, IFormFile file)
        {
            if(model.CategorySort == null)
            {
                model.CategorySort = 0;
            }

            var entity = new Category()
            {
                CategoryName = model.CategoryName,
                CategoryUrl = model.CategoryUrl,
                CategoryDescription = model.CategoryDescription,
                CategoryImage = model.CategoryImage,
                CategoryApproval = model.CategoryApproval,
                CategoryVisibility = model.CategoryVisibility,
                CategorySort = model.CategorySort,
                CategoryListType = model.CategoryListType,
                CategorySeoTitle = model.CategorySeoTitle,
                CategorySeoDescription = model.CategorySeoDescription,
                CategorySeoKeyword = model.CategorySeoKeyword
            };

            CategoryModelValidator categoryModelValidator = new CategoryModelValidator();
            ValidationResult results = categoryModelValidator.Validate(entity);

            if (results.IsValid)
            {
                if (file != null)
                {
                    entity.CategoryImage = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.CategoryImage);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.CategoryImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.CategoryImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _categoryService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kategori oluşturuldu.";
                return RedirectToAction("CategoryList", "Category");
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
        public IActionResult CategoryEdit(int id)
        {
            var entity = _categoryService.GetById(id);
            if (entity != null)
            {
                var model = new CategoryModel()
                {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName,
                    CategoryUrl = entity.CategoryUrl,
                    CategoryDescription = entity.CategoryDescription,
                    CategoryImage = entity.CategoryImage,
                    CategoryApproval = entity.CategoryApproval,
                    CategoryVisibility = entity.CategoryVisibility,
                    CategorySort = entity.CategorySort,
                    CategoryListType = entity.CategoryListType,
                    CategorySeoTitle = entity.CategorySeoTitle,
                    CategorySeoDescription = entity.CategorySeoDescription,
                    CategorySeoKeyword = entity.CategorySeoKeyword
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model, IFormFile file)
        {
            var entity = new Category()
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                CategoryUrl = model.CategoryUrl,
                CategoryDescription = model.CategoryDescription,
                CategoryImage = model.CategoryImage,
                CategoryApproval = model.CategoryApproval,
                CategoryVisibility = model.CategoryVisibility,
                CategorySort = model.CategorySort,
                CategoryListType = model.CategoryListType,
                CategorySeoTitle = model.CategorySeoTitle,
                CategorySeoDescription = model.CategorySeoDescription,
                CategorySeoKeyword = model.CategorySeoKeyword
            };

            CategoryModelValidator categoryModelValidator = new CategoryModelValidator();
            ValidationResult results = categoryModelValidator.Validate(entity);

            if (results.IsValid)
            {
                if (file != null)
                {
                    var dosyaYoluSil = Path.Combine("wwwroot/img/" + model.CategoryImage);
                    if (System.IO.File.Exists(dosyaYoluSil))
                    {
                        System.IO.File.Delete(dosyaYoluSil);
                    }
                    
                    entity.CategoryImage = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.CategoryImage);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.CategoryImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.CategoryImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _categoryService.Update(entity);
                
                TempData["icon"] = "success";
                TempData["title"] = "Kategori güncellendi.";
                return RedirectToAction("CategoryEdit", "Category", new { id = entity.CategoryId });
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
        public IActionResult CategoryDelete(int id)
        {
            var entity = _categoryService.GetById(id);
 
            if (entity != null)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/" + entity.CategoryImage);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }
                _categoryService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kategori silindi.";
                return RedirectToAction("CategoryList", "Category");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CategoryList", "Category");
        }
    
        // CLIENT METOTLARI ------------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult CategoryListClient(string url, int[] filters)
        {
            var category = _categoryService.SeciliKategori(url);
            
            List<Product> products = new List<Product>();
            if (filters.Count() == 0)
            {
                products = _productService.GetProductList(url);
            } else
            {
                products = _productService.GetProductFilters(url, filters);
            }
            
            if (category != null)
            {
                var model = new ProductListModel() {
                    Products = products,
                    Category = category,
                    SizeTypes = _sizeTypeService.SizeTypeAndSizeFilters(url),
                    CategoryFilters = _categoryService.CategoryFilters(url),
                    SelectedFilters = filters,
                    Categories = _categoryService.CategoryIcerikMenu()
                };
                return View(model);
            }
            return NotFound();
        }

    }
}
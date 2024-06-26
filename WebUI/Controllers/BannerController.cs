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
    [Authorize(Roles = "Admin, Banner")]
    public class BannerController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        BannerManager _bannerService = new BannerManager(new BannerDal());
        HomeDesignTypeManager _homeDesignTypeService = new HomeDesignTypeManager(new HomeDesignTypeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult BannerList()
        {
            var model = new BannerModel(){
                 Banners = _bannerService.GetAll().OrderBy(i => i.BannerSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult BannerList(BannerModel model)
        {
            var entity = _bannerService.GetById(model.BannerId);
            if (entity != null)
            {
                entity.BannerSort = model.BannerSort;
                _bannerService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("BannerList", "Banner");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("BannerList", "Banner");
        }

        [HttpGet]
        public IActionResult BannerCreate()
        {
            var model = new BannerModel()
            {
                ListHomeDesignTypes = _homeDesignTypeService.GetAll().Where(i => i.HomeDesignTypeOption == "Banner").OrderBy(i => i.HomeDesignTypeSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult BannerCreate(BannerModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(model.BannerSort == null)
                {
                    model.BannerSort = 0;
                }

                if (file != null)
                {
                    model.BannerImage = file.FileName;
                }

                var entity = new Banner()
                {
                    BannerName = model.BannerName,
                    BannerDescription = model.BannerDescription,
                    BannerLink = model.BannerLink,
                    BannerImage = model.BannerImage,
                    BannerApproval = model.BannerApproval,
                    BannerSort = model.BannerSort,
                    HomeDesignTypeId = model.HomeDesignTypeId
                };
                
                BannerModelValidator bannerModelValidator = new BannerModelValidator();
                ValidationResult results = bannerModelValidator.Validate(entity);

                if (results.IsValid)
                {
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.BannerImage);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.BannerImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.BannerImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();

                    _bannerService.Create(entity);

                    TempData["icon"] = "success";
                    TempData["title"] = "Banner oluşturuldu.";
                    return RedirectToAction("BannerList", "Banner");
                } else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            model.ListHomeDesignTypes = _homeDesignTypeService.GetAll().Where(i => i.HomeDesignTypeOption == "Banner").OrderBy(i => i.HomeDesignTypeSort).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult BannerEdit(int id)
        {
            var entity = _bannerService.GetById(id);
            if (entity != null)
            {
                var model = new BannerModel()
                {
                    BannerId = entity.BannerId,
                    BannerName = entity.BannerName,
                    BannerDescription = entity.BannerDescription,
                    BannerLink = entity.BannerLink,
                    BannerImage = entity.BannerImage,
                    BannerApproval = entity.BannerApproval,
                    BannerSort = entity.BannerSort,
                    HomeDesignTypeId = entity.HomeDesignTypeId,
                    ListHomeDesignTypes = _homeDesignTypeService.GetAll().Where(i => i.HomeDesignTypeOption == "Banner").OrderBy(i => i.HomeDesignTypeSort).ToList()
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("BannerList", "Banner");
        }

        [HttpPost]
        public IActionResult BannerEdit(BannerModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var dosyaYoluSil = Path.Combine("wwwroot/img/" + model.BannerImage);
                    if (System.IO.File.Exists(dosyaYoluSil))
                    {
                        System.IO.File.Delete(dosyaYoluSil);
                    }

                    model.BannerImage = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", model.BannerImage);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        model.BannerImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", model.BannerImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }

                var entity = new Banner()
                {
                    BannerId = model.BannerId,
                    BannerName = model.BannerName,
                    BannerDescription = model.BannerDescription,
                    BannerLink = model.BannerLink,
                    BannerImage = model.BannerImage,
                    BannerApproval = model.BannerApproval,
                    BannerSort = model.BannerSort,
                    HomeDesignTypeId = model.HomeDesignTypeId
                };

                _bannerService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Banner güncellendi.";
                return RedirectToAction("BannerEdit", "Banner", new { id = model.BannerId});
            }
            model.ListHomeDesignTypes = _homeDesignTypeService.GetAll().Where(i => i.HomeDesignTypeOption == "Banner").OrderBy(i => i.HomeDesignTypeSort).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult BannerDelete(int id)
        {
            var entity = _bannerService.GetById(id);
            if (entity != null)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/" + entity.BannerImage);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }
                _bannerService.Delete(entity);
                
                TempData["icon"] = "success";
                TempData["title"] = "Banner silindi.";
                return RedirectToAction("BannerList", "Banner");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("BannerList", "Banner");
        }

    }
}
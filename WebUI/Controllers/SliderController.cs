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
    [Authorize(Roles = "Admin, Slider")]
    public class SliderController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SliderManager _sliderService = new SliderManager(new SliderDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult SliderList()
        {
            var model = new SliderModel(){
                Sliders = _sliderService.GetAll().OrderBy(i => i.SliderSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SliderList(SliderModel model)
        {
            var entity = _sliderService.GetById(model.SliderId);
            if (entity != null)
            {
                entity.SliderSort = model.SliderSort;
                _sliderService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("SliderList", "Slider");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SliderList", "Slider");
        }

        [HttpGet]
        public IActionResult SliderCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SliderCreate(SliderModel model, IFormFile file)
        {
            if(model.SliderSort == null)
            {
                model.SliderSort = 0;
            }
            
            if (file != null)
            {
                var uzantiBul = Path.GetExtension(file.FileName);
                if (uzantiBul != ".jpg" && uzantiBul != ".mp4")
                {
                    ModelState.AddModelError("SliderImage", "Lütfen .jpg ya da .mp4 uzantılı dosya yükleyiniz.");
                    return View(model);
                }
                model.SliderImage = file.FileName;
            }

            var entity = new Slider()
            {
                SliderName = model.SliderName,
                SliderDescription = model.SliderDescription,
                SliderLink = model.SliderLink,
                SliderImage = model.SliderImage,
                SliderApproval = model.SliderApproval,
                SliderSort = model.SliderSort,
                SliderTime = model.SliderTime,
            };

            SliderModelValidator sliderModelValidator = new SliderModelValidator();
            ValidationResult results = sliderModelValidator.Validate(entity);

            if(results.IsValid)
            {
                var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.SliderImage);

                var sayi = 1;
                while (System.IO.File.Exists(dosyaYolu))
                {
                    entity.SliderImage = sayi + "-" + file.FileName;
                    dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.SliderImage);
                    sayi++;
                }

                var stream = new FileStream(dosyaYolu, FileMode.Create);
                file.CopyTo(stream);
                stream.Flush();
                stream.Close();

                _sliderService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Slider oluşturuldu.";
                return RedirectToAction("SliderList", "Slider");
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
        public IActionResult SliderEdit(int id)
        {
            var entity = _sliderService.GetById(id);
            if (entity != null)
            {
                var model = new SliderModel()
                {
                    SliderId = entity.SliderId,
                    SliderName = entity.SliderName,
                    SliderDescription = entity.SliderDescription,
                    SliderLink = entity.SliderLink,
                    SliderTime = entity.SliderTime,
                    SliderImage = entity.SliderImage,
                    SliderApproval = entity.SliderApproval,
                    SliderSort = entity.SliderSort
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SliderList", "Slider");
        }

        [HttpPost]
        public IActionResult SliderEdit(SliderModel model, IFormFile file)
        {
            // EditSlider ve EditBanner metotlarında, sliderImage alanı null olamayacağı için, validation sorgusu yapmadık(çünkü düzenleme kısmında resim silme butonu yok).
            if (file != null)
            {
                var uzantiBul = Path.GetExtension(file.FileName);
                if (uzantiBul != ".jpg" && uzantiBul != ".mp4")
                {
                    ModelState.AddModelError("SliderImage", "Lütfen .jpg ya da .mp4 uzantılı dosya yükleyiniz.");
                    return View(model);
                }

                var dosyaYoluSil = Path.Combine("wwwroot/img/" + model.SliderImage);
                if (System.IO.File.Exists(dosyaYoluSil))
                {
                    System.IO.File.Delete(dosyaYoluSil);
                }
                
                model.SliderImage = file.FileName;
                var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", model.SliderImage);

                var sayi = 1;
                while (System.IO.File.Exists(dosyaYolu))
                {
                    model.SliderImage = sayi + "-" + file.FileName;
                    dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", model.SliderImage);
                    sayi++;
                }

                var stream = new FileStream(dosyaYolu, FileMode.Create);
                file.CopyTo(stream);
                stream.Flush();
                stream.Close();
            }

            var entity = new Slider()
            {
                SliderId = model.SliderId,
                SliderName = model.SliderName,
                SliderDescription = model.SliderDescription,
                SliderLink = model.SliderLink,
                SliderTime = model.SliderTime,
                SliderImage = model.SliderImage,
                SliderApproval = model.SliderApproval,
                SliderSort = model.SliderSort
            };
            _sliderService.Update(entity);

            TempData["icon"] = "success";
            TempData["title"] = "Slider güncellendi.";
            return RedirectToAction("SliderEdit", "Slider", new { id = model.SliderId});
        }

        [HttpPost]
        public IActionResult SliderDelete(int id)
        {
            var entity = _sliderService.GetById(id);
            if (entity != null)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/" + entity.SliderImage);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }
                _sliderService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Slider silindi.";
                return RedirectToAction("SliderList", "Slider");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SliderList", "Slider");
        }

    }
}
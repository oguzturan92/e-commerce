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
    [Authorize(Roles = "Admin, Popup")]
    public class PopupController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        PopupManager _popupService = new PopupManager(new PopupDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult PopupList()
        {
            var model = new PopupModel()
            {
                Popups = _popupService.GetAll().OrderBy(i => i.PopupSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PopupList(PopupModel model)
        {
            var entity = _popupService.GetById(model.PopupId);
            if (entity != null)
            {
                entity.PopupSort = model.PopupSort;
                _popupService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("PopupList", "Popup");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("PopupList", "Popup");
        }

        [HttpGet]
        public IActionResult PopupCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PopupCreate(PopupModel model, IFormFile file)
        {
            if(model.PopupSort == null)
            {
                model.PopupSort = 0;
            }

            if (file != null)
            {
                var uzantiBul = Path.GetExtension(file.FileName);
                if (uzantiBul != ".jpg")
                {
                    ModelState.AddModelError("PopupImage", "Lütfen .jpg uzantılı dosya yükleyiniz.");
                    return View(model);
                }
                model.PopupImage = file.FileName;
            }

            var entity = new Popup()
            {
                PopupTitle = model.PopupTitle,
                PopupDescription = model.PopupDescription,
                PopupImage = model.PopupImage,
                PopupLink = model.PopupLink,
                PopupSort = model.PopupSort,
                PopupApproval = model.PopupApproval
            };

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.PopupImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.PopupImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _popupService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Popup oluşturuldu.";
                return RedirectToAction("PopupList", "Popup");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PopupEdit(int id)
        {
            var entity = _popupService.GetById(id);
            if (entity != null)
            {
                var model = new PopupModel()
                {
                    PopupId = entity.PopupId,
                    PopupTitle = entity.PopupTitle,
                    PopupDescription = entity.PopupDescription,
                    PopupImage = entity.PopupImage,
                    PopupLink = entity.PopupLink,
                    PopupSort = entity.PopupSort,
                    PopupApproval = entity.PopupApproval
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Popup bulunamadı. Lütfen tekrar deneyin.";
            return RedirectToAction("PopupList", "Popup");
        }

        [HttpPost]
        public IActionResult PopupEdit(PopupModel model, IFormFile file)
        {
            var entity = new Popup()
            {
                PopupId = model.PopupId,
                PopupTitle = model.PopupTitle,
                PopupDescription = model.PopupDescription,
                PopupImage = model.PopupImage,
                PopupLink = model.PopupLink,
                PopupSort = model.PopupSort,
                PopupApproval = model.PopupApproval
            };

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uzantiBul = Path.GetExtension(file.FileName);
                    if (uzantiBul != ".jpg")
                    {
                        ModelState.AddModelError("PopupImage", "Lütfen .jpg uzantılı dosya yükleyiniz.");
                        return View(model);
                    }

                    var dosyaYoluSil = Path.Combine("wwwroot/img/" + model.PopupImage);
                    if (System.IO.File.Exists(dosyaYoluSil))
                    {
                        System.IO.File.Delete(dosyaYoluSil);
                    }

                    entity.PopupImage = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.PopupImage);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.PopupImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", entity.PopupImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }
                _popupService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Popup güncellendi.";
                return RedirectToAction("PopupEdit", "Popup", new { id = model.PopupId});
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult PopupDelete(int id)
        {
            var entity = _popupService.GetById(id);
            if (entity != null)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/" + entity.PopupImage);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }
                _popupService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Popup silindi.";
                return RedirectToAction("PopupList", "Popup");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("PopupList", "Popup");
        }
    }
}
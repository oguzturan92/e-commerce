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
    [Authorize(Roles = "Admin, Seçenek")]
    public class SizeController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SizeManager _sizeService = new SizeManager(new SizeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult SizeList(int id)
        {
            var model = new SizeModel(){
                 Sizes = _sizeService.GetAll().Where(i => i.SizeTypeId == id).OrderBy(i => i.SizeSort).ToList(),
                 SizeTypeId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SizeList(SizeModel model)
        {
            var entity = _sizeService.GetById(model.SizeId);
            if (entity != null)
            {
                entity.SizeSort = model.SizeSort;
                _sizeService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("SizeList", "Size");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SizeList", "Size");
        }

        [HttpGet]
        public IActionResult SizeCreate(int id)
        {
            var model = new SizeModel() {
                SizeTypeId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SizeCreate(SizeModel model, IFormFile file)
        {
            if(model.SizeSort == null)
            {
                model.SizeSort = 0;
            }

            var entity = new Size()
            {
                SizeTitle = model.SizeTitle,
                SizeWriteOrImg = model.SizeWriteOrImg,
                SizeWrite = model.SizeWrite,
                SizeImage = model.SizeImage,
                SizeSort = model.SizeSort,
                SizeTypeId = model.SizeTypeId
            };

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uzantiBul = Path.GetExtension(file.FileName);
                    if (uzantiBul != ".jpg")
                    {
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Lütfen .jpg uzantılı dosya yükleyiniz.";
                        return RedirectToAction("SizeList", "Size", new { id = model.SizeTypeId });
                    }

                    entity.SizeImage = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\img-size", entity.SizeImage);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.SizeImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\img-size", entity.SizeImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }

                _sizeService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Alt Varyasyon oluşturuldu.";
                return RedirectToAction("SizeList", "Size", new { id = model.SizeTypeId });
            } else
            {
                return View(model);
            }
        }
    
        [HttpGet]
        public IActionResult SizeEdit(int id)
        {
            var entity = _sizeService.GetById(id);
            if (entity != null)
            {
                var model = new SizeModel()
                {
                    SizeId = entity.SizeId,
                    SizeTitle = entity.SizeTitle,
                    SizeWriteOrImg = entity.SizeWriteOrImg,
                    SizeWrite = entity.SizeWrite,
                    SizeImage = entity.SizeImage,
                    SizeSort = entity.SizeSort,
                    SizeTypeId = entity.SizeTypeId
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SizeTypeList", "SizeType");
        }

        [HttpPost]
        public IActionResult SizeEdit(SizeModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = new Size()
                {
                    SizeId = model.SizeId,
                    SizeTitle = model.SizeTitle,
                    SizeWriteOrImg = model.SizeWriteOrImg,
                    SizeWrite = model.SizeWrite,
                    SizeImage = model.SizeImage,
                    SizeSort = model.SizeSort,
                    SizeTypeId = model.SizeTypeId
                };

                if (file != null)
                {
                    var dosyaYoluSil = Path.Combine("wwwroot/img/img-size/" + model.SizeImage);
                    if (System.IO.File.Exists(dosyaYoluSil))
                    {
                        System.IO.File.Delete(dosyaYoluSil);
                    }
                    
                    entity.SizeImage = file.FileName;
                    var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\img-size", entity.SizeImage);

                    var sayi = 1;
                    while (System.IO.File.Exists(dosyaYolu))
                    {
                        entity.SizeImage = sayi + "-" + file.FileName;
                        dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\img-size", entity.SizeImage);
                        sayi++;
                    }

                    var stream = new FileStream(dosyaYolu, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                }

                _sizeService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Alt Varyasyon güncellendi.";
                return RedirectToAction("SizeList", "Size", new { id = model.SizeTypeId });
            } else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SizeDelete(int id)
        {
            var entity = _sizeService.GetById(id);
            if (entity != null)
            {
                var dosyaYolu = Path.Combine("wwwroot/img/img-size/" + entity.SizeImage);
                if (System.IO.File.Exists(dosyaYolu))
                {
                    System.IO.File.Delete(dosyaYolu);
                }

                _sizeService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Alt Varyasyon silindi.";
                return RedirectToAction("SizeList", "Size", new { id = entity.SizeTypeId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SizeTypeList", "SizeType");
        }
    
    }
}
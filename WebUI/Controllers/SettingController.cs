using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Ayarlar")]
    public class SettingController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SettingManager _settingService = new SettingManager(new SettingDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult SettingIndex()
        {
            var entity = _settingService.GetById(1);
            var model = new SettingModel()
            {
                SettingId = entity.SettingId,
                SettingFavicon = entity.SettingFavicon,
                SettingLogo = entity.SettingLogo,
                SettingKvkk = entity.SettingKvkk,
                SettingSeoTitle = entity.SettingSeoTitle,
                SettingSeoDescription = entity.SettingSeoDescription,
                SettingSeoKeyword = entity.SettingSeoKeyword
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SettingIndex(SettingModel model, IFormFile fileLogo, IFormFile fileFavicon)
        {
            if (fileLogo != null)
            {
                var dosyaYoluSilLogo = Path.Combine("wwwroot/img/img-logo/" + model.SettingLogo);
                if (System.IO.File.Exists(dosyaYoluSilLogo))
                {
                    System.IO.File.Delete(dosyaYoluSilLogo);
                }
                
                model.SettingLogo = "logo.png";
                var dosyaYoluLogo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\img-logo", "logo.png");

                var stream = new FileStream(dosyaYoluLogo, FileMode.Create);
                fileLogo.CopyTo(stream);
                stream.Flush();
                stream.Close();
            }

            if (fileFavicon != null)
            {
                var dosyaYoluSilFavicon = Path.Combine("wwwroot/" + model.SettingFavicon);
                if (System.IO.File.Exists(dosyaYoluSilFavicon))
                {
                    System.IO.File.Delete(dosyaYoluSilFavicon);
                }

                model.SettingFavicon = "favicon.ico";
                var dosyaYoluFavicon = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\", "favicon.ico");

                var stream = new FileStream(dosyaYoluFavicon, FileMode.Create);
                fileFavicon.CopyTo(stream);
                stream.Flush();
                stream.Close();
            }

            var entity = new Setting()
            {
                SettingId = model.SettingId,
                SettingFavicon = model.SettingFavicon,
                SettingLogo = model.SettingLogo,
                SettingKvkk = model.SettingKvkk,
                SettingSeoTitle = model.SettingSeoTitle,
                SettingSeoDescription = model.SettingSeoDescription,
                SettingSeoKeyword = model.SettingSeoKeyword
            };

            _settingService.Update(entity);

            TempData["icon"] = "success";
            TempData["title"] = "Ayarlar güncellendi.";
            return RedirectToAction("SettingIndex", "Setting");
        }
    
        // CLIENT METOTLAR ------------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SettingKvkk()
        {
            var entity = _settingService.GetAll().FirstOrDefault();
            var model = new SettingModel()
            {
                SettingKvkk = entity.SettingKvkk
            };
            return View(model);
        }
    }
}
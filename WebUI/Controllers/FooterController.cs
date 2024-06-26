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
    [Authorize(Roles = "Admin, Footer")]
    public class FooterController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        FooterManager _footerService = new FooterManager(new FooterDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult FooterList()
        {
            var model = new FooterModel(){
                Footers = _footerService.GetAll().OrderBy(i => i.FooterSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult FooterList(FooterModel model)
        {
            var entity = _footerService.GetById(model.FooterId);
            if (entity != null)
            {
                entity.FooterSort = model.FooterSort;
                _footerService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("FooterList", "Footer");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("FooterList", "Footer");
        }

        [HttpGet]
        public IActionResult FooterCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FooterCreate(FooterModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.FooterSort == null)
                {
                    model.FooterSort = 0;
                }

                var entity = new Footer()
                {
                    FooterTitle = model.FooterTitle,
                    FooterApproval = model.FooterApproval,
                    FooterSort = model.FooterSort
                };

                _footerService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Footer oluşturuldu.";
                return RedirectToAction("FooterList", "Footer");
            }
            return View(model);
        }
    
        [HttpGet]
        public IActionResult FooterEdit(int id)
        {
            var entity = _footerService.GetById(id);
            if (entity != null)
            {
                var model = new FooterModel()
                {
                    FooterId = entity.FooterId,
                    FooterTitle = entity.FooterTitle,
                    FooterApproval = entity.FooterApproval,
                    FooterSort = entity.FooterSort
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("FooterList", "Footer");
        }

        [HttpPost]
        public IActionResult FooterEdit(FooterModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Footer()
                {
                    FooterId = model.FooterId,
                    FooterTitle = model.FooterTitle,
                    FooterApproval = model.FooterApproval,
                    FooterSort = model.FooterSort
                };

                _footerService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Footer güncellendi.";
                return RedirectToAction("FooterEdit", "Footer", new { id = entity.FooterId });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult FooterDelete(int id)
        {
            var entity = _footerService.GetById(id);
            if (entity != null)
            {
                _footerService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Footer silindi.";
                return RedirectToAction("FooterList", "Footer");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("FooterList", "Footer");
        }

    }
}
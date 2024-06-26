using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Footer")]
    public class FooterAltController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        FooterAltManager _footerAltService = new FooterAltManager(new FooterAltDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult FooterAltList(int id)
        {
            var model = new FooterAltModel(){
                FooterAlts = _footerAltService.GetAll().Where(i => i.FooterId == id).OrderBy(i => i.FooterAltSort).ToList(),
                FooterId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult FooterAltList(FooterAltModel model)
        {
            var entity = _footerAltService.GetById(model.FooterAltId);
            if (entity != null)
            {
                entity.FooterAltSort = model.FooterAltSort;
                _footerAltService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("FooterAltList", "FooterAlt", new { id = entity.FooterId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("FooterAltList", "FooterAlt");
        }

        [HttpGet]
        public IActionResult FooterAltCreate(int id)
        {
            var model = new FooterAltModel(){
                FooterId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult FooterAltCreate(FooterAltModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.FooterAltSort == null)
                {
                    model.FooterAltSort = 0;
                }

                var entity = new FooterAlt()
                {
                    FooterAltSeoTitle = model.FooterAltSeoTitle,
                    FooterAltSeoDescription = model.FooterAltSeoDescription,
                    FooterAltSeoKeyword = model.FooterAltSeoKeyword,
                    FooterAltTitle = model.FooterAltTitle,
                    FooterAltContent = model.FooterAltContent,
                    FooterAltLink = model.FooterAltLink,
                    FooterAltApproval = model.FooterAltApproval,
                    FooterAltSort = model.FooterAltSort,
                    FooterId = model.FooterId
                };

                _footerAltService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Alt Footer oluşturuldu.";
                return RedirectToAction("FooterAltList", "FooterAlt", new { id = model.FooterId });
            } else
            {
                return View(model);
            }
        }
    
        [HttpGet]
        public IActionResult FooterAltEdit(int id)
        {
            var entity = _footerAltService.GetById(id);
            if (entity != null)
            {
                var model = new FooterAltModel()
                {
                    FooterAltId = entity.FooterAltId,
                    FooterAltSeoTitle = entity.FooterAltSeoTitle,
                    FooterAltSeoDescription = entity.FooterAltSeoDescription,
                    FooterAltSeoKeyword = entity.FooterAltSeoKeyword,
                    FooterAltTitle = entity.FooterAltTitle,
                    FooterAltContent = entity.FooterAltContent,
                    FooterAltLink = entity.FooterAltLink,
                    FooterAltApproval = entity.FooterAltApproval,
                    FooterAltSort = entity.FooterAltSort,
                    FooterId = entity.FooterId
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("FooterList", "Footer");
        }

        [HttpPost]
        public IActionResult FooterAltEdit(FooterAltModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new FooterAlt()
                {
                    FooterAltId = model.FooterAltId,
                    FooterAltSeoTitle = model.FooterAltSeoTitle,
                    FooterAltSeoDescription = model.FooterAltSeoDescription,
                    FooterAltSeoKeyword = model.FooterAltSeoKeyword,
                    FooterAltTitle = model.FooterAltTitle,
                    FooterAltContent = model.FooterAltContent,
                    FooterAltLink = model.FooterAltLink,
                    FooterAltApproval = model.FooterAltApproval,
                    FooterAltSort = model.FooterAltSort,
                    FooterId = model.FooterId
                };

                _footerAltService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Alt Footer güncellendi.";
                return RedirectToAction("FooterAltEdit", "FooterAlt", new { id = entity.FooterAltId });
            } else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult FooterAltDelete(int id)
        {
            var entity = _footerAltService.GetById(id);
            if (entity != null)
            {
                _footerAltService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Alt Footer silindi.";
                return RedirectToAction("FooterAltList", "FooterAlt", new { id = entity.FooterId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("FooterList", "Footer");
        }

        // CLIENT METOTLARI ------------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult FooterAltDetailClient(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var model = new FooterAltModel()
                {
                    FooterAlt = _footerAltService.FooterAltDetail(url)
                };
                return View(model);
            }
            return NotFound();
        }

    }
}
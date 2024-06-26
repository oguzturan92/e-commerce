using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class SupportController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SupportManager _supportService = new SupportManager(new SupportDal());
        private UserManager<ProjeUser> _userManager;
        public SupportController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }
        // ADMIN METOTLAR ------------------------------------------------------------
        [Authorize(Roles = "Admin, Destek")]
        [HttpGet]
        public IActionResult SupportList()
        {
            var model = new SupportModel()
            {
                Supports = _supportService.SupportsAndUsers()
            };
            return View(model);
        }

        [Authorize(Roles = "Admin, Destek")]
        [HttpGet]
        public IActionResult SupportDetail(int id)
        {
            var support = _supportService.SupportAndLines(id);
            if (support != null)
            {
                var model = new SupportModel()
                {
                    Support = support
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SupportList", "Support");
        }

        [Authorize(Roles = "Admin, Destek")]
        [HttpPost]
        public IActionResult SupportReply(SupportModel model)
        {
            if (ModelState.IsValid)
            {
                var support = _supportService.GetById(model.Support.SupportId);
                if (support != null)
                {
                    support.SupportSubject = model.SupportSubject;
                    var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    support.SupportState = "Cevaplandı";
                    support.SupportDateTime = dateTime;
                    _supportService.Update(support);

                    var supportLine = new SupportLine()
                    {
                            SupportId = model.Support.SupportId,
                            SupportLineContent = model.SupportLineContent,
                            SupportLineDateTime = dateTime,
                            SupportLineAnswering = "Müşteri Hizmetleri"
                    };

                    var context = new ProjeContext();
                    context.Add<SupportLine>(supportLine);
                    context.SaveChanges();

                    TempData["icon"] = "success";
                    TempData["title"] = "Mesajınız gönderildi.";
                    return RedirectToAction("SupportDetail", "Support", new { id = model.Support.SupportId});
                }
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
                return RedirectToAction("SupportList", "Support");
            }
            return RedirectToAction("SupportDetail", "Support", new { id = model.Support.SupportId});
        }

        [Authorize(Roles = "Admin, Destek")]
        [HttpPost]
        public IActionResult SupportDelete(int id)
        {
            var support = _supportService.GetById(id);
            if (support != null)
            {
                _supportService.Delete(support);
                
                TempData["icon"] = "success";
                TempData["title"] = "Destek talebi silindi.";
                return RedirectToAction("SupportList", "Support");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SupportList", "Support");
        }

        // CLIENT METOTLAR ------------------------------------------------------------
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SupportListClient()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new SupportModel()
                    {
                        Supports = _supportService.SupportsAndLines(user.Id)
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SupportCreateClient(SupportModel model)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (ModelState.IsValid)
                    {
                        var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        var support = new Support()
                        {
                            SupportSubject = model.SupportSubject,
                            SupportLines = new List<SupportLine>() {
                                new SupportLine() {
                                    SupportLineContent = model.SupportLineContent,
                                    SupportLineDateTime = dateTime,
                                    SupportLineAnswering = user.UserAdi + " " + user.UserSoyadi
                                }
                            },
                            SupportState = "Cevap bekliyor",
                            SupportDateTime = dateTime,
                            ProjeUserId = user.Id
                        };
                        _supportService.Create(support);

                        TempData["icon"] = "success";
                        TempData["text"] = "Mesajınız gönderildi.";
                        return RedirectToAction("SupportListClient", "Support");
                    }
                    return RedirectToAction("SupportListClient", "Support");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SupportLineReply(SupportModel model)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (ModelState.IsValid)
                    {
                        var support = _supportService.SupportsAndLines(user.Id).Where(i => i.SupportId == model.SupportId).FirstOrDefault();
                        if (support != null)
                        {
                            var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            support.SupportState = "Cevap bekliyor";
                            support.SupportDateTime = dateTime;
                            _supportService.Update(support);

                            var supportLine = new SupportLine()
                            {
                                    SupportId = support.SupportId,
                                    SupportLineContent = model.SupportLineContent,
                                    SupportLineDateTime = dateTime,
                                    SupportLineAnswering = user.UserAdi + " " + user.UserSoyadi
                            };

                            var context = new ProjeContext();
                            context.Add<SupportLine>(supportLine);
                            context.SaveChanges();

                            TempData["icon"] = "success";
                            TempData["text"] = "Mesajınız gönderildi.";
                            return RedirectToAction("SupportListClient", "Support");
                        }
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Destek talebi bulunamadı.";
                        return RedirectToAction("SupportListClient", "Support");
                    }
                    return RedirectToAction("SupportListClient", "Support");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Concrete;
using ProjeBusiness.Validators;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.EmailServis;
using WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Abone")]
    public class SubscribeController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        private IEmailGonder _emailGonder;
        public SubscribeController(IEmailGonder emailGonder)
        {
            _emailGonder = emailGonder;
        }
        SubscribeManager _subscribeService = new SubscribeManager(new SubscribeDal());


        // ADMİN KISMINDAKİ ACTIONLAR --------------------------------------------------
        [HttpGet]
        public IActionResult SubscribeList( int page = 1)
        {
            const int pageSize = 10;
            var model = new AdminSubscribeIndexModel(){
                PageInfo = new PageInfo(){ // Farklı bir modeli, bir başka model içine nesne olarak gönderdik.
                    TotalItems = _subscribeService.GetAll().Count(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                },
                Subscribes = _subscribeService.GetAll().OrderByDescending(i => i.SubscribeDate).Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult SubscribeCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubscribeCreate(SubscribeModel model)
        {
            var entity = new Subscribe()
            {
                SubscribeId = model.SubscribeId,
                SubscribeMail = model.SubscribeMail,
                SubscribeMailApproval = model.SubscribeMailApproval,
                SubscribeContactApproval = model.SubscribeContactApproval,
                SubscribeDate = model.SubscribeDate
            };

            if (ModelState.IsValid)
            {
                _subscribeService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Abone eklendi.";
                return RedirectToAction("SubscribeList", "Subscribe");
            } else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SubscribeEdit(int id)
        {
            var entity = _subscribeService.GetById(id);
            if (entity != null)
            {
                var model = new SubscribeModel()
                {
                    SubscribeId = entity.SubscribeId,
                    SubscribeMail = entity.SubscribeMail,
                    SubscribeToken = entity.SubscribeToken,
                    SubscribeMailApproval = entity.SubscribeMailApproval,
                    SubscribeContactApproval = entity.SubscribeContactApproval,
                    SubscribeDate = entity.SubscribeDate
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SubscribeList", "Subscribe");
        }

        [HttpPost]
        public IActionResult SubscribeEdit(SubscribeModel model)
        {
            var entity = new Subscribe()
            {
                SubscribeId = model.SubscribeId,
                SubscribeMail = model.SubscribeMail,
                SubscribeToken = model.SubscribeToken,
                SubscribeMailApproval = model.SubscribeMailApproval,
                SubscribeContactApproval = model.SubscribeContactApproval,
                SubscribeDate = model.SubscribeDate
            };

            if (ModelState.IsValid)
            {
                _subscribeService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Abone güncellendi.";
                return RedirectToAction("SubscribeEdit", "Subscribe", new { id = model.SubscribeId});
            } else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SubscribeDelete(int id)
        {
            var entity = _subscribeService.GetById(id);
            if (entity != null)
            {
                _subscribeService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Abone silindi";
                return RedirectToAction("SubscribeList", "Subscribe");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SubscribeList", "Subscribe");
        }


        // CLIENT METOTLARI --------------------------------------------------

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SubscribeCreateClient(SubscribeModel model)
        {
            if (ModelState.IsValid)
            {
                var mailControl = _subscribeService.GetAll();
                foreach (var item in mailControl)
                {
                    if (item.SubscribeMail == model.SubscribeMail)
                    {
                        return View(model);
                    }
                }

                var entity = new Subscribe()
                {
                    SubscribeMail = model.SubscribeMail,
                    SubscribeMailApproval = model.SubscribeMailApproval,
                    SubscribeContactApproval = model.SubscribeContactApproval,
                    SubscribeDate = DateTime.Now
                };

                Random random = new Random();
                string kaynak = "ABCDEFGHIJKLMNOPRSTUVYZabcdefghijklmnoprstuvyz0123456789-_+-*!%&?";
                string token = "";
                for (int i = 0; i < 100; i++)
                {
                    token += kaynak[random.Next(kaynak.Length)];
                }

                var mailIndex = model.SubscribeMail.IndexOf("@");
                var mailKalan = model.SubscribeMail.Remove(mailIndex);

                var url = Url.Action("SubscribeApproval", "Subscribe", new {
                    mail = mailKalan,
                    token = token
                });

                _emailGonder.SendEmailAsync(model.SubscribeMail, "Hesabınızı onaylayınız.", $"<p>HESABINIZI ONAYLAYIN</p><p>Lütfen Email hesabınızı onaylamak için linke <a href='https://sablon-5.softo.com.tr{url}'>tıklayınız.</a></p><p>Not: Bu mail, gereksiz klasörünüze geldiyse, linke tıklanmayabilir. Bu durumda, maili, gelen kutusuna taşıyıp linke tıklayın ya da bağlantıyı kopyalayıp, adres çubuğuna yapıştırın</p>");

                entity.SubscribeToken = token;
                entity.SubscribeContactApproval = true;
                entity.SubscribeMailApproval = false;
                _subscribeService.Create(entity);
                var values = JsonConvert.SerializeObject(entity);
                return Json(values);
            } else
            {
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SubscribeApproval(string mail, string token)
        {
            if(mail == null || token == null)
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Hatalı link, Lütfen tekrar deneyin.";
                return RedirectToAction("Index", "Home");
            } else
            {
                var entity = _subscribeService.GetAll().Where(i => i.SubscribeToken == token).FirstOrDefault();
                if (entity != null)
                {
                    if (entity.SubscribeMail.Remove(entity.SubscribeMail.IndexOf("@")) == mail)
                    {
                        if (entity.SubscribeMailApproval == false)
                        {
                            entity.SubscribeMailApproval = true;
                            _subscribeService.Update(entity);

                            TempData["icon"] = "success";       
                            TempData["text"] = "Mail adresiniz onaylandı.";
                            return RedirectToAction("Index", "Home");
                        } else
                        {
                            TempData["iconOK"] = "error";
                            TempData["iconText"] = "Bu mail adresi zaten onaylanmış.";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

                TempData["iconOK"] = "error";
                TempData["iconText"] = "Kayıtlı bir mail adresi bulunamadı ya da link hatalı. Lütfen kayıt yaptığınıza emin olun ve tekrar deneyin.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
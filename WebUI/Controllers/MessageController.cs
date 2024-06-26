using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Concrete;
using ProjeBusiness.Validators;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Mesaj")]
    public class MessageController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        MessageManager _messageService = new MessageManager(new MessageDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult MessageList(int page = 1)
        {
            const int pageSize = 10;
            var model = new AdminMessageIndexModel(){
                PageInfo = new PageInfo(){ // Farklı bir modeli, bir başka model içine nesne olarak gönderdik.
                    TotalItems = _messageService.GetAll().Count(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                },
                Messages = _messageService.GetAll().OrderByDescending(i => i.MessageDate).Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
            var entity = _messageService.GetById(id);
            if (entity != null)
            {
                var model = entity;
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("MessageList", "Message");
        }

        [HttpPost]
        public IActionResult MessageDelete(int id)
        {
            var entity = _messageService.GetById(id);
            if (entity != null)
            {
                _messageService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Mesaj silindi";
                return RedirectToAction("MessageList", "Message");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun olustu. Lütfen tekrar deneyin.";
            return RedirectToAction("MessageList", "Message");
        }
    
        // CLIENT METOTLAR ------------------------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        public IActionResult MessageCreate(PageMessageModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Message()
                {
                    MessageName = model.MessageName,
                    MessageSurname = model.MessageSurname,
                    MessagePhone = model.MessagePhone,
                    MessageMail = model.MessageMail,
                    MessageContent = model.MessageContent,
                    MessageDate = DateTime.Now
                };

                _messageService.Create(entity);
                var values = JsonConvert.SerializeObject(entity);
                return Json(values);
            }
            return View(model);
        }
    }
}
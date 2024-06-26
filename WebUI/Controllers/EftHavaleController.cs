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
    public class EftHavaleController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        EftHavaleManager _eftHavaleService = new EftHavaleManager(new EftHavaleDal());
        BankAccountManager _bankAccountService = new BankAccountManager(new BankAccountDal());
        OrderManager _orderService = new OrderManager(new OrderDal());
        private UserManager<ProjeUser> _userManager;
        public EftHavaleController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }
        
        // METOTLAR ------------------------------------------------------------
        [Authorize(Roles = "Admin, Havale Bildirim")]
        [HttpGet]
        public IActionResult EftHavaleList()
        {
            var model = new EftHavaleModel()
            {
                EftHavales = _eftHavaleService.GetAll().OrderByDescending(i => i.EftHavaleDateTime).ToList()
            };
            return View(model);
        }

        [Authorize(Roles = "Admin, Havale Bildirim")]
        [HttpPost]
        public IActionResult EftHavaleDelete(int id)
        {
            var eftHavale = _eftHavaleService.GetById(id);
            if (eftHavale != null)
            {
                _eftHavaleService.Delete(eftHavale);
                
                TempData["icon"] = "success";
                TempData["title"] = "Havale bildirimi silindi.";
                return RedirectToAction("EftHavaleList", "EftHavale");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("EftHavaleList", "EftHavale");
        }

        // CLIENT METOTLARI ------------------------------------------------------------
        [Authorize]
        public async Task<IActionResult> EftHavaleForm()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new EftHavaleModel()
                    {
                        Orders = _orderService.GetAll().Where(i => i.ProjeUserId == user.Id && i.OrderState == "Ödeme Bekliyor").Select(i => i.OrderNumber).ToList(),
                        BankAccounts = _bankAccountService.GetAll(),
                        EftHavales = _eftHavaleService.GetAll().Where(i => i.ProjeUserId == user.Id).OrderByDescending(i => i.EftHavaleDateTime).ToList()
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EftHavaleForm(EftHavaleModel model)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (ModelState.IsValid)
                    {
                        var eftHavale = new EftHavale()
                        {
                            EftHavaleOrderNumber = model.EftHavaleOrderNumber,
                            EftHavaleBankName = model.EftHavaleBankName,
                            EftHavaleOrderPrice = model.EftHavaleOrderPrice,
                            EftHavaleContent = model.EftHavaleContent,
                            EftHavaleDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                            ProjeUserId = user.Id
                        };
                        _eftHavaleService.Create(eftHavale);
                        
                        TempData["icon"] = "success";
                        TempData["text"] = "Havale bildiriminiz gönderildi.";
                        return RedirectToAction("EftHavaleForm", "EftHavale");
                    } else
                    {
                        model.Orders = _orderService.GetAll().Where(i => i.ProjeUserId == user.Id && i.OrderState == "Ödeme Bekliyor").Select(i => i.OrderNumber).ToList();
                        model.BankAccounts = _bankAccountService.GetAll();
                        model.EftHavales = _eftHavaleService.GetAll().Where(i => i.ProjeUserId == user.Id).OrderByDescending(i => i.EftHavaleDateTime).ToList();
                        return View(model);
                    }
                }
            }
            return RedirectToAction("AccountIndex", "UserAccount");
        }
    }
}
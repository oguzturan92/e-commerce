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
    [Authorize(Roles = "Admin, Banka")]
    public class BankAccountController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        BankAccountManager _bankAccountService = new BankAccountManager(new BankAccountDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult BankAccountList()
        {
            var model = new BankAccountModel()
            {
                BankAccounts = _bankAccountService.GetAll().OrderBy(i => i.BankAccountSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult BankAccountList(BankAccountModel model)
        {
            var entity = _bankAccountService.GetById(model.BankAccountId);
            if (entity != null)
            {
                entity.BankAccountSort = model.BankAccountSort;
                _bankAccountService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("BankAccountList", "BankAccount");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("BankAccountList", "BankAccount");
        }

        [HttpGet]
        public IActionResult BankAccountCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BankAccountCreate(BankAccountModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.BankAccountSort == null)
                {
                    model.BankAccountSort = 0;
                }

                var entity = new BankAccount()
                {
                    BankAccountName = model.BankAccountName,
                    BankAccountIban = model.BankAccountIban,
                    BankAccountSort = model.BankAccountSort
                };
                _bankAccountService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Banka hesabı oluşturuldu.";
                return RedirectToAction("BankAccountList", "BankAccount");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult BankAccountEdit(int id)
        {
            var entity = _bankAccountService.GetById(id);
            if (entity != null)
            {
                var model = new BankAccountModel()
                {
                    BankAccountId = entity.BankAccountId,
                    BankAccountName = entity.BankAccountName,
                    BankAccountIban = entity.BankAccountIban,
                    BankAccountSort = entity.BankAccountSort
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("BankAccountList", "BankAccount");
        }

        [HttpPost]
        public IActionResult BankAccountEdit(BankAccountModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new BankAccount()
                {
                    BankAccountId = model.BankAccountId,
                    BankAccountName = model.BankAccountName,
                    BankAccountIban = model.BankAccountIban,
                    BankAccountSort = model.BankAccountSort
                };
                _bankAccountService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Banka hesabı güncellendi.";
                return RedirectToAction("BankAccountEdit", "BankAccount", new { id = model.BankAccountId });
            }
            return View(model);
        }

        public IActionResult BankAccountDelete(int id)
        {
            var entity = _bankAccountService.GetById(id);
            if (entity != null)
            {
                _bankAccountService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Banka hesabı silindi.";
                return RedirectToAction("BankAccountList", "BankAccount");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("BankAccountList", "BankAccount");
        }
    }
}
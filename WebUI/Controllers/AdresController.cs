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
    [Authorize]
    public class AdresController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        AdresManager _adresService = new AdresManager(new AdresDal());
        private UserManager<ProjeUser> _userManager;
        public AdresController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }

        // CLIENT METOTLAR ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> AdresListUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var model = new AdresModel()
                {
                    Adreses = _adresService.GetAll().Where(i => i.ProjeUserId == id).ToList()
                };
                return View(model);
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("IndexAccount", "AdminAccount");
        }

        [HttpGet]
        public IActionResult AdresEditUser(int id)
        {
            var adres = _adresService.GetById(id);
            if (adres != null)
            {
                var model = new AdresModel()
                {
                    AdresId = adres.AdresId,
                    AdresTitle = adres.AdresTitle,
                    AdresNameSurname = adres.AdresNameSurname,
                    AdresTcNo = adres.AdresTcNo,
                    AdresPhoneNumber = adres.AdresPhoneNumber,
                    AdresContent = adres.AdresContent,
                    AdresCounty = adres.AdresCounty,
                    AdresCity = adres.AdresCity,
                    AdresPostCode = adres.AdresPostCode,
                    AdresFaturaType = adres.AdresFaturaType,
                    ProjeUserId = adres.ProjeUserId
                };
                return View(model);
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("IndexAccount", "AdminAccount");
        }

        [HttpPost]
        public IActionResult AdresEditUser(AdresModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Adres()
                {
                    AdresId = model.AdresId,
                    AdresTitle = model.AdresTitle,
                    AdresNameSurname = model.AdresNameSurname,
                    AdresTcNo = model.AdresTcNo,
                    AdresContent = model.AdresContent,
                    AdresCounty = model.AdresCounty,
                    AdresCity = model.AdresCity,
                    AdresPostCode = model.AdresPostCode,
                    AdresPhoneNumber = model.AdresPhoneNumber,
                    AdresFaturaType = model.AdresFaturaType,
                    ProjeUserId = model.ProjeUserId
                };
                _adresService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Adres Güncellendi.";
                return RedirectToAction("AdresEditUser", "Adres", new { id = model.AdresId} );
            }
            return View(model);
        }

        public IActionResult AdresDeleteUser(int id)
        {
            var adres = _adresService.GetById(id);
            if (adres != null)
            {
                _adresService.Delete(adres);
                TempData["icon"] = "success";
                TempData["title"] = "Adres silindi.";
                return RedirectToAction("IndexAccount", "AdminAccount");
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("IndexAccount", "AdminAccount");
        }
        // CLIENT METOTLAR ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> AdresList()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new AdresModel()
                    {
                        Adreses = _adresService.GetAll().Where(i => i.ProjeUserId == user.Id).ToList(),
                        ProjeUserId = user.Id
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpGet]
        public async Task<IActionResult> AdresCreate()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    return View();
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpPost]
        public async Task<IActionResult> AdresCreate(AdresModel model, string cart)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (ModelState.IsValid)
                    {
                        var entity = new Adres()
                        {
                            AdresTitle = model.AdresTitle,
                            AdresNameSurname = model.AdresNameSurname,
                            AdresTcNo = model.AdresTcNo,
                            AdresContent = model.AdresContent,
                            AdresCounty = model.AdresCounty,
                            AdresCity = model.AdresCity,
                            AdresPostCode = model.AdresPostCode,
                            ProjeUserId = user.Id,
                            AdresPhoneNumber = model.AdresPhoneNumber,
                            AdresFaturaType = model.AdresFaturaType
                        };
                        _adresService.Create(entity);

                        user.SeciliAdresId = entity.AdresId;
                        await _userManager.UpdateAsync(user);

                        TempData["iconSuccess"] = "success";
                        TempData["iconSuccessText"] = "Adres oluşturuldu.";
                        if (cart == "0")
                        {
                            return RedirectToAction("CartAdres", "Cart");
                        }
                        return RedirectToAction("AdresList", "Adres", new { id = user.Id} );
                    }
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
        
        [HttpGet]
        public async Task<IActionResult> AdresEdit(int id)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var entity = _adresService.GetById(id);
                    if (entity != null && entity.ProjeUserId == user.Id)
                    {
                        var model = new AdresModel()
                        {
                            AdresId = id,
                            AdresTitle = entity.AdresTitle,
                            AdresNameSurname = entity.AdresNameSurname,
                            AdresTcNo = entity.AdresTcNo,
                            AdresContent = entity.AdresContent,
                            AdresCounty = entity.AdresCounty,
                            AdresCity = entity.AdresCity,
                            AdresPostCode = entity.AdresPostCode,
                            AdresPhoneNumber = entity.AdresPhoneNumber,
                            AdresFaturaType = entity.AdresFaturaType
                        };
                        return View(model);
                    }
                    TempData["iconError"] = "error";
                    TempData["iconErrorText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
                    return RedirectToAction("AdresList", "Adres");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
        
        [HttpPost]
        public async Task<IActionResult> AdresEdit(AdresModel model)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (ModelState.IsValid)
                    {
                        var entity = new Adres()
                        {
                            AdresId = model.AdresId,
                            AdresTitle = model.AdresTitle,
                            AdresNameSurname = model.AdresNameSurname,
                            AdresTcNo = model.AdresTcNo,
                            AdresContent = model.AdresContent,
                            AdresCounty = model.AdresCounty,
                            AdresCity = model.AdresCity,
                            AdresPostCode = model.AdresPostCode,
                            AdresPhoneNumber = model.AdresPhoneNumber,
                            AdresFaturaType = model.AdresFaturaType,
                            ProjeUserId = user.Id
                        };
                        _adresService.Update(entity);

                        TempData["iconSuccess"] = "success";
                        TempData["iconSuccessText"] = "Değişiklikler kaydedildi.";
                        return RedirectToAction("AdresEdit", "Adres", new { id = model.AdresId} );
                    }
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        public async Task<IActionResult> AdresDelete(int id)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var entity = _adresService.GetById(id);
                    if (entity != null && entity.ProjeUserId == user.Id)
                    {
                        _adresService.Delete(entity);

                        TempData["iconSuccess"] = "success";
                        TempData["iconSuccessText"] = "Adres silindi.";
                        return RedirectToAction("AdresList", "Adres");
                    }
                    
                    TempData["iconError"] = "error";
                    TempData["iconErrorText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
                    return RedirectToAction("AdresList", "Adres");
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
    }
}
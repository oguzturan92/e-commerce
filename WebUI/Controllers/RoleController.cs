using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Validators;
using WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeEntity.Concrete;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Rol")]
    public class RoleController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        private RoleManager<ProjeRole> _roleManager; // Rol işlemleri için kullanılacak
        private UserManager<ProjeUser> _userManager;
        public RoleController(RoleManager<ProjeRole> roleManager, UserManager<ProjeUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult RoleList()
        {
            var model = new RoleModel()
            {
                Roles = _roleManager.Roles
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var rol = new ProjeRole()
                {
                    Name = model.RoleName,
                    NormalizedName = model.RoleName.ToUpper()
                };
                
                var sonuc = await _roleManager.CreateAsync(rol); // Gelen name değeri alınarak, _roleManager'ınCreateAsync metodu ile IdentityRole içinde rol oluşturulur.
                if (sonuc.Succeeded) // Oluşturma işlemi başarılı ise
                {
                    TempData["icon"] = "success";
                    TempData["title"] = "Rol oluşturuldu.";
                    return RedirectToAction("RoleList", "Role");
                } else
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Bir sorun olustu. Lütfen tekrar deneyin.";
                    return RedirectToAction("RoleList", "Role");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RoleEdit(string Id)
        {
            var rol = await _roleManager.FindByIdAsync(Id); // Parametreden Id ile gelen değer ile rol sınıfı içinde sorgulama yaptık.
            if (rol != null) // Eşleşen değer varsa, Model içine gönderdim.
            {
                var model = new RoleModel(){
                    RoleId = Id,
                    RoleName = rol.Name
                };
                return View(model);
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Rol bulunamadi. Lütfen tekrar deneyin.";
            return RedirectToAction("RoleList", "Role");
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var rol = await _roleManager.FindByIdAsync(model.RoleId); // model'den gelen Id ile eşleşen değer aradık
                if (rol != null) // Eşleşen değer varsa
                {
                    rol.Name = model.RoleName; // Model'den gelen değeri Rol içindeki Name'e gönderdik.

                    var sonuc = await _roleManager.UpdateAsync(rol); // _roleManager içindeki Rol değerinin Name alanını güncelledik.
                    if (sonuc.Succeeded) // sonuc başarılı ise
                    {
                        TempData["icon"] = "success";
                        TempData["title"] = "Rol güncellendi";
                        return RedirectToAction("RoleList", "Role");
                    } else // sonuc başarılı değil ise
                    {
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Bir sorun olustu. Lütfen tekrar deneyin.";
                        return RedirectToAction("RoleList", "Role");
                    }
                }
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Rol bulunamadi. Lütfen tekrar deneyin.";
                return RedirectToAction("RoleEdit", "Role", new { id = model.RoleId}); // Eşleşen Rol yok ise
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleDelete(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id); // Parametre ile gelen Id'ye göre _roleManager içinde sorgulama yaptık.
            if (role != null) // Gelen Id ile ilişkili bir Rol var ise
            {
                var sonuc = await _roleManager.DeleteAsync(role); // Eşleşen Rolü, _roleManager içinde siler
                if (sonuc.Succeeded) // Silme işlemi başarılı ise
                {
                    TempData["icon"] = "success";
                    TempData["title"] = "Rol silindi.";
                    return RedirectToAction("RoleList", "Role");
                }
                else // Silme işlemi başarısız ise
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Bir sorun olustu. Lütfen tekrar deneyin.";
                    return RedirectToAction("RoleList", "Role");
                }
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Rol bulunamadi. Lütfen tekrar deneyin.";
            return RedirectToAction("RoleList", "Role");
        }
    }
}
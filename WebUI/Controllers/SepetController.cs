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
    [Authorize(Roles = "Admin, Sipariş")]
    public class SepetController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SepetManager _sepetService = new SepetManager(new SepetDal());
        private UserManager<ProjeUser> _userManager;
        public SepetController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }
        
        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> SepetIncompleteList(string searchEmail)
        {
            if (string.IsNullOrEmpty(searchEmail))
            {
                var yarımKalanSepetler = _sepetService.SepetsAndUserIncomplete();
                var model = new SepetModel()
                {
                    Sepets = yarımKalanSepetler,
                    UserSepets = new List<Sepet>(){}
                };
                return View(model);
            } else
            {
                var user = await _userManager.FindByEmailAsync(searchEmail);
                if (user != null)
                {
                    var userSepetIncompletes = _sepetService.SepetsAndUserIncomplete().Where(i => i.ProjeUserId == user.Id).OrderByDescending(i => i.SepetId).ToList();
                    
                    var modelUser = new SepetModel()
                    {
                        UserSepets = userSepetIncompletes,
                        Sepets = new List<Sepet>(){}
                    };
                    return View(modelUser);
                }
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SepetIncompleteList", "Sepet");
        }

        [HttpGet]
        public IActionResult SepetIncompleteDetail(int id)
        {
            var sepetDetail = _sepetService.SepetAndProductsIncomplete(id);
            if (sepetDetail != null)
            {
                var model = new SepetModel()
                {
                    Sepet = sepetDetail
                };
                return View(model);
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SepetIncompleteList", "Sepet");
        }
    }
}
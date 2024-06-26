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
    [Authorize(Roles = "Admin, Anasayfa")]
    public class AdminController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        ProductManager _productService = new ProductManager(new ProductDal());
        MessageManager _messageService = new MessageManager(new MessageDal());
        SubscribeManager _subscribeService = new SubscribeManager(new SubscribeDal());
        private UserManager<ProjeUser> _userManager;
        public AdminController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }


        // METOTLAR ------------------------------------------------------------
        public IActionResult Home()
        {
            var model = new AdminHomeModel(){
                Product = _productService.GetAll().Count(),
                Message = _messageService.GetAll().Count(),
                Subscribe = _subscribeService.GetAll().Count(),
                User = _userManager.Users.Count()
            };
            return View(model);
        }
    }
}
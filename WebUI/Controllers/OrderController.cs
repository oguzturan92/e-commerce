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
    public class OrderController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        OrderManager _orderService = new OrderManager(new OrderDal());
        AdresManager _adresService = new AdresManager(new AdresDal());
        private UserManager<ProjeUser> _userManager;
        public OrderController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }

        // METOTLAR ------------------------------------------------------------
        [Authorize(Roles = "Admin, Sipariş")]
        [HttpGet]
        public async Task<IActionResult> OrderList(string searchEmail)
        {
            if (string.IsNullOrEmpty(searchEmail))
            {
                var order = _orderService.GetAll().OrderByDescending(i => i.OrderDateTime).ToList();
                if (order != null)
                {
                    var model = new OrderModel()
                    {
                        Orders = order,
                        UserOrders = new List<Order>(){}
                    };
                    return View(model);
                }
            } else
            {
                var user = await _userManager.FindByEmailAsync(searchEmail);
                if (user != null)
                {
                    var userOrders = _orderService.GetAll().Where(i => i.ProjeUserId == user.Id).OrderByDescending(i => i.OrderDateTime).ToList();
                    
                    var modelUser = new OrderModel()
                    {
                        UserOrders = userOrders,
                        Orders = new List<Order>(){}
                    };
                    return View(modelUser);
                }
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderList", "Order");
        }
        
        [Authorize(Roles = "Admin, Sipariş")]
        [HttpGet]
        public async Task<IActionResult> OrderDetail(int id)
        {
            var order = _orderService.OrderDetail(id);
            if (order != null)
            {
                var model = new OrderModel()
                {
                    Order = order,
                    User = await _userManager.FindByIdAsync(order.ProjeUserId.ToString())
                };
                return View(model);
            }
            return View();
        }
        
        [Authorize(Roles = "Admin, Sipariş")]
        [HttpGet]
        public IActionResult OrderEdit(int id)
        {
            var order = _orderService.OrderDetail(id);
            if (order != null)
            {
                var model = new OrderModel()
                {
                    Order = order
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderList", "Order");
        }
        
        [Authorize(Roles = "Admin, Sipariş")]
        [HttpPost]
        public IActionResult OrderEdit(OrderModel model)
        {
            var order = _orderService.OrderDetail(model.Order.OrderId);
            if (order != null)
            {
                order.OrderState = model.Order.OrderState;
                
                _orderService.Update(order);

                TempData["icon"] = "success";
                TempData["title"] = "Sipariş güncellendi.";
                return RedirectToAction("OrderList", "Order");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderList", "Order");
        }
        
        [Authorize(Roles = "Admin, Sipariş")]
        public IActionResult OrderDelete(int id)
        {   
            var order = _orderService.GetById(id);
            if (order != null)
            {
                _orderService.Delete(order);

                TempData["icon"] = "success";
                TempData["title"] = "Sipariş silindi.";
                return RedirectToAction("OrderList", "Order");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderList", "Order");
        }

        // CLIENT METOTLAR ------------------------------------------------------------
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrderListClient()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new OrderModel()
                    {
                        Orders = _orderService.OrdersAndLines(user.Id)
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
    }
}
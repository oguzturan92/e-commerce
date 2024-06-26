using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class OrderIadeController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        OrderIadeManager _orderIadeService = new OrderIadeManager(new OrderIadeDal());
        OrderManager _orderService = new OrderManager(new OrderDal());
        private UserManager<ProjeUser> _userManager;
        public OrderIadeController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }

        // METOTLAR ------------------------------------------------------------
        [Authorize(Roles = "Admin, Sipariş")]
        [HttpGet]
        public async Task<IActionResult> OrderIadeList(string searchEmail)
        {
            if (string.IsNullOrEmpty(searchEmail))
            {                
                var iadeListesi = _orderIadeService.GetAll().OrderByDescending(i => i.OrderIadeDate).ToList();
                var model = new OrderIadeModel()
                {
                    OrderIades = iadeListesi,
                    UserOrderIades = new List<OrderIade>(){}
                };
                return View(model);
            } else
            {
                var user = await _userManager.FindByEmailAsync(searchEmail);
                if (user != null)
                {
                    var userOrderIades = _orderIadeService.UserAndOrderIades(user.Id);
                    
                    var modelUser = new OrderIadeModel()
                    {
                        UserOrderIades = userOrderIades,
                        OrderIades = new List<OrderIade>(){}
                    };
                    return View(modelUser);
                }
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderIadeList", "OrderIade");
        }
        
        [Authorize(Roles = "Admin, Sipariş")]
        [HttpGet]
        public IActionResult OrderIadeEdit(int id)
        {
            var iadeDetail = _orderIadeService.OrderIadeAndOrder(id);
            if (iadeDetail != null)
            {
                if (iadeDetail.OrderIadeOkundu != true)
                {
                    iadeDetail.OrderIadeOkundu = true;
                    _orderIadeService.Update(iadeDetail);
                }

                var model = new OrderIadeModel()
                {
                    OrderIade = iadeDetail
                };
                return View(model);
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderIadeList", "OrderIade");
        }
        
        [Authorize(Roles = "Admin, Sipariş")]
        [HttpPost]
        public IActionResult OrderIadeEdit(OrderIadeModel model)
        {
            var iadeLine = _orderIadeService.GetById(model.OrderIade.OrderIadeId);
            if (iadeLine != null)
            {
                iadeLine.OrderIadeId = model.OrderIade.OrderIadeId;
                iadeLine.OrderIadeApproval = model.OrderIade.OrderIadeApproval;
                _orderIadeService.Update(iadeLine);

                if (model.OrderIade.OrderIadeApproval == "Ret")
                {
                    var orderLine = _orderService.OrderAndLine(model.OrderIade.OrderId).OrderLines.Where(i => i.OrderLineId == model.OrderIade.OrderLineId).FirstOrDefault();
                    
                    orderLine.IadeEdilebilirAdet = orderLine.IadeEdilebilirAdet + iadeLine.IadeUrunAdet;
                    var context = new ProjeContext();
                    context.Update<OrderLine>(orderLine);
                    context.SaveChanges();
                }
                TempData["icon"] = "success";
                TempData["title"] = "İade güncellendi.";
                return RedirectToAction("OrderIadeList", "OrderIade", new { id = model.OrderIade.OrderIadeId});
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderIadeList", "OrderIade");
        }
        
        [Authorize(Roles = "Admin, Sipariş")]
        public IActionResult OrderIadeDelete(int orderIadeId)
        {
            var iadeLine = _orderIadeService.GetById(orderIadeId);
            if (iadeLine != null)
            {
                if (iadeLine.OrderIadeApproval != "Bekliyor")
                {
                    _orderIadeService.Delete(iadeLine);

                    TempData["icon"] = "success";
                    TempData["title"] = "İade talebi silindi.";
                    return RedirectToAction("OrderIadeList", "OrderIade");
                }
                TempData["iconOK"] = "error";
                TempData["iconText"] = "İade durumu ONAY ya da RET olanlar silinebilir.";
                return RedirectToAction("OrderIadeList", "OrderIade");
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "İade talebi bulunamadı. Lütfen tekrar deneyin.";
            return RedirectToAction("OrderIadeList", "OrderIade");
        }

        // CLIENT METOTLARI ------------------------------------------------------------
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrderIadeCreate(int orderId)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var order = _orderService.OrderAndLineIade(orderId, user.Id);
                    if (order != null)
                    {
                        var model = new OrderIadeModel()
                        {
                            Order = order,
                            SelectedOrderLineIds = new List<int>{}
                        };
                        return View(model);
                    }
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> OrderIadeCreate(OrderIadeModel model)
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (ModelState.IsValid)
                    {
                        var order = _orderService.OrderAndLineIade(model.OrderId, user.Id);
                        if (order != null)
                        {
                            for (int i = 0; i < model.SelectedOrderLineIds.Count(); i++)
                            {
                                var a = i;
                                var orderLine = order.OrderLines.Where(i => i.OrderLineId == model.SelectedOrderLineIds[a]).FirstOrDefault();
                                var adet = model.IadeAdedi[i];

                                var entity = new OrderIade()
                                {
                                    OrderId = orderLine.OrderId,
                                    OrderLineId = orderLine.OrderLineId,
                                    OrderIadeNedeni = model.OrderIadeNedeni,
                                    OrderIadeNot = model.OrderIadeNot,
                                    OrderIadeApproval = "Bekliyor",
                                    BankName = model.BankName,
                                    BankIban = model.BankIban,
                                    OrderIadeDate = DateTime.Now,
                                    IadeUrunId = orderLine.ProductId,
                                    IadeUrunKodu = orderLine.ProductCode,
                                    IadeUrunAdi = orderLine.ProductName,
                                    IadeUrunImage = orderLine.ProductImage,
                                    IadeUrunUrl = orderLine.ProductUrl,
                                    IadeUrunOzellik = orderLine.ProductSize,
                                    IadeUrunBirimFiyati = orderLine.OrderLineProductPrice,
                                    IadeUrunIndirimFiyati = orderLine.OrderLineCampaignPrice,
                                    IadeUrunAdet = adet
                                };

                                if (orderLine.IadeEdilebilirAdet - adet < 0)
                                {
                                    TempData["iconError"] = "error";
                                    TempData["iconErrorText"] = "Ürün iade edilebilir limiti aşılamaz.";
                                    return RedirectToAction("OrderIadeCreate", "OrderIade", new { orderId = model.OrderId} );
                                }

                                _orderIadeService.Create(entity);
                                
                                orderLine.IadeEdilebilirAdet = orderLine.IadeEdilebilirAdet - adet;
                                var context = new ProjeContext();
                                context.Update<OrderLine>(orderLine);
                                context.SaveChanges();
                            }
                            TempData["iconSuccess"] = "success";
                            TempData["iconSuccessText"] = "İade talebiniz alındı.";
                            return RedirectToAction("OrderListClient", "Order");
                        }
                        TempData["iconError"] = "error";
                        TempData["iconErrorText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
                        return RedirectToAction("OrderListClient", "Order");
                    }
                    model.Order = _orderService.OrderAndLineIade(model.OrderId, user.Id);
                    if (model.SelectedOrderLineIds == null)
                    {
                        model.SelectedOrderLineIds = new List<int>{};
                    }
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrderIadeListClient()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new OrderModel()
                    {
                        Orders = _orderService.OrdersAndIadeLines(user.Id)
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
    


    }
}
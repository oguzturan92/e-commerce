using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.ViewComponents.CartList
{
    public class CartListViewComponent : ViewComponent
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SepetManager _sepetService = new SepetManager(new SepetDal());
        private UserManager<ProjeUser> _userManager;
        public CartListViewComponent(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }
        // METOTLAR ------------------------------------------------------------
        public async Task<string> InvokeAsync()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var sepet = _sepetService.SepetAndProducts(user.Id);
                    if (sepet != null)
                    {
                        List<int> sayi = new List<int>();
                        foreach (var item in sepet.SepetLines)
                        {
                            sayi.Add(item.ProductQuantity);
                        }
                        return sayi.Sum().ToString();
                    }
                }
            } else
            {
                // Sepete, kaç adet ürün olduğu bilgisini taşır.
                var products = HttpContext.Session.GetJson<Cart>("Cart")?.Product;
                if (products != null)
                {
                    List<int> sayi = new List<int>();
                    foreach (var item in products)
                    {
                        sayi.Add(item.ProductQuantity);
                    }
                    return sayi.Sum().ToString();
                }
            }
            return "0";
        }
    }
}
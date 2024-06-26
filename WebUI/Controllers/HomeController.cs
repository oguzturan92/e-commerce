using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        HomeDesignTypeManager _homeDesignTypeService = new HomeDesignTypeManager(new HomeDesignTypeDal());
        ProductManager _productService = new ProductManager(new ProductDal());
        BannerManager _bannerService = new BannerManager(new BannerDal());
        SliderManager _sliderService = new SliderManager(new SliderDal());
        SettingManager _settingService = new SettingManager(new SettingDal());
        
        // METOTLAR ------------------------------------------------------------
        public IActionResult Index()
        {
            var home = new HomeModel(){
                HomeDesignTypes = _homeDesignTypeService.HomeDesignTypes(),
                Banners = _bannerService.GetAll().Where(i => i.BannerApproval).ToList(),
                Sliders = _sliderService.GetAll().Where(i => i.SliderApproval).ToList(),
                Setting = _settingService.GetAll().FirstOrDefault()
            };
            return View(home);
        }

        [HttpGet]
        public IActionResult Search(string q)
        {
            if (q == null)
            {
                return NotFound();
            } else
            {
                var model = new ProductListModel(){
                    Products = _productService.Search(q)
                    // Search metoduna göre elemanları alıp, Products değişkenine atarak model'e gönderdik ve model'is .cshtml dosyası içinde açtık
                };
                return View(model);
            }
        }
    }
}

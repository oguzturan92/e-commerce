using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using WebUI.Models;

namespace WebUI.ViewComponents.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        FooterManager _footerService = new FooterManager(new FooterDal());
        
        // METOTLAR ------------------------------------------------------------
        public IViewComponentResult Invoke()
        {
            var model = new FooterModel()
            {
                Footers = _footerService.FooterAndAltList()
            };
            return View(model);
        }
    }
}
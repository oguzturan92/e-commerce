using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using WebUI.Models;

namespace WebUI.ViewComponents.Popup
{
    public class PopupViewComponent : ViewComponent
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        PopupManager _popupService = new PopupManager(new PopupDal());
        
        // METOTLAR ------------------------------------------------------------
        public IViewComponentResult Invoke()
        {
            var model = new PopupModel()
            {
                Popup= _popupService.GetAll().Where(i => i.PopupApproval).OrderBy(i => i.PopupSort).FirstOrDefault()
            };
            return View(model);
        }
    }
}
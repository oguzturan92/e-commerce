using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using ProjeEntity.Concrete;

namespace WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        CategoryManager _categoryService = new CategoryManager(new CategoryDal());
        
        // METOTLAR ------------------------------------------------------------
        public IViewComponentResult Invoke()
        {
            var model = new CategoryModel()
            {
                Categories = _categoryService.CategoryMenu()
            };
            return View(model);
        }
    }
}
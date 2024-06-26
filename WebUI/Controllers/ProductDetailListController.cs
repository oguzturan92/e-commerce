using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductDetailListController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        HomeDesignTypeManager _homeDesignTypeService = new HomeDesignTypeManager(new HomeDesignTypeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult ProductDetailListList(int? id)
        {
            var model = new HomeDesignTypeModel(){
                HomeDesignTypes = _homeDesignTypeService.GetAll().Where(i => i.HomeDesignTypeOption == "DetailList").OrderBy(i => i.HomeDesignTypeSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult HomeDesignTypeList(HomeDesignTypeModel model)
        {
            var entity = _homeDesignTypeService.GetById(model.HomeDesignTypeId);
            if (entity != null)
            {
                entity.HomeDesignTypeSort = model.HomeDesignTypeSort;
                _homeDesignTypeService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("HomeDesignTypeList", "HomeDesignType");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("HomeDesignTypeList", "HomeDesignType");
        }

        [HttpGet]
        public IActionResult HomeDesignTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HomeDesignTypeCreate(HomeDesignTypeModel model)
        {
            if(model.HomeDesignTypeSort == null)
            {
                model.HomeDesignTypeSort = 0;
            }

            var entity = new HomeDesignType()
            {
                HomeDesignTypeName = model.HomeDesignTypeName,
                HomeDesignTypeOption = model.HomeDesignTypeOption,
                HomeDesignTypeApproval = model.HomeDesignTypeApproval,
                HomeDesignTypeSort = model.HomeDesignTypeSort
            };

            if (ModelState.IsValid)
            {
                _homeDesignTypeService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Dizayn oluşturuldu.";
                return RedirectToAction("HomeDesignTypeList", "HomeDesignType");
            } else
            {
                return View(model);
            }
        }
    
        [HttpGet]
        public IActionResult HomeDesignTypeEdit(int id)
        {
            var entity = _homeDesignTypeService.GetById(id);
            if (entity != null)
            {
                var model = new HomeDesignTypeModel()
                {
                    HomeDesignTypeId = entity.HomeDesignTypeId,
                    HomeDesignTypeName = entity.HomeDesignTypeName,
                    HomeDesignTypeOption = entity.HomeDesignTypeOption,
                    HomeDesignTypeApproval = entity.HomeDesignTypeApproval,
                    HomeDesignTypeSort = entity.HomeDesignTypeSort,
                    HomeDesignTypeBannerList = entity.HomeDesignTypeBannerList,
                    HomeDesignTypeProductList = entity.HomeDesignTypeProductList
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("HomeDesignTypeList", "HomeDesignType");
        }

        [HttpPost]
        public IActionResult HomeDesignTypeEdit(HomeDesignTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new HomeDesignType()
                {
                    HomeDesignTypeId = model.HomeDesignTypeId,
                    HomeDesignTypeName = model.HomeDesignTypeName,
                    HomeDesignTypeOption = model.HomeDesignTypeOption,
                    HomeDesignTypeApproval = model.HomeDesignTypeApproval,
                    HomeDesignTypeSort = model.HomeDesignTypeSort,
                    HomeDesignTypeBannerList = model.HomeDesignTypeBannerList,
                    HomeDesignTypeProductList = model.HomeDesignTypeProductList
                };

                _homeDesignTypeService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Dizayn güncellendi.";
                return RedirectToAction("HomeDesignTypeList", "HomeDesignType");
            } else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult HomeDesignTypeDelete(int id)
        {
            var entity = _homeDesignTypeService.GetById(id);
            if (entity != null)
            {
                _homeDesignTypeService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Dizayn silindi.";
                return RedirectToAction("HomeDesignTypeList", "HomeDesignType");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("HomeDesignTypeList", "HomeDesignType");
        }

    }
}
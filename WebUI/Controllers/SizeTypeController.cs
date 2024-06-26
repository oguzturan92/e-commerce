using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Seçenek")]
    public class SizeTypeController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SizeTypeManager _sizeTypeService = new SizeTypeManager(new SizeTypeDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult SizeTypeList()
        {
            var model = new SizeTypeModel(){
                 SizeTypes = _sizeTypeService.GetAll().OrderBy(i => i.SizeTypeSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SizeTypeList(SizeTypeModel model)
        {
            var entity = _sizeTypeService.GetById(model.SizeTypeId);
            if (entity != null)
            {
                entity.SizeTypeSort = model.SizeTypeSort;
                _sizeTypeService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("SizeTypeList", "SizeType");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SizeTypeList", "SizeType");
        }

        [HttpGet]
        public IActionResult SizeTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SizeTypeCreate(SizeTypeModel model)
        {
            if(model.SizeTypeSort == null)
            {
                model.SizeTypeSort = 0;
            }

            var entity = new SizeType()
            {
                SizeTypeName = model.SizeTypeName,
                SizeTypeSort = model.SizeTypeSort
            };

            if (ModelState.IsValid)
            {
                _sizeTypeService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Varyasyon oluşturuldu.";
                return RedirectToAction("SizeTypeList", "SizeType");
            } else
            {
                return View(model);
            }
        }
    
        [HttpGet]
        public IActionResult SizeTypeEdit(int id)
        {
            var entity = _sizeTypeService.GetById(id);
            if (entity != null)
            {
                var model = new SizeTypeModel()
                {
                    SizeTypeId = entity.SizeTypeId,
                    SizeTypeName = entity.SizeTypeName,
                    SizeTypeSort = entity.SizeTypeSort,
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SizeTypeList", "SizeType");
        }

        [HttpPost]
        public IActionResult SizeTypeEdit(SizeTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new SizeType()
                {
                    SizeTypeId = model.SizeTypeId,
                    SizeTypeName = model.SizeTypeName,
                    SizeTypeSort = model.SizeTypeSort,
                };

                _sizeTypeService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Varyasyon güncellendi.";
                return RedirectToAction("SizeTypeEdit", "SizeType", new { id = model.SizeTypeId});
            } else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SizeTypeDelete(int id)
        {
            var entity = _sizeTypeService.GetById(id);
            if (entity != null)
            {
                _sizeTypeService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Varyasyon silindi.";
                return RedirectToAction("SizeTypeList", "SizeType");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("SizeTypeList", "SizeType");
        }

    }
}
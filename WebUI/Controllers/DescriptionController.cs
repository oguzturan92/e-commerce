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
    [Authorize(Roles = "Admin, Ürün")]
    public class DescriptionController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        DescriptionManager _descriptionService = new DescriptionManager(new DescriptionDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult DescriptionList(int id)
        {
            var entities = _descriptionService.GetAll().Where(i => i.ProductId == id).OrderBy(i => i.DescriptionSort).ToList();
            if (entities != null)
            {
                var model = new DescriptionModel(){
                    Descriptions = entities,
                    ProductId = id
                };
                return View(model);
            }
            return RedirectToAction("ProductList", "Product");
        }

        [HttpPost]
        public IActionResult DescriptionList(DescriptionModel model)
        {
            var entity = _descriptionService.GetById(model.DescriptionId);
            if (entity != null)
            {
                entity.DescriptionSort = model.DescriptionSort;
                _descriptionService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("DescriptionList", "Description", new { id = model.ProductId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("DescriptionList", "Description", new { id = model.ProductId });
        }

        [HttpGet]
        public IActionResult DescriptionCreate(int proId)
        {
            var model = new DescriptionModel() {
                ProductId = proId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult DescriptionCreate(DescriptionModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.DescriptionSort == null)
                {
                    model.DescriptionSort = 0;
                }

                var entity = new Description()
                {
                    DescriptionName = model.DescriptionName,
                    DescriptionContent = model.DescriptionContent,
                    DescriptionApproval = model.DescriptionApproval,
                    DescriptionSort = model.DescriptionSort,
                    ProductId = model.ProductId
                };

                _descriptionService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Açıklama oluşturuldu.";
                return RedirectToAction("DescriptionList", "Description", new { id = model.ProductId });
            }
            return View(model);
        }
    
        [HttpGet]
        public IActionResult DescriptionEdit(DescriptionModel model1, int id)
        {
            var entity = _descriptionService.GetById(id);
            if (entity != null)
            {
                var model = new DescriptionModel()
                {
                    DescriptionId = entity.DescriptionId,
                    DescriptionName = entity.DescriptionName,
                    DescriptionContent = entity.DescriptionContent,
                    DescriptionApproval = entity.DescriptionApproval,
                    DescriptionSort = entity.DescriptionSort,
                    ProductId = entity.ProductId
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("DescriptionList", "Description", new { id = model1.ProductId });
        }

        [HttpPost]
        public IActionResult DescriptionEdit(DescriptionModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Description()
                {
                    DescriptionId = model.DescriptionId,
                    DescriptionName = model.DescriptionName,
                    DescriptionContent = model.DescriptionContent,
                    DescriptionApproval = model.DescriptionApproval,
                    DescriptionSort = model.DescriptionSort,
                    ProductId = model.ProductId
                };

                _descriptionService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Açıklama güncellendi.";
                return RedirectToAction("DescriptionEdit", "Description", new { id = model.DescriptionId });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DescriptionDelete(int id, int proId)
        {
            var entity = _descriptionService.GetById(id);
            if (entity != null)
            {
                _descriptionService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Açıklama silindi.";
                return RedirectToAction("DescriptionList", "Description", new { id = entity.ProductId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("DescriptionList", "Description", new { id = proId });
        }

    }
}
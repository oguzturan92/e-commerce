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
    [Authorize(Roles = "Admin, Kargo")]
    public class CargoController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        CargoManager _cargoService = new CargoManager(new CargoDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult CargoList()
        {
            var model = new CargoModel()
            {
                Cargos = _cargoService.GetAll().OrderBy(i => i.CargoSort).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CargoList(CargoModel model)
        {
            var entity = _cargoService.GetById(model.CargoId);
            if (entity != null)
            {
                entity.CargoSort = model.CargoSort;
                _cargoService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("CargoList", "Cargo");
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CargoList", "Cargo");
        }

        [HttpGet]
        public IActionResult CargoCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CargoCreate(CargoModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CargoSort == null)
                {
                    model.CargoSort = 0;
                }

                var entity = new Cargo()
                {
                    CargoName = model.CargoName,
                    CargoFreePrice = model.CargoFreePrice,
                    CargoPrice = model.CargoPrice,
                    CargoApproval = model.CargoApproval,
                    CargoSort = model.CargoSort
                };
                _cargoService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kargo oluşturuldu.";
                return RedirectToAction("CargoList", "Cargo");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CargoEdit(int id)
        {
            var entity = _cargoService.GetById(id);
            if (entity != null)
            {
                var model = new CargoModel()
                {
                    CargoId = entity.CargoId,
                    CargoName = entity.CargoName,
                    CargoFreePrice = entity.CargoFreePrice,
                    CargoPrice = entity.CargoPrice,
                    CargoApproval = entity.CargoApproval,
                    CargoSort = entity.CargoSort
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CargoList", "Cargo");
        }

        [HttpPost]
        public IActionResult CargoEdit(CargoModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Cargo()
                {
                    CargoId = model.CargoId,
                    CargoName = model.CargoName,
                    CargoFreePrice = model.CargoFreePrice,
                    CargoPrice = model.CargoPrice,
                    CargoApproval = model.CargoApproval,
                    CargoSort = model.CargoSort
                };
                _cargoService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Kargo güncellendi.";
                return RedirectToAction("CargoEdit", "Cargo", new { id = model.CargoId });
            }
            return View(model);
        }

        public IActionResult CargoDelete(int id)
        {
            var cargoAdet = _cargoService.GetAll().Count();
            if (cargoAdet > 1)
            {
                var entity = _cargoService.GetById(id);
                if (entity != null)
                {
                    _cargoService.Delete(entity);

                    TempData["icon"] = "success";
                    TempData["title"] = "Kargo silindi.";
                    return RedirectToAction("CargoList", "Cargo");
                }
            } else
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "En az 1 adet kargo ögesi bulunmalıdır.";
                return RedirectToAction("CargoList", "Cargo");
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("CargoList", "Cargo");

        }
    }
}
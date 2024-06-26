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
    public class ListController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        ListManager _listService = new ListManager(new ListDal());
        ProductManager _productService = new ProductManager(new ProductDal());

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult ListList(int id)
        {
            var proId = id;
            var model = new ListModel(){
                Lists = _listService.GetAll().Where(i => i.ProductId == proId || i.ListLocation == "Genel").OrderBy(i => i.ListSort).ToList(),
                ProductId = proId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ListList(ListModel model)
        {
            var entity = _listService.GetById(model.ListId);
            if (entity != null)
            {
                entity.ListSort = model.ListSort;
                _listService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Sıralama güncellendi.";
                return RedirectToAction("ListList", "List", new { id = model.ProductId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

        [HttpGet]
        public IActionResult ListCreate(int id)
        {
            var proId = id;
            var model = new ListModel(){
                ProductId = proId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ListCreate(ListModel model)
        {
            if(model.ListSort == null)
            {
                model.ListSort = 0;
            }

            var entity = new List()
            {
                ListTitle = model.ListTitle,
                ListLocation = model.ListLocation,
                ListType = model.ListType,
                ListApproval = model.ListApproval,
                ListSort = model.ListSort,
                ListColumn = model.ListColumn,
                ProductId = model.ProductId
            };

            if (ModelState.IsValid)
            {
                _listService.Create(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Liste oluşturuldu.";
                return RedirectToAction("ListList", "List", new { id = model.ProductId });
            }
            return View(model);
        }
    
        [HttpGet]
        public IActionResult ListEdit(int id, int proId)
        {
            var listId = id;
            var entity = _listService.GetById(listId);
            if (entity != null)
            {
                var model = new ListModel()
                {
                    ListId = entity.ListId,
                    ListTitle = entity.ListTitle,
                    ListLocation = entity.ListLocation,
                    ListType = entity.ListType,
                    ListApproval = entity.ListApproval,
                    ListSort = entity.ListSort,
                    ListColumn = entity.ListColumn,
                    ProductId = entity.ProductId,
                    ProId = proId
                };
                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

        [HttpPost]
        public IActionResult ListEdit(ListModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new List()
                {
                    ListId = model.ListId,
                    ListTitle = model.ListTitle,
                    ListLocation = model.ListLocation,
                    ListType = model.ListType,
                    ListApproval = model.ListApproval,
                    ListSort = model.ListSort,
                    ListColumn = model.ListColumn,
                    ProductId = model.ProductId
                };

                _listService.Update(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Liste güncellendi.";
                return RedirectToAction("ListEdit", "List", new { id = entity.ListId, model.ProId });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult ListDelete(int id, int proId)
        {
            var entity = _listService.GetById(id);
            if (entity != null)
            {
                _listService.Delete(entity);

                TempData["icon"] = "success";
                TempData["title"] = "Liste silindi.";
                return RedirectToAction("ListList", "List", new { id = proId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

        [HttpGet]
        public IActionResult ListProductList(int id, int proId, string searchName, int? searchId)
        {
            var seciliUrünler = _listService.ListIdyeGoreProducts(id);

            List<int> seciliProIds = new List<int>();
            foreach (var pro in seciliUrünler.ProductLists)
            {
                seciliProIds.Add(pro.ProductId);
            }

            if (searchName != null)
            {
                var model1 = new ListModel(){
                    Products = _productService.GetAll()
                        .Where(i => i.ProductName.ToLower().Contains(searchName.ToLower()) && !seciliProIds.Contains(i.ProductId))
                        .Take(10).ToList(),
                    List = seciliUrünler,
                    ProId = proId
                };
                return View(model1);
            }

            if (searchId != null)
            {
                var model2 = new ListModel(){
                    Products = _productService.GetAll()
                        .Where(i => i.ProductId == searchId && !seciliProIds.Contains(i.ProductId)).ToList(),
                    List = seciliUrünler,
                    ProId = proId
                };
                return View(model2);
            }
            
            var model = new ListModel(){
                Products = _productService.GetAll()
                                            .Where(i => !seciliProIds.Contains(i.ProductId))
                                            .OrderBy(i => i.ProductSort).Take(5).ToList(),
                List = seciliUrünler,
                ProId = proId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ListPlus(int listId, int proId, int productId)
        {
            var entity = _listService.GetById(listId);
            if (entity != null)
            {
                List<ProductList> productLists = new List<ProductList>();
                productLists.Add(new ProductList()
                {
                    ListId = listId,
                    ProductId = productId
                });

                _listService.ListeProductCreate(listId, productLists);

                TempData["icon"] = "success";
                TempData["title"] = "Listeye Eklendi.";
                return RedirectToAction("ListProductList", "List", new { id = listId, proId = proId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

        [HttpPost]
        public IActionResult ListMinus(int listId, int proId, int productId)
        {
            var entity = _listService.GetById(listId);
            if (entity != null)
            {
                _listService.ListtenProductDelete(listId, productId);

                TempData["icon"] = "success";
                TempData["title"] = "Listeden Silindi.";
                return RedirectToAction("ListProductList", "List", new { id = listId, proId = proId });
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("ProductList", "Product");
        }

    }
}
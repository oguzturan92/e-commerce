using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeBusiness.Concrete;
using ProjeBusiness.Validators;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class GiftCardController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        GiftCardManager _giftCardService = new GiftCardManager(new GiftCardDal());
        private UserManager<ProjeUser> _userManager;
        public GiftCardController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }

        // METOTLAR ------------------------------------------------------------
        [Authorize(Roles = "Admin, Hediye Çeki")]
        [HttpGet]
        public IActionResult GiftCardList()
        {
            var model = new GiftCardModel()
            {
                GiftCards = _giftCardService.GetAll().OrderByDescending(i => i.GiftCardDateTime).ToList()
            };
            return View(model);
        }

        [Authorize(Roles = "Admin, Hediye Çeki")]
        [HttpGet]
        public async Task<IActionResult> GiftCardCreate(string userName, string userEmail)
        {
            if (userName != null)
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new GiftCardModel()
                    {
                        GiftCardUsers = new List<GiftCardUser>() {
                            new GiftCardUser() { ProjeUser = user }
                        }
                    };
                    return View(model);
                }
                ModelState.AddModelError("userName", "kullanıcı adı ile eşleşen kayıt bulunamadı.");
            }
            if (userEmail != null)
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user != null)
                {
                    var model = new GiftCardModel()
                    {
                        GiftCardUsers = new List<GiftCardUser>() {
                            new GiftCardUser() { ProjeUser = user }
                        }
                    };
                    return View(model);
                }
                ModelState.AddModelError("userEmail", "e-mail adresi ile eşleşen kayıt bulunamadı.");
            }

            var model1 = new GiftCardModel()
            {
                GiftCardUsers = new List<GiftCardUser>() {}
            };
            return View(model1);
        }

        [Authorize(Roles = "Admin, Hediye Çeki")]
        [HttpPost]
        public IActionResult GiftCardCreate(GiftCardModel model, int userId)
        {
            if (ModelState.IsValid)
            {
                var giftCard = _giftCardService.GiftCardAndUser(model.GiftCardTitle);
                if (giftCard == null)
                {
                    if (userId != 0)
                    {
                        var entity = new GiftCard()
                        {
                            GiftCardTitle = model.GiftCardTitle,
                            GiftCardOran = model.GiftCardOran,
                            GiftCardMiktar = model.GiftCardMiktar,
                            GiftCardApproval = model.GiftCardApproval,
                            GiftCardLimit = model.GiftCardLimit,
                            GiftCardDateTime = DateTime.Now,
                            GiftCardUsers = new List<GiftCardUser>() {
                                new GiftCardUser() { ProjeUserId = userId}
                            }
                        };

                        GiftCardModelValidator giftCardModelValidator = new GiftCardModelValidator();
                        ValidationResult results = giftCardModelValidator.Validate(entity);
                        if (results.IsValid)
                        {
                            
                                _giftCardService.Create(entity);
                        } else
                        {
                            foreach (var item in results.Errors)
                            {
                                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                            }
                            model.GiftCardUsers = new List<GiftCardUser>(){};
                            return View(model);
                        }
                        
                    } else
                    {
                        var entity = new GiftCard()
                        {
                            GiftCardTitle = model.GiftCardTitle,
                            GiftCardOran = model.GiftCardOran,
                            GiftCardMiktar = model.GiftCardMiktar,
                            GiftCardApproval = model.GiftCardApproval,
                            GiftCardLimit = model.GiftCardLimit,
                            GiftCardDateTime = DateTime.Now
                        };

                        GiftCardModelValidator giftCardModelValidator = new GiftCardModelValidator();
                        ValidationResult results = giftCardModelValidator.Validate(entity);
                        if (results.IsValid)
                        {
                            
                                _giftCardService.Create(entity);
                        } else
                        {
                            foreach (var item in results.Errors)
                            {
                                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                            }
                            model.GiftCardUsers = new List<GiftCardUser>(){};
                            return View(model);
                        }
                    }
                    TempData["icon"] = "success";
                    TempData["title"] = "Hediye Çeki oluşturuldu.";
                    return RedirectToAction("GiftCardList", "GiftCard");
                } else
                {
                    ModelState.AddModelError("GiftCardTitle", "Bu isimde bir hediye çeki zaten mevcut.");
                }
            }
            model.GiftCardUsers = new List<GiftCardUser>(){};
            return View(model);
        }

        [Authorize(Roles = "Admin, Hediye Çeki")]
        [HttpGet]
        public async Task<IActionResult> GiftCardEdit(int id, string userName, string userEmail)
        {
            var entity = _giftCardService.GiftCardAndUser(id);
            if (entity != null)
            {
                var model = new GiftCardModel()
                {
                    GiftCardId = entity.GiftCardId,
                    GiftCardTitle = entity.GiftCardTitle,
                    GiftCardOran = entity.GiftCardOran,
                    GiftCardMiktar = entity.GiftCardMiktar,
                    GiftCardApproval = entity.GiftCardApproval,
                    GiftCardLimit = entity.GiftCardLimit,
                    GiftCardDateTime = entity.GiftCardDateTime,
                    GiftCardUsers = entity.GiftCardUsers,
                    SelectedGiftCardUsers = entity.GiftCardUsers.Select(p => p.ProjeUser).ToList()
                };

                if (userName != null)
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    if (user != null)
                    {
                        model.GiftCardUsers.Add(new GiftCardUser() {
                            GiftCard = entity,
                            GiftCardId = id,
                            ProjeUser = user,
                            ProjeUserId = user.Id
                        });
                    } else
                    {
                        ModelState.AddModelError("userName", "kullanıcı adı ile eşleşen kayıt bulunamadı.");
                    }
                }
                if (userEmail != null)
                {
                    var user = await _userManager.FindByEmailAsync(userEmail);
                    if (user != null)
                    {
                        model.GiftCardUsers.Add(new GiftCardUser() {
                            GiftCard = entity,
                            GiftCardId = id,
                            ProjeUser = user,
                            ProjeUserId = user.Id
                        });
                    } else
                    {
                        ModelState.AddModelError("userEmail", "e-mail adresi ile eşleşen kayıt bulunamadı.");
                    }
                }

                return View(model);
            }

            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("GiftCardList", "GiftCard");
        }

        [Authorize(Roles = "Admin, Hediye Çeki")]
        [HttpPost]
        public IActionResult GiftCardEdit(GiftCardModel model, int[] projeUserIds)
        {
            if (ModelState.IsValid)
            {
                var giftCard = _giftCardService.GiftCardAndUser(model.GiftCardTitle);
                
                if ( (giftCard != null && model.GiftCardId == giftCard.GiftCardId ) || giftCard == null)
                {
                    var entity = new GiftCard()
                    {
                        GiftCardId = model.GiftCardId,
                        GiftCardTitle = model.GiftCardTitle,
                        GiftCardOran = model.GiftCardOran,
                        GiftCardMiktar = model.GiftCardMiktar,
                        GiftCardApproval = model.GiftCardApproval,
                        GiftCardLimit = model.GiftCardLimit,
                        GiftCardDateTime = model.GiftCardDateTime
                    };

                        GiftCardModelValidator giftCardModelValidator = new GiftCardModelValidator();
                        ValidationResult results = giftCardModelValidator.Validate(entity);
                    if (results.IsValid)
                    {
                        _giftCardService.Update(entity, projeUserIds);
                    } else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }
                        model.GiftCardUsers = _giftCardService.GiftCardAndUser(model.GiftCardId).GiftCardUsers;
                        model.SelectedGiftCardUsers = _giftCardService.GiftCardAndUser(model.GiftCardId).GiftCardUsers.Select(g => g.ProjeUser).ToList();
                        return View(model);
                    }

                    TempData["icon"] = "success";
                    TempData["title"] = "Hediye Çeki güncellendi.";
                    return RedirectToAction("GiftCardEdit", "GiftCard", new { id = model.GiftCardId });
                }
                if (giftCard != null)
                {
                    ModelState.AddModelError("GiftCardTitle", "Bu isimde bir hediye çeki zaten mevcut.");
                    model.GiftCardUsers = _giftCardService.GiftCardAndUser(model.GiftCardId).GiftCardUsers;
                    model.SelectedGiftCardUsers = _giftCardService.GiftCardAndUser(model.GiftCardId).GiftCardUsers.Select(g => g.ProjeUser).ToList();
                    return View(model);
                }
            }
            model.GiftCardUsers = _giftCardService.GiftCardAndUser(model.GiftCardId).GiftCardUsers;
            model.SelectedGiftCardUsers = _giftCardService.GiftCardAndUser(model.GiftCardId).GiftCardUsers.Select(g => g.ProjeUser).ToList();
            return View(model);
        }

        [Authorize(Roles = "Admin, Hediye Çeki")]
        [HttpPost]
        public IActionResult GiftCardDelete(int id)
        {
            var entity = _giftCardService.GetById(id);
            if (entity != null)
            {
                _giftCardService.Delete(entity);
                TempData["icon"] = "success";
                TempData["title"] = "Hediye Çeki silindi.";
                return RedirectToAction("GiftCardList", "GiftCard");
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("GiftCardList", "GiftCard");
        }

        // CLIENT METOTLARI ------------------------------------------------------------
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GiftCardListClient()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new GiftCardModel()
                    {
                        GiftCards = _giftCardService.GiftCardsUserList(user.Id)
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }
    
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.EmailServis;
using WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeEntity.Concrete;
using ProjeData.Concrete;
using Newtonsoft.Json;
using WebUI.Infrastructure;
using ProjeBusiness.Concrete;

namespace WebUI.Controllers
{
    [AutoValidateAntiforgeryToken] // Csrf Token için. Form güvenliği. Bu Controller içindeki tüm Post metotları etkiler.
    public class UserAccountController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        SepetManager _sepetService = new SepetManager(new SepetDal());
        SepetLineManager _sepetLineService = new SepetLineManager(new SepetLineDal());
        private UserManager<ProjeUser> _userManager; // SignIn(Kullanıcı) işlemlerini yönetecek sınıf
        private SignInManager<ProjeUser> _signInManager; // Kullanıcıya giriş yaptıracak
        private IPasswordValidator<ProjeUser> _passwordValidator; // Şifre değiştirme işlemleri için kullanıcaz
        private IPasswordHasher<ProjeUser> _passwordHasher; // Şifre değiştirme işlemleri için kullanıcaz
        private IEmailGonder _emailGonder; // Email gönderme işlemleri için kullanıcaz
        public UserAccountController(UserManager<ProjeUser> userManager,
            SignInManager<ProjeUser> signInManager,
            IPasswordValidator<ProjeUser> passwordValidator,
            IPasswordHasher<ProjeUser> passwordHasher,
            IEmailGonder emailGonder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
            _emailGonder = emailGonder;
        }
        

        // METOTLAR ------------------------------------------------------------
        public async Task<IActionResult> AccountIndex()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new AccountIndexModel()
                    {
                        UserAdi = user.UserAdi,
                        UserSoyadi = user.UserSoyadi,
                        UserId = user.Id
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpGet]
        public IActionResult AccountRegister()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken] // Action düzeyince Csrf Token için. Sadece Post'lara uygulanır.
        public async Task<IActionResult> AccountRegister(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var emailSorgu = await _userManager.FindByEmailAsync(model.Email);
                if (emailSorgu != null)
                {
                    ModelState.AddModelError("Email", "Bu email adresiyle daha önce kayıt yapılmış.");
                    return View(model);
                }
                
                var user = new ProjeUser()
                {
                    UserName = model.Email,
                    UserAdi = model.UserAdi,
                    UserSoyadi = model.UserSoyadi,
                    Email = model.Email,
                    UserRegisterDate = DateTime.Now
                };

                var yeniUser = await _userManager.CreateAsync(user, model.Password); // user ve model.Password değerlerini yeniUser içine attık

                if (yeniUser.Succeeded)
                {
                    var emailOnayKodu = await _userManager.GenerateEmailConfirmationTokenAsync(user); // Token kodu oluşturur
                    var urlOnayKodu = Url.Action("AccountEmailOnay", "UserAccount", new { // Url Onay Kodu oluşturur.
                        userId = user.Id,
                        token = emailOnayKodu
                        // /Account/EmailOnay/userId/token şeklinde oluşacak, Onay Url. Linke tıklandığında, Account Controllerın EmailOnay Actionuna gidecek.
                    });

                    await _emailGonder.SendEmailAsync(model.Email, "Hesabınızı onaylayınız.", $"Lütfen Email hesabınızı onaylamak için linke <a href='https://localhost:7045{urlOnayKodu}'>tıklayınız.</a>"); // Email gönderen kod. Model'den Email bilgisini alır

                    TempData["icon"] = "success";
                    TempData["text"] = "Hesabın oluşturuldu. Giriş yapabilirsiniz.";
                    return RedirectToAction("AccountLogin", "UserAccount");
                } else
                {
                    TempData["iconOk"] = "error";
                    TempData["iconText"] = "Kullanıcı oluşturulamadı. Lütfen tekrar deneyin.";
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AccountLogin(string ReturnUrl = null)
        {   
            // Login'e yönlendiğimizde(bu metoda), burdan ReturnUrl bilgisini alıp, UserGirisModel içindeki ReturnUrl alanına attık ve _login.cshtml dosyasına yönlendiğimizde input içine Get metodu(bu metot), ReturnUrl bilgisini çekecek. Ordan da Login Post Action'una gönderdik ve ReturnUrl kullanarak giriş yaptırdık. Yani gitmek istediği sayfaya giderken Login olması istenirse, Login olduğunda devam etmek istediği sayfaya yönlendirilcek.
            var returnUrl = new AccountLoginModel(){
                ReturnUrl = ReturnUrl
            };
            return View(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> AccountLogin(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userSorgusu = await _userManager.FindByEmailAsync(model.Email);

                if (userSorgusu != null)
                {
                    if (await _userManager.IsEmailConfirmedAsync(userSorgusu)) // Email onaylı ise
                    {
                        var passwordSorgusu = await _signInManager.PasswordSignInAsync( // Aşağıdaki bilgilerle giriş yaptır
                            userSorgusu,
                            model.Password,
                            false, // True ise tarayıcı kapandığında Cookie silinir, false ise StartUp içinde elle girdiğimiz değeri baz alır.
                            false // StartUp içindeki yanlış şifre girilmesi durumundaki hesap kilitleme ayarı kapalı. True ise açık.
                        );
                        
                        if (passwordSorgusu.Succeeded)
                        {
                            SepetCreate(userSorgusu);
                            return Redirect(model.ReturnUrl ?? "~/"); // ReturnUrl == Null ise Anasayfaya yönlendirilir.
                        } else
                        {
                            ModelState.AddModelError("Password", "Şifre hatalı.");
                        }
                    } else // Emaili onaylanmamışsa
                    {
                        ModelState.AddModelError("Email", "Lütfen email adresinizi onaylayınız.");
                    }
                } else // eMail sorgusuna uygun kullanıcı yoksa
                {
                    ModelState.AddModelError("Email", "Bu kullanıcıya ait hesap bulunamadı.");
                }
            }
            return View(model);
        }

// SEPET EKLEME ---------------------------------------------------------------------------
        private void SepetCreate(ProjeUser userSorgusu)
        {
            var cart = GetCart();

            var sepet = _sepetService.SepetAndProducts(userSorgusu.Id);
            if (sepet == null)
            {
                List<SepetLine> sepetLines = new List<SepetLine>();
                var price = new double();
                foreach (var item in cart.Product)
                {
                    var sepetLine = new SepetLine() {
                            ProductId = item.Product.ProductId,
                            ProductQuantity = item.ProductQuantity,
                            ProductSizeId = item.ProductSizeId
                    };
                    sepetLines.Add(sepetLine);

                    price += item.Product.ProductPrice * item.ProductQuantity;
                }

                var newSepet = new Sepet() {
                    ProjeUserId = userSorgusu.Id,
                    SepetLines = sepetLines,
                    SiparisToplam = price,
                    GenelToplam = price
                };
                _sepetService.Create(newSepet);
            } else
            {
                foreach (var cartLine in cart.Product)
                {
                    var sepetLines = _sepetService.SepetAndProducts(userSorgusu.Id).SepetLines.Select(i => i.Product.ProductId);

                    if (sepetLines.Contains(cartLine.Product.ProductId))
                    {   // Olan ürüne ekleme yapıldı
                    
                        var sepetLine = _sepetService.SepetAndProducts(userSorgusu.Id).SepetLines.Where(i => i.Product.ProductId == cartLine.Product.ProductId).FirstOrDefault();
                        sepetLine.ProductQuantity += cartLine.ProductQuantity;
                        _sepetLineService.Update(sepetLine);
                    }
                    else
                    {   // Olmayan ürün sepete eklendi
                    
                        var newSepetLine = new SepetLine(){
                            SepetId = sepet.SepetId,
                            ProductId = cartLine.Product.ProductId,
                            ProductQuantity = cartLine.ProductQuantity,
                            ProductSizeId = cartLine.ProductSizeId
                        };
                        _sepetLineService.Create(newSepetLine);
                    }

                    var sepet1 = _sepetService.SepetAndProducts(userSorgusu.Id);
                    var newPrice = sepet1.SepetLines.Sum(i => i.Product.ProductPrice * i.ProductQuantity);
                    sepet1.SiparisToplam = newPrice;
                    sepet1.GenelToplam = newPrice;
                    _sepetService.Update(sepet1);
                }
            }

            cart.RemoveProductAll();
            SaveCart(cart);
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }
// SEPET EKLEME ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        [HttpGet]
        public async Task<IActionResult> AccountLoginAjax(string mail, string password)
        {
            if (ModelState.IsValid)
            {
                var userSorgusu = await _userManager.FindByEmailAsync(mail);

                if (userSorgusu != null)
                {
                    if (await _userManager.IsEmailConfirmedAsync(userSorgusu)) // Email onaylı ise
                    {
                        var passwordSorgusu = await _signInManager.PasswordSignInAsync( // Aşağıdaki bilgilerle giriş yaptır
                            userSorgusu,
                            password,
                            false, // True ise tarayıcı kapandığında Cookie silinir, false ise StartUp içinde elle girdiğimiz değeri baz alır.
                            false // StartUp içindeki yanlış şifre girilmesi durumundaki hesap kilitleme ayarı kapalı. True ise açık.
                        );
                        if (passwordSorgusu.Succeeded)
                        {
                            var sonuc = JsonConvert.SerializeObject(passwordSorgusu);
                            return Json(sonuc);
                        } else
                        {
                            ModelState.AddModelError("Password", "Şifre hatalı.");
                        }
                    } else // Emaili onaylanmamışsa
                    {
                        ModelState.AddModelError("Email", "Lütfen email adresinizi onaylayınız.");
                    }
                } else // eMail sorgusuna uygun kullanıcı yoksa
                {
                    ModelState.AddModelError("Email", "Bu kullanıcıya ait hesap bulunamadı.");
                }
            }
            return View();
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> AccountEdit()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var model = new AccountEditModel(){
                        UserId = Convert.ToString(user.Id),
                        UserAdi = user.UserAdi,
                        UserSoyadi = user.UserSoyadi,
                        UserCinsiyet = user.UserCinsiyet,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        UserBirthDate = user.UserBirthDate
                    };
                    return View(model);
                }
            }
            return RedirectToAction("AccountLogin", "UserAccount");
        }

        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> AccountEdit(AccountEditModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    if (user != null && Convert.ToString(user.Id) == model.UserId)
                    {
                        if (user.Email != model.Email)
                        {
                            user.Email = model.Email;
                            user.UserName = model.Email;
                            if (await _userManager.FindByEmailAsync(user.Email) != null)
                            {
                                ModelState.AddModelError("Email", "Bu mail adresi başka kullanıcıya kayıtlı.");
                                return View(model);
                            }
                        }
                        
                        if (user.UserBirthDate == new DateTime(0001,01,01))
                        {   // Doğum tarihi bilgisi daha önce değiştirilmemişse gelen tarih güncellenir. Değiştirilmişse burayı atlar ve güncelleme yapılmaz
                            user.UserBirthDate = model.UserBirthDate;
                        }

                        user.UserAdi = model.UserAdi;
                        user.UserSoyadi = model.UserSoyadi;
                        user.UserCinsiyet = model.UserCinsiyet;
                        user.PhoneNumber = model.PhoneNumber;

                            // ŞİFRE GÜNCELLEME ALANI
                        IdentityResult validPass = null; 
                        if (!string.IsNullOrEmpty(model.NewPassword)) // Dışarıdan NewPassword alanı gelmişse
                        {
                            // Kullanıcı ve Password ile uyumlu kullanıcı sorgular.
                            if (await _userManager.CheckPasswordAsync(user, model.Password)) 
                            {
                                validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword); // validPass değişkenine, paranteziçindeki alanları gönderiyoruz.

                                if (validPass.Succeeded)
                                {
                                    user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword); // Yeni şifreyi güncelliyoruz
                                } else
                                {
                                    TempData["iconOK"] = "error";
                                    TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin";
                                    return View(model);
                                }
                            } else
                            {
                                ModelState.AddModelError("Password", "Mevcut şifreniz doğrulanamadı.");
                                return View(model);
                            }
                        }
                        
                        // USER GÜNCELLEME ALANI
                        var guncelle = await _userManager.UpdateAsync(user);
                        if (!guncelle.Succeeded)
                        {
                            TempData["iconOK"] = "error";
                            TempData["iconText"] = "İşlem başarısız. Lütfen tekrar deneyin.";
                            return View(model);
                        }

                        TempData["iconSuccess"] = "success";
                        TempData["iconSuccessText"] = "Tamamlandı.";
                        return View(model);

                    } else
                    {
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen tekrar deneyin.";
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("AccountLogin", "UserAccount");
            }
            return View(model);
        }

        public async Task<IActionResult> AccountLogout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AccountEmailOnay(string userId, string token)
        {
            if (userId == null || token == null) // Link bilgisindeki userId ya da token alanı boş ise
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Hatalı link. Lütfen gelen linke tekrar tıklayın ya da yeni bir link talep edin.";
                return RedirectToAction("Index", "Home");
            } else
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null) // Eşleşen user varsa
                {
                    var sonuc = await _userManager.ConfirmEmailAsync(user, token);
                    
                    if (sonuc.Succeeded) // Email onaylama başarılı ise
                    {
                        TempData["icon"] = "success";
                        TempData["text"] = "Hesabınız onaylandı.";
                        return RedirectToAction("Index", "Home");
                    } else
                    {
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
                        return RedirectToAction("Index", "Home");
                    }
                } else // Eşleşen user yoksa
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        
        [HttpGet]
        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifremiUnuttum(UserSifremiUnuttumModel model)
        {
            if (!string.IsNullOrEmpty(model.Email))
            {
                var user = await _userManager.FindByEmailAsync(model.Email); // Gelen email'i alarak, _userManager içinde user sorgulaması yaptık.
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user); // Gelen email'in eşleştiği user'a ait Şifre Reset Token'ı ürettik.

                    var url = Url.Action("SifreYenile", "UserAccount", new { // Url Onay Kodu oluşturur.
                        userId = user.Id,
                        token = token
                        // /Account/SifreYenile/userId/token şeklinde oluşacak, Şifre Yenileme Url. Linke tıklandığında, Account Controllerın SifreYenile Actionuna, userId ve token ile gidecek.
                    });

                    await _emailGonder.SendEmailAsync(model.Email, "Şifre Yenile", $"Lütfen şifrenizi yenilemek için linke <a href='https://localhost:7045{url}'>tıklayınız.</a>"); // Email gönderen kod. Parametreden email bilgisini alır

                    TempData["iconOk"] = "success";
                    TempData["iconText"] = "Şifre yenileme linki, mail adresinize göderilmiştir.";
                    return RedirectToAction("AccountLogin", "UserAccount");
                } else
                {
                    ModelState.AddModelError("Email", "Mail adresiyle kayıtlı kullanıcı bulunamadı.");
                }
            }
            return View(model);
        }
    
        [HttpGet]
        public IActionResult SifreYenile(string userId, string token)
        { // Şifre sıfırlama linki bu metota gelecek ve içinde Action ile Controller bilgisi dışında bir de userId ve token bigisi de vardı. İşte o bilgileri metot parametresi aracılığıyla. bu Get metodundan forma, kullanıcının görmeyeceği şekilde hidden olarak aktarıcaz.

            if (userId == null || token == null) // Kullanıcı maildeki şifre yenile linkine tıkladığında userId veya token alanlarından en az biri null ise
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Hatalı link. Lütfen gelen linke tekrar tıklayın ya da yeni bir link talep edin.";
                return RedirectToAction("Index", "Home");
            } else // userId ve token bilgileri var ise
            {
                var model = new UserSifreYenileModel(){
                    Token = token,
                    UserId = userId
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SifreYenile(UserSifreYenileModel model)
        {
            if (ModelState.IsValid)
            {
                // var user = await _userManager.FindByEmailAsync(model.Email); // model'den gelen email var mı
                var user = await _userManager.FindByIdAsync(model.UserId); // model'den gelen email var mı

                if (user != null)
                {
                    var sonuc = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword); // Paranteziçindeki bilgilerle ResetPassword işlemini uygularız.
                    
                    if (sonuc.Succeeded)
                    {
                        TempData["iconOK"] = "success";
                        TempData["iconText"] = "Şifre değiştirme başarılı. Giriş yapabilirsiniz.";
                        return RedirectToAction("AccountLogin", "UserAccount");
                    } else
                    {
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Hatalı link. Lütfen gelen linke tekrar tıklayın ya da yeni bir link talep edin.";
                        return RedirectToAction("Index", "Home");
                        // foreach (var error in sonuc.Errors)
                        // {
                            // ModelState.AddModelError("", error.Description);
                        // }
                    }
                }
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Hatalı link. Lütfen gelen linke tekrar tıklayın ya da yeni bir link talep edin.";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    
    }
}
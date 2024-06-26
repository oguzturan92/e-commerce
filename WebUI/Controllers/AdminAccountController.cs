using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Validators;
using WebUI.EmailServis;
using WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeEntity.Concrete;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin, Kullanıcı")]
    [AutoValidateAntiforgeryToken] // Csrf Token için. Form güvenliği. Bu Controller içindeki tüm Post metotları etkiler.
    public class AdminAccountController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        private UserManager<ProjeUser> _userManager; // SignIn(Kullanıcı) işlemlerini yönetecek sınıf
        private SignInManager<ProjeUser> _signInManager; // Kullanıcıya giriş yaptıracak
        private IPasswordValidator<ProjeUser> _passwordValidator; // Şifre değiştirme işlemleri için kullanıcaz
        private IPasswordHasher<ProjeUser> _passwordHasher; // Şifre değiştirme işlemleri için kullanıcaz
        private IEmailGonder _emailGonder; // Email gönderme işlemleri için kullanıcaz
        private RoleManager<ProjeRole> _roleManager; // Rol işlemleri için kullanılacak
        public AdminAccountController(UserManager<ProjeUser> userManager,
            SignInManager<ProjeUser> signInManager,
            IPasswordValidator<ProjeUser> passwordValidator,
            IPasswordHasher<ProjeUser> passwordHasher,
            IEmailGonder emailGonder,
            RoleManager<ProjeRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
            _emailGonder = emailGonder;
            _roleManager = roleManager;
        }
        

        // METOTLAR ------------------------------------------------------------
        [HttpGet]
        public IActionResult IndexAccount(int page = 1)
        {   
            const int pageSize = 10;
            var model = new AdminUserIndexModel()
            {
                PageInfo = new PageInfo(){ // Farklı bir modeli, bir başka model içine nesne olarak gönderdik.
                    TotalItems = _userManager.Users.Count(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                },
                Users = _userManager.Users.OrderByDescending(i => i.UserRegisterDate).Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var tumRoller = _roleManager.Roles.Select(i => i.Name); // Rollerin name bilgisini aldık.

            var model = new UserModel { // Yukarıdaki bilgileri Model içine attık
                TumRoller = tumRoller
            };
            return View(model);
        }
        
        [HttpPost]
        // [ValidateAntiForgeryToken] // Action düzeyince Csrf Token için. Sadece Post'lara uygulanır.
        public async Task<IActionResult> Register(UserModel model, string[] seciliRoller)
        {
            if (ModelState.IsValid)
            {
                var user = new ProjeUser() // model'den gelen bilgileri, yeni User nesnesine atarız.
                {
                    UserRegisterDate = DateTime.Now,
                    UserAdi = model.UserAdi,
                    UserSoyadi = model.UserSoyadi,
                    UserName = model.UserName,
                    UserCinsiyet = model.UserCinsiyet,
                    Email = model.Email,
                    EmailConfirmed = model.EmailConfirmed,
                    PhoneNumber = model.PhoneNumber,
                };

                var userName = await _userManager.FindByNameAsync(model.UserName);
                if (userName != null)
                {
                    ModelState.AddModelError("UserName", "Bu kullanıcı adı ile oluşturulmuş bir hesap mevcut.");
                    model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                    model.SeciliRoller = seciliRoller;
                    return View(model);
                }

                var userSorgula = await _userManager.FindByEmailAsync(model.Email);
                if (userSorgula != null)
                {
                    ModelState.AddModelError("Email", "Bu e-mail hesabıyla oluşturulmuş bir hesap mevcut.");
                    model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                    model.SeciliRoller = seciliRoller;
                    return View(model);
                }
                
                var yeniUser = await _userManager.CreateAsync(user, model.Password); // user ve model.Password değerleriyle User oluşturma talebi gönderdik.

                if (yeniUser.Succeeded)
                {
                    // ROL EKLEME KODU
                    var userRoles = await _userManager.GetRolesAsync(user); // Kayıtlı olduğu rolleri aldık.
                    seciliRoller = seciliRoller ?? new string[]{};

                    await _userManager.AddToRolesAsync(user, seciliRoller.Except(userRoles).ToArray<string>());

                    await _userManager.RemoveFromRolesAsync(user, userRoles.Except(seciliRoller).ToArray<string>());

                    // EMAİL ONAYI İÇİN TOKEN KODU 
                    if (model.EmailConfirmed == false) // Emailonayı false ise link gönderir.
                    {
                        var emailOnayKodu = await _userManager.GenerateEmailConfirmationTokenAsync(user); // Token kodu oluşturur
                        var urlOnayKodu = Url.Action("EmailOnay", "AdminAccount", new { // Url Onay Kodu oluşturur.
                            userId = user.Id,
                            token = emailOnayKodu
                        });

                        await _emailGonder.SendEmailAsync(model.Email, "Hesabınızı onaylayınız.", $"<p>HESABINIZI ONAYLAYIN</p><p>Lütfen Email hesabınızı onaylamak için linke <a href='https://localhost:7045{urlOnayKodu}'>tıklayınız.</a></p><p>Not: Bu mail, gereksiz klasörünüze geldiyse, linke tıklanmayabilir. Bu durumda, maili, gelen kutusuna taşıyıp linke tıklayın ya da bağlantıyı kopyalayıp, adres çubuğuna yapıştırın</p>");

                        TempData["iconOK"] = "success";
                        TempData["iconText"] = "Kullanıcı oluşturuldu. Lütfen mail adresinize gelen onay linkine tıklayarak kaydı tamamlayın.";
                        return RedirectToAction("IndexAccount", "AdminAccount");
                    }

                    TempData["iconOK"] = "success";
                    TempData["iconText"] = "Kullanıcı oluşturuldu.";
                    return RedirectToAction("IndexAccount", "AdminAccount");
                } else // yeniUser.Succeeded değil ise, yani kullanıcı oluşturulamadıysa
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Kayıt başarısız. Lütfen tekrar deneyin.";
                    model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                    model.SeciliRoller = seciliRoller;
                    return View(model);
                }
            }
            model.TumRoller = _roleManager.Roles.Select(i => i.Name);
            model.SeciliRoller = seciliRoller;
            return View(model);
        }
    
        [HttpGet]
        [AllowAnonymous] // Controller seviyesinde kilitlenen dosyaların içindeki kilitlenmeyen Action'ları belirtir.
        public IActionResult Login(string ReturnUrl = null)
        {   
            // Login'e yönlendiğimizde(bu metoda), burdan ReturnUrl bilgisini alıp, UserGirisModel içindeki ReturnUrl alanına attık ve _login.cshtml dosyasına yönlendiğimizde input içine Get metodu(bu metot), ReturnUrl bilgisini çekecek. Ordan da Login Post Action'una gönderdik ve ReturnUrl kullanarak giriş yaptırdık. Yani gitmek istediği sayfaya giderken Login olması istenirse, Login olduğunda devam etmek istediği sayfaya yönlendirilcek.
            var model = new UserLoginModel(){
                // ReturnUrl = ReturnUrl // ReturnUrl alanı Admin panelinde çalışması için bunu aç
                ReturnUrl = null
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.Users.ToList().Count() == 0)
                {
                    List<ProjeRole> roles = new List<ProjeRole>();
                    roles.Add(new ProjeRole(){Name = "Admin", NormalizedName = "ADMIN"});
                    roles.Add(new ProjeRole(){Name = "Anasayfa", NormalizedName = "ANASAYFA"});
                    roles.Add(new ProjeRole(){Name = "Sipariş", NormalizedName = "SIPARIS"});
                    roles.Add(new ProjeRole(){Name = "Dizayn", NormalizedName = "DIZAYN"});
                    roles.Add(new ProjeRole(){Name = "Slider", NormalizedName = "SLIDER"});
                    roles.Add(new ProjeRole(){Name = "Banner", NormalizedName = "BANNER"});
                    roles.Add(new ProjeRole(){Name = "Ürün", NormalizedName = "URUN"});
                    roles.Add(new ProjeRole(){Name = "Seçenek", NormalizedName = "SECENEK"});
                    roles.Add(new ProjeRole(){Name = "Kategori", NormalizedName = "KATEGORİ"});
                    roles.Add(new ProjeRole(){Name = "Kullanıcı", NormalizedName = "KULLANICI"});
                    roles.Add(new ProjeRole(){Name = "Rol", NormalizedName = "ROL"});
                    roles.Add(new ProjeRole(){Name = "Popup", NormalizedName = "POPUP"});
                    roles.Add(new ProjeRole(){Name = "Hediye Çeki", NormalizedName = "HEDIYE CEKI"});
                    roles.Add(new ProjeRole(){Name = "Havale Bildirim", NormalizedName = "HAVALE BILDIRIM"});
                    roles.Add(new ProjeRole(){Name = "Destek", NormalizedName = "DESTEK"});
                    roles.Add(new ProjeRole(){Name = "Mesaj", NormalizedName = "MESAJ"});
                    roles.Add(new ProjeRole(){Name = "Abone", NormalizedName = "ABONE"});
                    roles.Add(new ProjeRole(){Name = "Footer", NormalizedName = "FOOTER"});
                    roles.Add(new ProjeRole(){Name = "Banka", NormalizedName = "BANKA"});
                    roles.Add(new ProjeRole(){Name = "Kargo", NormalizedName = "KARGO"});
                    roles.Add(new ProjeRole(){Name = "Ayarlar", NormalizedName = "AYARLAR"});
                    for (int i = 0; i < roles.Count(); i++)
                    {
                        await _roleManager.CreateAsync(roles[i]);
                    }

                    var ilkUser = new ProjeUser() // model'den gelen bilgileri, User nesnesine atarız.
                    {
                        Email = model.Email,
                        UserName= "Admin",
                        UserAdi= "John",
                        UserSoyadi= "DOE",
                        EmailConfirmed = true,
                        UserRegisterDate = DateTime.Now
                    };
                    var ilkUser1 = await _userManager.CreateAsync(ilkUser, model.Password); // user ve model.Password değerleriyle User oluşturma talebi gönderdik.

                    // await _userManager.AddToRoleAsync(ilkUser, rol.Name);

                    if (ilkUser1.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(ilkUser, roles[0].Name);

                        TempData["iconOK"] = "success";
                        TempData["iconText"] = "Admin oluşturuldu. Giriş yapabilirsiniz.";
                        return RedirectToAction("Login", "AdminAccount");
                    }
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Kayıt başarısız. Lütfen tekrar deneyin.";
                    return RedirectToAction("Login", "AdminAccount");
                }

                var user = await _userManager.FindByEmailAsync(model.Email);
                // var user = await _userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Hesap bulunamadı.");
                    return View(model);
                } else
                {
                    var mailOnay = await _userManager.IsEmailConfirmedAsync(user); // eMail onay durumu sorgulama
                    if (mailOnay)
                    {
                        // gelen password ile giriş yaptırıyoruz
                        var password = await _signInManager.PasswordSignInAsync(
                            user, // Kullanıcıdan gelen userSorgusu ile
                            model.Password, // Kullanıcıdan gelen Password eşitliği sorgular
                            false, // True ise tarayıcı kapandığında Cookie silinir, false ise StartUp içinde elle girdiğimiz değeri baz alır.
                            false // StartUp içindeki yanlış şifre girilmesi durumundaki hesap kilitleme ayarı kapalı/false mı açık/true mı olsun.
                        );
                            
                        if (password.Succeeded) // passwordSorgusu değişkeni başarılı ise Giriş yapılmıştır
                        {
                            return Redirect(model.ReturnUrl ?? "~/admin/anasayfa"); // ReturnUrl == Null ise ~/Admin/Home'a yönlendirilir.
                        } else // passwordSorgusu başarılı değilse, şifre sorgulaması hatalı demektir
                        {
                            ModelState.AddModelError("Password", "Şifre hatalı. Lütfen tekrar deneyin.");
                        }
                    } else // Emaili onaylanmamışsa
                    {
                        ModelState.AddModelError("Email", "Lütfen email adresinizi onaylayınız.");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAdmin(string UserName = null)
        {
            // Kişisel düzenleme Action'u

            var user = await _userManager.FindByNameAsync(UserName); // Burda Id değeri, string değer istediği için Action'a gelen id değerini string olarak aldık.

            if (user != null) // user değeri null değilse
            {
                var giris = User.Identity.Name; // giriş yapmış kullanıcıyı aldık
                if (user.UserName == giris) // Giriş yapmış kullanıcı ile, gelen kullanıcı adı eşit ise bilgiler getirilir.
                {
                    var model = new UserEditModel(){
                        UserId = Convert.ToString(user.Id),
                        UserAdi = user.UserAdi,
                        UserSoyadi = user.UserSoyadi,
                        UserName = user.UserName,
                        UserCinsiyet = user.UserCinsiyet,
                        Password = user.PasswordHash,
                        NewPassword = user.PasswordHash,
                        Email = user.Email,
                        UserRegisterDate = user.UserRegisterDate,
                        PhoneNumber = user.PhoneNumber
                    };
                    return View(model);
                } else
                {
                    // TempData["iconOK"] = "error";
                    // TempData["iconText"] = "Başka bir kullanıcıya ait bilgileri görüntüleyemezsiniz";
                    return RedirectToAction("Home", "Admin");
                }
            } else
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen tekrar deneyin.";
                return RedirectToAction("Home", "Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAdmin(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId); // Burda Id değeri, string değer istediği için Action'a gelen id değerini string olarak aldık.
                if (user != null)
                {
                    if (user.UserName != model.UserName)
                    { // Gelen UserName bilgisi, işlem yapılmak istenilen kullanıcının UserName bilgisi ile eşit değilse başka kullanıcıların UserName bilgisi ile eşleşme ararız. Eşitse, kendi adına güncelleriz.
                        var userName = await _userManager.FindByNameAsync(model.UserName);
                        if (userName != null)
                        {
                            ModelState.AddModelError("UserName", "Bu kullanıcı adı ile oluşturulmuş bir hesap mevcut.");
                            return View(model);
                        }
                    }

                    if (user.Email != model.Email)
                    { // Gelen Email bilgisi, işlem yapılmak istenilen kullanıcının Email bilgisi ile eşit değilse başka kullanıcıların Email bilgisi ile eşleşme ararız. Eşitse, kendi adına güncelleriz.
                        var userSorgula = await _userManager.FindByEmailAsync(model.Email);
                        if (userSorgula != null)
                        {
                            ModelState.AddModelError("Email", "Bu e-mail hesabıyla oluşturulmuş bir hesap mevcut.");
                            return View(model);
                        }
                    }

                    user.UserAdi = model.UserAdi;
                    user.UserSoyadi = model.UserSoyadi;
                    user.UserName = model.UserName;
                    user.UserCinsiyet = model.UserCinsiyet;
                    user.Email = model.Email;
                    user.UserRegisterDate = model.UserRegisterDate;
                    user.PhoneNumber = model.PhoneNumber;

                    // ŞİFRE GÜNCELLEME ALANI
                    IdentityResult validPass = null; 

                    if (!string.IsNullOrEmpty(model.NewPassword)) // Dışarıdan Password alanı gelmişse, yani şifre değiştirilmek istenmişse, şifre değiştirmiş olacağız.
                    {
                        validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword); // validPass değişkenine, paranteziçindeki alanları gönderiyoruz.

                        if (validPass.Succeeded)
                        {
                            user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword); // seçili olan user'ın PasswordHash(Identity ile kendiliğinden oluşan şifre sütunu) alanını, Post Action'dan gelen Password alanı ile güncelliyoruz. Yani şifre değişmiş oluyor.
                        } else // validPass değişkenine gönderilen veriler başarıyla işşlenMEMİŞSE
                        {
                            ModelState.AddModelError("Password", "Şifre güncelleme başarısız.");
                            return View(model);
                        }
                    } else // Eğer şifre alanı boş gelmişse, varolan şifreyi (Password = user.PasswordHash) diyerek validPass alanına gönderdim.
                    {
                        validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.Password = user.PasswordHash);
                    }

                    // USER GÜNCELLEME ALANI
                    if (validPass.Succeeded)
                    {
                        var guncellemeIslemi = await _userManager.UpdateAsync(user); // user'ı göndererek update ediyoruz.

                        if (guncellemeIslemi.Succeeded)
                        {
                            TempData["icon"] = "success";
                            TempData["title"] = "Güncelleme başarılı.";
                        } else
                        {
                            TempData["iconOK"] = "error";
                            TempData["iconText"] = "Güncelleme başarısız. Lütfen tekrar deneyin.";
                        }
                    }
                } else
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen tekrar deneyin.";
                }
            }   
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id); // Burda Id değeri, string değer istediği için Action'a gelen id değerini string olarak aldık.

            if (user != null) // user değeri null değilse
            {
                var seciliRoller = await _userManager.GetRolesAsync(user); // Gelen user'ın rolü ile _userManager içinde eşleşen rol bilgilerini aldık.
                var tumRoller = _roleManager.Roles.Select(i => i.Name); // Rollerin name bilgisini aldık.

                var model = new UserEditModel { // Yukarıdaki bilgileri Model içine attık
                    UserId = Convert.ToString(user.Id),
                    UserAdi = user.UserAdi,
                    UserSoyadi = user.UserSoyadi,
                    UserName = user.UserName,
                    UserCinsiyet = user.UserCinsiyet,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    UserRegisterDate = user.UserRegisterDate,
                    SeciliRoller = seciliRoller,
                    TumRoller = tumRoller
                };
                return View(model);
            }
            TempData["iconOK"] = "error";
            TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen tekrar deneyin.";
            return RedirectToAction("IndexAccount", "AdminAccount");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditModel model, string[] seciliRoller)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId); // Burda Id değeri, string değer istediği için Action'a gelen id değerini string olarak aldık.
                if (user != null)
                {
                    if (user.UserName != model.UserName)
                    { // Gelen UserName bilgisi, işlem yapılmak istenilen kullanıcının UserName bilgisi ile eşit değilse başka kullanıcıların UserName bilgisi ile eşleşme ararız. Eşitse, kendi adına güncelleriz.
                        var userName = await _userManager.FindByNameAsync(model.UserName);
                        if (userName != null)
                        {
                            ModelState.AddModelError("UserName", "Bu kullanıcı adı ile oluşturulmuş bir hesap mevcut.");
                            model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                            model.SeciliRoller = seciliRoller;
                            return View(model);
                        }
                    }

                    if (user.Email != model.Email)
                    { // Gelen Email bilgisi, işlem yapılmak istenilen kullanıcının Email bilgisi ile eşit değilse başka kullanıcıların Email bilgisi ile eşleşme ararız. Eşitse, kendi adına güncelleriz.
                        var userSorgula = await _userManager.FindByEmailAsync(model.Email);
                        if (userSorgula != null)
                        {
                            ModelState.AddModelError("Email", "Bu e-mail hesabıyla oluşturulmuş bir hesap mevcut.");
                            model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                            model.SeciliRoller = seciliRoller;
                            return View(model);
                        }
                    }

                    user.UserAdi = model.UserAdi;
                    user.UserSoyadi = model.UserSoyadi;
                    user.UserName = model.UserName;
                    user.UserCinsiyet = model.UserCinsiyet;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;
                    user.PhoneNumber = model.PhoneNumber;

                    // ŞİFRE GÜNCELLEME ALANI
                    IdentityResult validPass = null; 

                    if (!string.IsNullOrEmpty(model.Password)) // Dışarıdan Password alanı gelmişse, yani şifre değiştirilmek istenmişse, şifre değiştirmiş olacağız.
                    {
                        validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.Password); // validPass değişkenine, paranteziçindeki alanları gönderiyoruz.

                        if (validPass.Succeeded)
                        {
                            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password); // seçili olan user'ın PasswordHash(Identity ile kendiliğinden oluşan şifre sütunu) alanını, Post Action'dan gelen Password alanı ile güncelliyoruz. Yani şifre değişmiş oluyor.
                        } else // validPass değişkenine gönderilen veriler başarıyla işşlenMEMİŞSE
                        {
                            ModelState.AddModelError("Password", "Şifre güncelleme başarısız.");
                            model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                            model.SeciliRoller = seciliRoller;
                            return View(model);
                        }
                    } else
                    { // Eğer şifre alanı boş gelmişse, varolan şifreyi (Password = user.PasswordHash) diyerek validPass alanına gönderdim.
                        validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.Password = user.PasswordHash);
                    }

                    // USER GÜNCELLEME ALANI
                    if (validPass.Succeeded)
                    {
                        var guncellemeIslemi = await _userManager.UpdateAsync(user); // user'ı göndererek update ediyoruz.

                        if (guncellemeIslemi.Succeeded)
                        {
                            var userRoles = await _userManager.GetRolesAsync(user); // Kayıtlı olduğu rolleri aldık.
                            seciliRoller = seciliRoller ?? new string[]{}; // seciliRoller boş ise, boş liste döndürür.

                            await _userManager.AddToRolesAsync(user, seciliRoller.Except(userRoles).ToArray<string>());

                            await _userManager.RemoveFromRolesAsync(user, userRoles.Except(seciliRoller).ToArray<string>());

                            TempData["icon"] = "success";
                            TempData["title"] = "Güncelleme başarılı.";
                            model.SeciliRoller = seciliRoller;
                            model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                            return View(model);
                        } else
                        {
                            TempData["iconOK"] = "error";
                            TempData["iconText"] = "Güncelleme başarısız. Lütfen tekrar deneyin.";
                            model.SeciliRoller = seciliRoller;
                            model.TumRoller = _roleManager.Roles.Select(i => i.Name);
                            return View(model);
                        }
                    }
                } else
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen tekrar deneyin.";
                    return RedirectToAction("IndexAccount", "AdminAccount");
                }
            }
            model.SeciliRoller = seciliRoller;
            model.TumRoller = _roleManager.Roles.Select(i => i.Name);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id); // Burda Id değeri, string değer istediği için Action'a gelen id değerini string olarak aldık. 

            if (user != null)
            {
                var sonuc = await _userManager.DeleteAsync(user); // _userManager üzerinden DeleteAsync ile user'i sil.
                if (sonuc.Succeeded)
                {
                    TempData["icon"] = "success";
                    TempData["title"] = "Kullanıcı silindi.";
                } else
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Silme işlemi başarısız. Lütfen tekrar deneyin.";
                }
            } else
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen tekrar deneyin.";
            }
            return RedirectToAction("IndexAccount", "AdminAccount");
        }
    
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> EmailOnay(string userId, string token)
        {
            if (userId == null || token == null) // Link bilgisindeki userId ya da token alanı boş ise
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Hatalı link. Lütfen gelen linke yeniden tıklayın.";
                return RedirectToAction("SifremiUnuttum", "AdminAccount");
            } else // Link bilgisindeki userId ve token alanı dolu ise
            {
                var user = await _userManager.FindByIdAsync(userId); // Gelen userId ile sorgulama yapar.
                if (user != null) // Eşleşen user varsa
                {
                    var sonuc = await _userManager.ConfirmEmailAsync(user, token); // user ile token bilgisine göre email alanını onaylar.
                    if (sonuc.Succeeded) // Email onaylama başarılı ise
                    {
                        TempData["icon"] = "success";
                        TempData["text"] = "Hesabınız onaylandı.";
                        return RedirectToAction("Login", "AdminAccount");
                    } else // Email onaylama başarılı değilse, Token'da sorun vardır
                    {
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Bir hata oluştu. Lütfen gelen linke yeniden tıklayın.";
                        return RedirectToAction("SifremiUnuttum", "AdminAccount");
                    }
                } else // Eşleşen user yoksa
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen gelen linke yeniden tıklayın.";
                    return RedirectToAction("SifremiUnuttum", "AdminAccount");
                }
            }
        }
    
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SifremiUnuttum(UserSifremiUnuttumModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email); // e-mail sorgulaması
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user); // Gelen email'in eşleştiği user'a ait Şifre Reset Token'ı ürettik.

                    var url = Url.Action("SifreYenile", "AdminAccount", new { // Url Onay Kodu oluşturur.
                        userId = user.Id,
                        token = token
                        // /Account/SifreYenile/userId/token şeklinde oluşacak şifre yenileme Url. Linke tıklandığında post metoduna userId ve token ile gidecek.
                    });

                    await _emailGonder.SendEmailAsync(model.Email, "Şifre Yenile.", $"<p>ŞİFRENİZİ YENİLEYİN</p><p>Lütfen şifrenizi yenilemek için linke <a href='https://sablon-1.softo.com.tr{url}'>tıklayınız.</a></p><p>Not: Bu mail, gereksiz klasörünüze geldiyse, linke tıklanmayabilir. Bu durumda, maili, gelen kutusuna taşıyıp linke tıklayın ya da bağlantıyı kopyalayıp, adres çubuğuna yapıştırın</p>");

                    TempData["iconOK"] = "success";
                    TempData["iconText"] = "Lütfen e-mail adresinizi kontrol edin.";
                    return RedirectToAction("Login", "AdminAccount");
                } else
                {
                    ModelState.AddModelError("Email", "Kayıtlı e mail adresi bulunamadı.");
                    return View(model);
                }
            }
            return View(model);
        }
    
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SifreYenile(string userId, string token)
        { // Şifre sıfırlama linki bu metota gelecek ve içinde Controller ile Action bilgisi dışında bir de userId ve token bigisi de vardı. İşte o bilgileri metot parametresi aracılığıyla. bu Get metodundan forma, kullanıcının görmeyeceği şekilde hidden olarak aktarıcaz.

            if (userId == null || token == null) // Kullanıcı maildeki şifre yenile linkine tıkladığında userId veya token alanlarından en az biri null ise
            {
                TempData["iconOK"] = "error";
                TempData["iconText"] = "Hatalı link. Lütfen gelen linke yeniden tıklayın.";
                return RedirectToAction("SifremiUnuttum", "AdminAccount");
            } else 
            {
                var model = new UserSifreYenileModel {
                    Token = token,
                    UserId = userId
                };
                return View(model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SifreYenile(UserSifreYenileModel model)
        {
            if (ModelState.IsValid)
            {
                // var user = await _userManager.FindByEmailAsync(model.Email); // model'den gelen email var mı
                var user = await _userManager.FindByIdAsync(model.UserId); // model'den gelen ıd'ye ait kullanıcı

                if (user != null)
                {
                    var sonuc = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword); // Paranteziçindeki bilgilerle ResetPassword işlemini uygularız.
                    
                    if (sonuc.Succeeded) // Şifre değiştirme işlemi başarılı ise
                    {
                        TempData["icon"] = "success";
                        TempData["text"] = "Şifreniz güncellendi.";
                        return RedirectToAction("Login", "AdminAccount");
                    } else // Şifre değiştirme başarılı değil ise, Token'da sorun vardır
                    {
                        TempData["iconOK"] = "error";
                        TempData["iconText"] = "Bir hata oluştu. Lütfen gelen linke yeniden tıklayın ya da yeni bir link daha alın.";
                        return RedirectToAction("SifremiUnuttum", "AdminAccount");
                    }
                } else
                {
                    TempData["iconOK"] = "error";
                    TempData["iconText"] = "Kullanıcı bulunamadı. Lütfen gelen linke yeniden tıklayın ya da yeni bir link daha alın.";
                    return RedirectToAction("SifremiUnuttum", "AdminAccount");
                }
            }
            return View(model);
        }
    
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "AdminAccount");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Accessdenied()
        {
            return View();
        }
    
    }
}
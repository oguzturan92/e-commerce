using WebUI.EmailServis;
using Microsoft.AspNetCore.Identity;
using ProjeData.Concrete;
using ProjeEntity.Concrete;
using WebUI.Extension;

var builder = WebApplication.CreateBuilder(args);

    // IDentity Context bilgileri
    builder.Services.AddDbContext<ProjeContext>();
    builder.Services.AddIdentity<ProjeUser, ProjeRole>().AddEntityFrameworkStores<ProjeContext>().AddDefaultTokenProviders();

    builder.Services.AddMemoryCache();
    builder.Services.AddSession();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // IDENTITY AYARLARI - 1
    builder.Services.Configure<IdentityOptions>(options => {

        // Şifre Ayarları
        options.Password.RequireDigit = false; // Sayısal değer bulunma durumu.
        options.Password.RequireLowercase = false; // Küçük harf bulunma durumu.
        options.Password.RequireUppercase = false; // Büyük harf bulunma durumu.
        // options.Password.RequiredLength = false; // Minimum karakter sayısı.
        options.Password.RequireNonAlphanumeric = false; // Hem rakam hem harf bulunma durumu.

        // Kilitleme Ayarları
        options.Lockout.MaxFailedAccessAttempts = 5; // 5 yanlış parola girme hakkı olur ve engellenir.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // 5dk sonra engeli kalkar.
        options.Lockout.AllowedForNewUsers = true; // Kilitleme işlemi, yeni kullanıcı için geçerli olur.

        // Mail Ayarları
        // options.User.AllowedUserNameCharacters = ""; // UserName içinde olmasını istediğimiz harfler
        options.User.RequireUniqueEmail = true; // Aynı mail adresi ile bir tane kullanıcı oluşturulabilir.
        options.SignIn.RequireConfirmedEmail = true; // Üye olduktan sonra hesap onaylansın mı.
        options.SignIn.RequireConfirmedPhoneNumber = false; // Üye olduktan sonra telefon numarası onaylansın mı.
    });

    // IDENTITY AYARLARI - 2
    builder.Services.ConfigureApplicationCookie(options => {
        // COOKIE Nedir? : Üye girişi yaptıktan sonra, çıkış yapana kadar, bizden tekrar şifre istemez. Çünkü Cookie aracılığıyla, giriş bilgilerimiz tarayıcıda tutuluyor. Başka bir Örnek : Sepete ürün ekledikten sonra üye girişi yaptığımızda, eklediğimiz sepet karşımıza gelir. Burdaki sepet bilgileri de Cookie aracılığıyla tarayıcıda tutulmuşur.

        options.LoginPath = "/admin"; // Giriş yapmamış kullanıcı, yetkisi olmayan sayfaya gitmek istediğinde, yönlendirilecek sayfa.
        options.LogoutPath = "/AdminAccount/Logout"; // Hesaptan çıkış yapılırsa, Cookie, tarayıcıdan silinmiş olacak ve kullanıcı çıkış yaptıktan sonra, parantez içindeki sayfaya yönlendirilecek.
        options.AccessDeniedPath = "/admin/yetkisizalan"; // Giriş yapmış kullanıcı, yetkisi olmayan sayfaya gitmek istediğinde, yönlendirilecek sayfa.
        options.SlidingExpiration = true; // Oturum açıldıktan sonra, her istek yaptığında, kullanıcı Cookie'sinin tarayıcıdan silinmesi için extra 20dk verir. False dersek, istek yapsın yapmasın, ilk giriş yaptıktan 20dk sonra oturum sonlanır.
        options.ExpireTimeSpan = TimeSpan.FromDays(30); // SlidingExpiration(Yukarıdaki özellik) özelliğinin varsayılan dakikasını belirler. 20 yerine 5dk ya da 1 gün diyebiliriz.
        // Not : Tarayıcı kapandığında Cookie silinmesi için Login Action'a bak.
        options.Cookie = new CookieBuilder
        {
            HttpOnly = true, // Cookie değerlerini, sadece, HttpRequest talep edebilir. JavaScript talep edemez. Biz bunu kullanıcaz. Değiştirme.
            Name = ".Product.Security.Cookie", // Cookie'nin nasıl adlandırılacağı. Tarayıcıda böyle görünecek.

            SameSite = SameSiteMode.Strict // CSRF TOKEN. 
        };
    });
    
    // MAIL AYARLARI
    builder.Services.AddScoped<IEmailGonder, EmailHotmailGonder>(i => 
        new EmailHotmailGonder(
            builder.Configuration["EmailGonder:Host"],
            builder.Configuration.GetValue<int>("EmailGonder:Port"),
            builder.Configuration.GetValue<bool>("EmailGonder:EnableSSL"),
            builder.Configuration["EmailGonder:UserName"],
            builder.Configuration["EmailGonder:Password"]
        )
    );

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    // 404 hatası için yazdık. Error Controller içindeki Error404 Actionuna, code parametresi ile gidecek
    app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication(); // IDentity için

    app.UseAuthorization(); // IDentity için

    app.UseSession(); // Sepet işlemleri Session için

    // app.UseSession(new SessionOptions()
    // {
    //     Cookie = new CookieBuilder()
    //     {
    //         Name = ".e-ticaret.Session"
    //     }
    // }); // Bu session, her bir session'u farklı isimlendirmek için kullanılır.

    app.UseEndpoints(endpoints =>
    {
        // endpoints.MapControllerRoute(
        //     name: "deneme",
        //     pattern: "{controller}/{action}",
        //     defaults: new { action="BannerList"}
        // );

        // ADMİN ALANI ----------------------------------------------------------------
            // ADMİN/HOME GİRİŞ ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminHome",
            pattern: "admin/anasayfa",
            defaults: new { controller="Admin", action="Home"}
        );

            // ADMİN/ADMİN GİRİŞ ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminGiriş",
            pattern: "admin",
            defaults: new { controller="AdminAccount", action="Login"}
        );

        endpoints.MapControllerRoute(
            name: "adminSifremiUnuttum",
            pattern: "admin/sifremiunuttum",
            defaults: new { controller="AdminAccount", action="SifremiUnuttum"}
        );

        endpoints.MapControllerRoute(
            name: "adminSifreYenile",
            pattern: "admin/sifreyenile",
            defaults: new { controller="AdminAccount", action="SifreYenile"}
        );

        endpoints.MapControllerRoute(
            name: "adminYetkisizAlan",
            pattern: "admin/yetkisizalan",
            defaults: new { controller="AdminAccount", action="Accessdenied"}
        );

        endpoints.MapControllerRoute(
            name: "adminCikis",
            pattern: "admin/cikis",
            defaults: new { controller="AdminAccount", action="Logout"}
        );

            // ADMİN/ADMİN DÜZENLEME ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminAdminEdit",
            pattern: "admin/hesap/duzenle/{userName}",
            defaults: new { controller="AdminAccount", action="EditAdmin"}
        );

            // ADMİN/HOMEDESIGNTYPE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminDesignTypeList",
            pattern: "admin/dizayn",
            defaults: new { controller="HomeDesignType", action="HomeDesignTypeList"}
        );
        endpoints.MapControllerRoute(
            name: "adminDesignTypeCreate",
            pattern: "admin/dizayn/ekle",
            defaults: new { controller="HomeDesignType", action="HomeDesignTypeCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminDesignTypeEdit",
            pattern: "admin/dizayn/duzenle/{id}",
            defaults: new { controller="HomeDesignType", action="HomeDesignTypeEdit"}
        );

            // ADMİN/ORDER ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminOrderList",
            pattern: "admin/siparis",
            defaults: new { controller="Order", action="OrderList"}
        );
        endpoints.MapControllerRoute(
            name: "adminOrderDetail",
            pattern: "admin/siparis/detay/{id}",
            defaults: new { controller="Order", action="OrderDetail"}
        );
        endpoints.MapControllerRoute(
            name: "adminOrderEdit",
            pattern: "admin/siparis/duzenle/{id}",
            defaults: new { controller="Order", action="OrderEdit"}
        );

            // ADMİN/ORDERIADE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminOrderIadeList",
            pattern: "admin/siparis/iade",
            defaults: new { controller="OrderIade", action="OrderIadeList"}
        );
        endpoints.MapControllerRoute(
            name: "adminOrderIadeEdit",
            pattern: "admin/siparis/iade/duzenle/{id}",
            defaults: new { controller="OrderIade", action="OrderIadeEdit"}
        );

            // ADMİN/ORDERINCOMPLETE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminOrderIncompleteList",
            pattern: "admin/siparis/yarimkalansepet",
            defaults: new { controller="Sepet", action="SepetIncompleteList"}
        );
        endpoints.MapControllerRoute(
            name: "adminOrderIncompleteDetail",
            pattern: "admin/siparis/yarimkalansepet/detay/{id}",
            defaults: new { controller="Sepet", action="SepetIncompleteDetail"}
        );

            // ADMİN/SLIDER ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminSliderList",
            pattern: "admin/slider",
            defaults: new { controller="Slider", action="SliderList"}
        );
        endpoints.MapControllerRoute(
            name: "adminSliderCreate",
            pattern: "admin/slider/ekle",
            defaults: new { controller="Slider", action="SliderCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminSliderEdit",
            pattern: "admin/slider/duzenle/{id}",
            defaults: new { controller="Slider", action="SliderEdit"}
        );

            // ADMİN/BANNER ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminBannerList",
            pattern: "admin/banner",
            defaults: new { controller="Banner", action="BannerList"}
        );
        endpoints.MapControllerRoute(
            name: "adminBannerCreate",
            pattern: "admin/banner/ekle",
            defaults: new { controller="Banner", action="BannerCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminBannerEdit",
            pattern: "admin/banner/duzenle/{id}",
            defaults: new { controller="Banner", action="BannerEdit"}
        );
        
            // ADMİN/PRODUCT ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminProductIndex",
            pattern: "admin/urun",
            defaults: new { controller="Product", action="ProductList"}
        );
        endpoints.MapControllerRoute(
            name: "adminProductCreate",
            pattern: "admin/urun/ekle",
            defaults: new { controller="Product", action="ProductCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminProductEdit",
            pattern: "admin/urun/duzenle/{id}",
            defaults: new { controller="Product", action="ProductEdit"}
        );

            // ADMİN/PRODUCT/IMG ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminProductResim",
            pattern: "admin/urun/resim/{id}",
            defaults: new { controller="ProductImage", action="ProductImageList"}
        );

            // ADMİN/PRODUCT/DESCRIPTION ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminDescriptionList",
            pattern: "admin/urun/aciklama/{id}",
            defaults: new { controller="Description", action="DescriptionList"}
        );
        endpoints.MapControllerRoute(
            name: "adminDescriptionCreate",
            pattern: "admin/urun/aciklama/ekle/{proId}",
            defaults: new { controller="Description", action="DescriptionCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminDescriptionEdit",
            pattern: "admin/urun/aciklama/duzenle/{id}",
            defaults: new { controller="Description", action="DescriptionEdit"}
        );

            // ADMİN/PRODUCT/VARIANT ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminVariantEdit",
            pattern: "admin/urun/varyant/duzenle/{id}",
            defaults: new { controller="Variant", action="VariantEdit"}
        );

            // ADMİN/PRODUCT/PRODUCTSIZE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminProductSizeEdit",
            pattern: "admin/urun/secenek/duzenle/{id}",
            defaults: new { controller="ProductSize", action="ProductSizeEdit"}
        );

            // ADMİN/PRODUCT/LISTE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminListList",
            pattern: "admin/urun/liste/{id}",
            defaults: new { controller="List", action="ListList"}
        );
        endpoints.MapControllerRoute(
            name: "adminListCreate",
            pattern: "admin/urun/liste/ekle/{id}",
            defaults: new { controller="List", action="ListCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminListEdit",
            pattern: "admin/urun/liste/duzenle/{id}",
            defaults: new { controller="List", action="ListEdit"}
        );
        endpoints.MapControllerRoute(
            name: "adminListProduct",
            pattern: "admin/urun/liste/detay/{id}",
            defaults: new { controller="List", action="ListProductList"}
        );

            // ADMİN/SIZETYPE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminSizeTypeList",
            pattern: "admin/secenek",
            defaults: new { controller="SizeType", action="SizeTypeList"}
        );
        endpoints.MapControllerRoute(
            name: "adminSizeTypeCreate",
            pattern: "admin/secenek/ekle",
            defaults: new { controller="SizeType", action="SizeTypeCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminSizeTypeEdit",
            pattern: "admin/secenek/duzenle/{id}",
            defaults: new { controller="SizeType", action="SizeTypeEdit"}
        );

            // ADMİN/SIZE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminSizeList",
            pattern: "admin/secenek/alt/{id}",
            defaults: new { controller="Size", action="SizeList"}
        );
        endpoints.MapControllerRoute(
            name: "adminSizeCreate",
            pattern: "admin/secenek/alt/ekle/{id}",
            defaults: new { controller="Size", action="SizeCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminSizeEdit",
            pattern: "admin/secenek/alt/duzenle/{id}",
            defaults: new { controller="Size", action="SizeEdit"}
        );

            // ADMİN/KATEGORİ ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminCategoryList",
            pattern: "admin/kategori",
            defaults: new { controller="Category", action="CategoryList"}
        );
        endpoints.MapControllerRoute(
            name: "adminCategoryCreate",
            pattern: "admin/kategori/ekle/{id?}",
            defaults: new { controller="Category", action="CategoryCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminCategoryEdit",
            pattern: "admin/kategori/duzenle/{id}",
            defaults: new { controller="Category", action="CategoryEdit"}
        );

            // ADMİN/KATEGORİ2 ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminCategory2List",
            pattern: "admin/kategori2/{id}",
            defaults: new { controller="Category2", action="Category2List"}
        );
        endpoints.MapControllerRoute(
            name: "adminCategory2Create",
            pattern: "admin/kategori2/ekle/{id?}",
            defaults: new { controller="Category2", action="Category2Create"}
        );
        endpoints.MapControllerRoute(
            name: "adminCategory2Edit",
            pattern: "admin/kategori2/duzenle/{id}",
            defaults: new { controller="Category2", action="Category2Edit"}
        );

            // ADMİN/KATEGORİ3 ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminCategory3List",
            pattern: "admin/kategori3/{id}",
            defaults: new { controller="Category3", action="Category3List"}
        );
        endpoints.MapControllerRoute(
            name: "adminCategory3Create",
            pattern: "admin/kategori3/ekle/{id?}",
            defaults: new { controller="Category3", action="Category3Create"}
        );
        endpoints.MapControllerRoute(
            name: "adminCategory3Edit",
            pattern: "admin/kategori3/duzenle/{id}",
            defaults: new { controller="Category3", action="Category3Edit"}
        );

            // ADMİN/KULLANICI ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminUserIndex",
            pattern: "admin/kullanici",
            defaults: new { controller="AdminAccount", action="IndexAccount"}
        );
        endpoints.MapControllerRoute(
            name: "adminUserCreate",
            pattern: "admin/kullanici/kayit",
            defaults: new { controller="AdminAccount", action="Register"}
        );
        endpoints.MapControllerRoute(
            name: "adminUserEdit",
            pattern: "admin/kullanici/duzenle/{id}",
            defaults: new { controller="AdminAccount", action="Edit"}
        );
        endpoints.MapControllerRoute(
            name: "adminMailOnay",
            pattern: "mailonay/kullanici",
            defaults: new { controller="AdminAccount", action="EmailOnay"}
        );
        endpoints.MapControllerRoute(
            name: "adminSifreYenile",
            pattern: "sifreyenile/kullanici",
            defaults: new { controller="AdminAccount", action="SifremiUnuttum"}
        );

            // ADMİN/ROLE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminRoleIndex",
            pattern: "admin/rol",
            defaults: new { controller="Role", action="RoleList"}
        );
        endpoints.MapControllerRoute(
            name: "adminRoleCreate",
            pattern: "admin/rol/ekle",
            defaults: new { controller="Role", action="RoleCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminRoleEdit",
            pattern: "admin/rol/duzenle/{id}",
            defaults: new { controller="Role", action="RoleEdit"}
        );

        // ADMİN/POPUP ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminPopupIndex",
            pattern: "admin/popup",
            defaults: new { controller="Popup", action="PopupList"}
        );
        endpoints.MapControllerRoute(
            name: "adminPopupCreate",
            pattern: "admin/popup/ekle",
            defaults: new { controller="Popup", action="PopupCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminPopupEdit",
            pattern: "admin/popup/duzenle/{id}",
            defaults: new { controller="Popup", action="PopupEdit"}
        );

            // ADMİN/GIFTCARD ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminGiftCardIndex",
            pattern: "admin/hediyeceki",
            defaults: new { controller="GiftCard", action="GiftCardList"}
        );
        endpoints.MapControllerRoute(
            name: "adminGiftCardCreate",
            pattern: "admin/hediyeceki/ekle",
            defaults: new { controller="GiftCard", action="GiftCardCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminGiftCardEdit",
            pattern: "admin/hediyeceki/duzenle/{id}",
            defaults: new { controller="GiftCard", action="GiftCardEdit"}
        );

            // ADMİN/EFTHAVALE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminEftHavaleList",
            pattern: "admin/efthavale",
            defaults: new { controller="EftHavale", action="EftHavaleList"}
        );

            // ADMİN/SUPPORT ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminSupportList",
            pattern: "admin/destek",
            defaults: new { controller="Support", action="SupportList"}
        );
        endpoints.MapControllerRoute(
            name: "adminSupportDetail",
            pattern: "admin/destek/detay/{id}",
            defaults: new { controller="Support", action="SupportDetail"}
        );

            // ADMİN/MESAJ ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminMessageIndex",
            pattern: "admin/mesaj",
            defaults: new { controller="Message", action="MessageList"}
        );
        endpoints.MapControllerRoute(
            name: "adminMessageDetail",
            pattern: "admin/mesaj/detay/{id}",
            defaults: new { controller="Message", action="MessageDetail"}
        );

            // ADMİN/ABONE ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminSubscribeIndex",
            pattern: "admin/abone",
            defaults: new { controller="Subscribe", action="SubscribeList"}
        );
        endpoints.MapControllerRoute(
            name: "adminSubscribeCreate",
            pattern: "admin/abone/ekle",
            defaults: new { controller="Subscribe", action="SubscribeCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminSubscribeEdit",
            pattern: "admin/abone/duzenle/{id}",
            defaults: new { controller="Subscribe", action="SubscribeEdit"}
        );
        endpoints.MapControllerRoute(
            name: "subscribeApproval",
            pattern: "mailonay/abone",
            defaults: new { controller="Subscribe", action="SubscribeApproval"}
        );

            // ADMİN/FOOTER ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminFooter",
            pattern: "admin/footer",
            defaults: new { controller="Footer", action="FooterList"}
        );
        endpoints.MapControllerRoute(
            name: "adminFooterCreate",
            pattern: "admin/footer/ekle",
            defaults: new { controller="Footer", action="FooterCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminFooterEdit",
            pattern: "admin/footer/düzenle/{id}",
            defaults: new { controller="Footer", action="FooterEdit"}
        );

            // ADMİN/FOOTERALT ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminFooterAlt",
            pattern: "admin/footeralt/{id}",
            defaults: new { controller="FooterAlt", action="FooterAltList"}
        );
        endpoints.MapControllerRoute(
            name: "adminFooterAltCreate",
            pattern: "admin/footeralt/ekle/{id}",
            defaults: new { controller="FooterAlt", action="FooterAltCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminFooterAltEdit",
            pattern: "admin/footeralt/düzenle/{id}",
            defaults: new { controller="FooterAlt", action="FooterAltEdit"}
        );

            // ADMİN/BANKACCOUNT ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminBankAccount",
            pattern: "admin/bankahesap",
            defaults: new { controller="BankAccount", action="BankAccountList"}
        );
        endpoints.MapControllerRoute(
            name: "adminBankAccountCreate",
            pattern: "admin/bankahesap/ekle",
            defaults: new { controller="BankAccount", action="BankAccountCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminBankAccountEdit",
            pattern: "admin/bankahesap/düzenle/{id}",
            defaults: new { controller="BankAccount", action="BankAccountEdit"}
        );

            // ADMİN/CARGO ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminCargo",
            pattern: "admin/kargo",
            defaults: new { controller="Cargo", action="CargoList"}
        );
        endpoints.MapControllerRoute(
            name: "adminCargoCreate",
            pattern: "admin/kargo/ekle",
            defaults: new { controller="Cargo", action="CargoCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adminCargoEdit",
            pattern: "admin/kargo/düzenle/{id}",
            defaults: new { controller="Cargo", action="CargoEdit"}
        );

            // ADMİN/SETTING ALANI -----------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "adminSetting",
            pattern: "admin/ayarlar",
            defaults: new { controller="Setting", action="SettingIndex"}
        );

        // CLIENT USER ALANI ----------------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "userIndex",
            pattern: "hesabim",
            defaults: new { controller="UserAccount", action="AccountIndex"}
        );
        endpoints.MapControllerRoute(
            name: "orderListClient",
            pattern: "hesabim/siparislerim",
            defaults: new { controller="Order", action="OrderListClient"}
        );
        endpoints.MapControllerRoute(
            name: "orderIadeCreate",
            pattern: "hesabim/siparislerim/iade/{orderId}",
            defaults: new { controller="OrderIade", action="OrderIadeCreate"}
        );
        endpoints.MapControllerRoute(
            name: "orderIadeList",
            pattern: "hesabim/iade-taleplerim",
            defaults: new { controller="OrderIade", action="OrderIadeListClient"}
        );
        endpoints.MapControllerRoute(
            name: "userAccountLogint",
            pattern: "hesabim/giris",
            defaults: new { controller="UserAccount", action="AccountLogin"}
        );
        endpoints.MapControllerRoute(
            name: "userAccountKayit",
            pattern: "kayitol",
            defaults: new { controller="UserAccount", action="AccountRegister"}
        );
        endpoints.MapControllerRoute(
            name: "userAccountLogint",
            pattern: "sifremi-unuttum",
            defaults: new { controller="UserAccount", action="SifremiUnuttum"}
        );
        endpoints.MapControllerRoute(
            name: "userAccountEdit",
            pattern: "hesabim/kisisel-bilgilerim",
            defaults: new { controller="UserAccount", action="AccountEdit"}
        );
        endpoints.MapControllerRoute(
            name: "adresList",
            pattern: "hesabim/adres-listem",
            defaults: new { controller="Adres", action="AdresList"}
        );
        endpoints.MapControllerRoute(
            name: "adresCreate",
            pattern: "hesabim/adres-ekle",
            defaults: new { controller="Adres", action="AdresCreate"}
        );
        endpoints.MapControllerRoute(
            name: "adresEdit",
            pattern: "hesabim/adres-duzenle/{id}",
            defaults: new { controller="Adres", action="AdresEdit"}
        );
        endpoints.MapControllerRoute(
            name: "favoriteList",
            pattern: "hesabim/favori-listem",
            defaults: new { controller="Favorite", action="FavoriteList"}
        );
        endpoints.MapControllerRoute(
            name: "supportListClient",
            pattern: "hesabim/destek-taleplerim",
            defaults: new { controller="Support", action="SupportListClient"}
        );
        endpoints.MapControllerRoute(
            name: "eftHavaleForm",
            pattern: "hesabim/odeme-bildirimlerim",
            defaults: new { controller="EftHavale", action="EftHavaleForm"}
        );
        endpoints.MapControllerRoute(
            name: "giftCardListClient",
            pattern: "hesabim/hediye-ceklerim",
            defaults: new { controller="GiftCard", action="GiftCardListClient"}
        );
        endpoints.MapControllerRoute(
            name: "cartIndex",
            pattern: "sepet",
            defaults: new { controller="Cart", action="CartIndex"}
        );
        endpoints.MapControllerRoute(
            name: "cartAdres",
            pattern: "sepet/adres",
            defaults: new { controller="Cart", action="CartAdres"}
        );
        endpoints.MapControllerRoute(
            name: "cartOdeme",
            pattern: "sepet/odeme",
            defaults: new { controller="Cart", action="Odeme"}
        );
        endpoints.MapControllerRoute(
            name: "cikis",
            pattern: "cikis",
            defaults: new { controller="UserAccount", action="AccountLogout"}
        );


        // CLIENT ALANI ----------------------------------------------------------------
        endpoints.MapControllerRoute(
            name: "settingKvkk",
            pattern: "kvkk",
            defaults: new { controller="Setting", action="SettingKvkk"}
        );

        endpoints.MapControllerRoute(
            name: "footerClient",
            pattern: "footer/{url}",
            defaults: new { controller="FooterAlt", action="FooterAltDetailClient"}
        );
        
        endpoints.MapControllerRoute(
            name: "searchRoute",
            pattern: "search/{q}",
            defaults: new { controller="Home", action="Search"}
        );

        endpoints.MapControllerRoute(
            name: "ProductDetailRoute",
            pattern: "{url}/{id}",
            defaults: new { controller="Product", action="ProductDetail"}
        );

        endpoints.MapControllerRoute(
            name: "categoryRoute",
            pattern: "{url}",
            defaults: new { controller="Category", action="CategoryListClient"}
        );

        endpoints.MapControllerRoute(
            name: "category2Route",
            pattern: "{urlUst}/{url}/2",
            defaults: new { controller="Category2", action="Category2ListClient" }
        );

        endpoints.MapControllerRoute(
            name: "category3Route",
            pattern: "{urlUst}/{urlUst2}/{url}/3",
            defaults: new { controller="Category3", action="Category3ListClient"}
        );

        endpoints.MapControllerRoute(
            name: "defaultRoute",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    });

    app.MigrateDatabase().Run();

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // USERACCOUNT İLE İLGİLİ MODELLER BU DOSYADA YER ALIR

    public class AccountIndexModel
    {
        public int UserId { get; set; }
        public string UserAdi { get; set; }
        public string UserSoyadi { get; set; }
    }

    public class AccountEditModel
    {
        public string UserId { get; set; }
        
        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserAdi { get; set; }

        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserSoyadi { get; set; }
        public string UserCinsiyet { get; set; }
        public DateTime UserBirthDate { get; set; }

        // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&-_])[A-Za-z\d$@$!%*?&-_]{8,}", ErrorMessage = "En az 1 büyük, 1 küçük, 1 sayı, 1 özel karakter bulunmalı.")]
        public string Password { get; set; }

        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string NewRePassword { get; set; }

        // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }

        // [RegularExpression(@"(?=.*\d)[\d]{10,}", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }
        public IEnumerable<string> SeciliRoller { get; set; }
        public IEnumerable<string> TumRoller { get; set; }
    }
    
    public class AccountLoginModel
    {
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
    
    public class AccountRegisterModel
    {
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserAdi { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserSoyadi { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string NewRePassword { get; set; }
    }
    
    // AdminAccount/SifremiUnuttum
    public class UserSifremiUnuttumModel
    {
        // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }
    }

    // AdminAccount/SifreYenile
    public class UserSifreYenileModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&-_])[A-Za-z\d$@$!%*?&-_]{8,}", ErrorMessage = "En az 1 büyük, 1 küçük, 1 sayı, 1 özel karakter bulunmalı.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string NewRePassword { get; set; }
    }








    // AdminAccount/Register
    public class UserModel
    {
        public string UserId { get; set; }
        
        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserAdi { get; set; }

        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserSoyadi { get; set; }
        public string UserCinsiyet { get; set; }
        public DateTime UserRegisterDate { get; set; }
        public DateTime UserBirthDate { get; set; }

        // [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}", ErrorMessage = "En az 5 karakterli olmalı, 1 harf ve 1 sayı bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserName { get; set; }

        // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&-_])[A-Za-z\d$@$!%*?&-_]{8,}", ErrorMessage = "En az 1 büyük, 1 küçük, 1 sayı, 1 özel karakter bulunmalı.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string RePassword { get; set; }

        // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        [RegularExpression(@"(?=.*\d)[\d]{11,}", ErrorMessage = "11 haneli ve başında 0(sıfır) olan geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }
        public IEnumerable<string> SeciliRoller { get; set; }
        public IEnumerable<string> TumRoller { get; set; }
    }

    // AdminAccount/IndexAccount
    public class AdminUserIndexModel
    {
        public PageInfo PageInfo { get; set; }
        public List<ProjeUser> Users { get; set; }
    }

    // AdminAccount/Login
    public class UserLoginModel
    {
        // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }

    // AdminAccount/Edit
    // AdminAccount/EditAdmin
    public class UserEditModel
    {
        public string UserId { get; set; }
        
        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserAdi { get; set; }

        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserSoyadi { get; set; }
        public string UserCinsiyet { get; set; }
        public DateTime UserRegisterDate { get; set; }
        public DateTime UserBirthDate { get; set; }

        // [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}", ErrorMessage = "En az 5 karakterli olmalı, 1 harf ve 1 sayı bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserName { get; set; }

        // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&-_])[A-Za-z\d$@$!%*?&-_]{8,}", ErrorMessage = "En az 1 büyük, 1 küçük, 1 sayı, 1 özel karakter bulunmalı.")]
        public string Password { get; set; }

        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string NewRePassword { get; set; }

        // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        [RegularExpression(@"(?=.*\d)[\d]{11,}", ErrorMessage = "11 haneli ve başında 0(sıfır) olan geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }
        public IEnumerable<string> SeciliRoller { get; set; }
        public IEnumerable<string> TumRoller { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class CreditCardModel
    {
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string CreditCardName { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Kredi Kartınızın Ön Yüzündeki 16 Basamaklı Kredi Kartı Numaranızı Giriniz")]
        public string CreditCardNumber { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Kredi Kartınızın Son Kullanım Tarihinin İlk 2 Hanesini Giriniz")]
        public string CreditCardMonth { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Kredi Kartınızın Son Kullanım Tarihinin Son 2 Hanesini Giriniz")]
        public string CreditCardYear { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Kredi Kartınızın Arka Yüzündeki 3 Basamaklı Güvenlik Kodunu Giriniz")]
        public string CreditCardCvc { get; set; }
        
        public int AdresId { get; set; }
        public string PaymentType { get; set; }
        public double SiparisToplam { get; set; }
        public double GenelToplam { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }
}
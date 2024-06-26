using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Message
    public class PageMessageModel
    {
        public int MessageId { get; set; }

        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string MessageName { get; set; }

        // [RegularExpression(@"^(?=.*[A-Za-zğıüöş])[A-Za-zğıüöş]{0,}", ErrorMessage = "Sadece harf bulunmalıdır.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string MessageSurname { get; set; }
        public string MessagePhone { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        // [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        public string MessageMail { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }

    // Message/MessageList içinde kullanılıyor
    public class AdminMessageIndexModel
    {
        public PageInfo PageInfo { get; set; } // BlogModel içinde tanımlı
        public List<Message> Messages { get; set; }
    }
}
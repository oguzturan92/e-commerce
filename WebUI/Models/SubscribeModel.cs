using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Subscribe/
    public class SubscribeModel
    {
        public int SubscribeId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        public string SubscribeMail { get; set; }
        public string SubscribeToken { get; set; }
        public bool SubscribeMailApproval { get; set; }
        public bool SubscribeContactApproval { get; set; }
        public DateTime SubscribeDate { get; set; }
    }

    // Subscribe/SubscribeList içinde kullanılıyor
    public class AdminSubscribeIndexModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Subscribe> Subscribes { get; set; }
    }
}
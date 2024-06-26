using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // GiftCard/
    public class GiftCardModel
    {
        public int GiftCardId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string GiftCardTitle { get; set; }
        public int GiftCardOran { get; set; }
        public double GiftCardMiktar { get; set; }
        public bool GiftCardApproval { get; set; }
        public DateTime GiftCardDateTime { get; set; }
        public int GiftCardLimit { get; set; }
        public List<GiftCardUser> GiftCardUsers { get; set; }
        public List<ProjeUser> SelectedGiftCardUsers { get; set; }
        public List<GiftCard> GiftCards { get; set; }

        public string userName { get; set; }
        public string userEmail { get; set; }
    }
}
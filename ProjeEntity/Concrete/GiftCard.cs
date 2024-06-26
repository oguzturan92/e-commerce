using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class GiftCard
    {
        public int GiftCardId { get; set; }
        public string GiftCardTitle { get; set; }
        public int GiftCardOran { get; set; }
        public double GiftCardMiktar { get; set; }
        public bool GiftCardApproval { get; set; }
        public DateTime GiftCardDateTime { get; set; }
        public int GiftCardLimit { get; set; }
        public List<GiftCardUser> GiftCardUsers { get; set; }
    }
}
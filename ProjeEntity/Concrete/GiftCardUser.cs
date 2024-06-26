using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class GiftCardUser
    {
        public int GiftCardId { get; set; }
        public GiftCard GiftCard { get; set; }
        public int ProjeUserId { get; set; }
        public ProjeUser ProjeUser { get; set; }
    }
}
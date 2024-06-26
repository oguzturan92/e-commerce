using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Sepet
    {
        public int SepetId { get; set; }

        public List<SepetLine> SepetLines { get; set; }

        public int ProjeUserId { get; set; }
        public ProjeUser ProjeUser { get; set; }

        public double SiparisKdv { get; set; }
        public double SiparisToplam { get; set; }
        public double GenelToplam { get; set; }

        public double CargoPrice { get; set; }

        public string GiftCardTitle { get; set; }
        public string GiftCardContent { get; set; }
    }
}
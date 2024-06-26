using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class FooterAlt
    {
        public int FooterAltId { get; set; }
        public string FooterAltSeoTitle { get; set; }
        public string FooterAltSeoDescription { get; set; }
        public string FooterAltSeoKeyword { get; set; }
        public string FooterAltTitle { get; set; }
        public string FooterAltContent { get; set; }
        public string FooterAltLink { get; set; }
        public bool FooterAltApproval { get; set; }
        public int? FooterAltSort { get; set; }

        public int FooterId { get; set; }
        public Footer Footer { get; set; }
    }
}
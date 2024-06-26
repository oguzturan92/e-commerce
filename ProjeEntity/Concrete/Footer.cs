using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Footer
    {
        public int FooterId { get; set; }
        public string FooterTitle { get; set; }
        public bool FooterApproval { get; set; }
        public int? FooterSort { get; set; }

        public List<FooterAlt> FooterAlts { get; set; }
    }
}
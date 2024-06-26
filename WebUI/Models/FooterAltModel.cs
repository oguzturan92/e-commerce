using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // FooterAlt/
    public class FooterAltModel
    {
        public int FooterAltId { get; set; }
        public string FooterAltSeoTitle { get; set; }
        public string FooterAltSeoDescription { get; set; }
        public string FooterAltSeoKeyword { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string FooterAltTitle { get; set; }
        public string FooterAltContent { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string FooterAltLink { get; set; }
        public bool FooterAltApproval { get; set; }
        public int? FooterAltSort { get; set; }
        public int FooterId { get; set; }
        public FooterAlt FooterAlt { get; set; }
        public List<FooterAlt> FooterAlts { get; set; }
    }
}
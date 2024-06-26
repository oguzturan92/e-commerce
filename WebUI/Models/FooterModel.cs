using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Footer/
    public class FooterModel
    {
        public int FooterId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string FooterTitle { get; set; }
        public bool FooterApproval { get; set; }
        public int? FooterSort { get; set; }

        public List<FooterAlt> FooterAlts { get; set; }
        public List<Footer> Footers { get; set; }
    }
}
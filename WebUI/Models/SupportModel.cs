using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Support/
    public class SupportModel
    {
        public int SupportId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string SupportSubject { get; set; }
        public string SupportState { get; set; }
        public string SupportDateTime { get; set; }
        public int ProjeUserId { get; set; }
        public ProjeUser User { get; set; }
        public List<Support> Supports { get; set; }
        public Support Support { get; set; }
        public List<SupportLine> SupportLines { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string SupportLineContent { get; set; }
        public string SupportLineDateTime { get; set; }
        public string SupportLineAnswering { get; set; }
    }
}
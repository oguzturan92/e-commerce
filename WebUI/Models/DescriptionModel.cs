using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Description/
    public class DescriptionModel
    {
        public int DescriptionId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string DescriptionName { get; set; }
        public string DescriptionContent { get; set; }
        public int? DescriptionSort { get; set; }
        public bool DescriptionApproval { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<Description> Descriptions { get; set; }
    }
}
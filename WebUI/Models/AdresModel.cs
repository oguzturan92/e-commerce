using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Adres/
    public class AdresModel
    {
        public int AdresId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string AdresTitle { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string AdresNameSurname { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string AdresContent { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string AdresCounty { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string AdresCity { get; set; }
        public string AdresPostCode { get; set; }
        public string AdresPhoneNumber { get; set; }
        public string AdresTcNo { get; set; }
        public string AdresFaturaType { get; set; }
        public List<Adres> Adreses { get; set; }
        public List<OrderAndAdresJunc> OrderAndAdresJuncs { get; set; }
        
        public int ProjeUserId { get; set; }
        public ProjeUser ProjeUser { get; set; }
    }
}
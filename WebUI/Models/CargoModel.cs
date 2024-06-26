using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class CargoModel
    {
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string CargoName { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public double CargoFreePrice { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public double CargoPrice { get; set; }
        public bool CargoApproval { get; set; }
        public int? CargoSort { get; set; }

        public List<Cargo> Cargos { get; set; }
    }
}
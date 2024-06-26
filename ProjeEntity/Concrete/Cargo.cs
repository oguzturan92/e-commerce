using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public string CargoName { get; set; }
        public double CargoFreePrice { get; set; }
        public double CargoPrice { get; set; }
        public bool CargoApproval { get; set; }
        public int? CargoSort { get; set; }
    }
}
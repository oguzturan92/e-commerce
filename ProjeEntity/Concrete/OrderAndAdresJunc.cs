using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class OrderAndAdresJunc
    {
        [Key]
        public int OrderAndAdresJuncId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int OrderAdresId { get; set; }
        public OrderAdres OrderAdres { get; set; }
    }
}
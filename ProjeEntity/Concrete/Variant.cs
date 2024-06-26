using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Variant
    {
        public int VariantId { get; set; }
        public int VariantSecond { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
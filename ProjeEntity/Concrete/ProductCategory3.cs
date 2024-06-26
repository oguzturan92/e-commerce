using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class ProductCategory3
    {
        public int Category3Id { get; set; }
        public Category3 Category3 { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
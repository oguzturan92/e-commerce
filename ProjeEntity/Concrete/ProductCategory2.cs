using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class ProductCategory2
    {
        public int Category2Id { get; set; }
        public Category2 Category2 { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
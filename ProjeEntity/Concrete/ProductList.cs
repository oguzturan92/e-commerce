using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class ProductList
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int ListId { get; set; }
        public List List { get; set; }
    }
}
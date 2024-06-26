using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class ProductSize
    {
        public int ProductSizeId { get; set; }
        public double ProductSizePrice { get; set; }
        public int ProductSizeStock { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
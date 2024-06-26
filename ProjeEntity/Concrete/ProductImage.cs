using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ProductImageName { get; set; }
        public int ProductImageSort { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
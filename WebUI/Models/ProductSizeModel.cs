using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class ProductSizeModel
    {
        public int ProductSizeId { get; set; }
        public double ProductSizePrice { get; set; }
        public int ProductSizeStock { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<ProductSize> EklenmisSizes { get; set; }
        public List<SizeType> SizeTypes { get; set; }
        public int ProductIdGelen { get; set; }
        public string Secim { get; set; }
    }
}
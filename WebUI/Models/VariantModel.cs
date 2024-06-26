using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Varyant/
    public class VariantModel
    {
        public int VariantId { get; set; }
        public int VariantSecond { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public List<Product> VariantSelected { get; set; }
        public List<Product> Products { get; set; }
    }
}
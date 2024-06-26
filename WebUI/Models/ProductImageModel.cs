using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class ProductImageModel
    {
        public int ProductImageId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string ProductImageName { get; set; }
        public int ProductImageSort{ get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Category/
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        // [RegularExpression(@"^(?=.*[a-z$-])[a-z$-]{0,}", ErrorMessage = "Bu alanda küçük harf, ingilizce karakter ve boşluk yerine ' - ' kullanabilirsiniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string CategoryUrl { get; set; }
        public string CategoryImage { get; set; }
        public bool CategoryApproval { get; set; }
        public string CategoryVisibility { get; set; }
        public int? CategorySort { get; set; }
        public string CategoryListType { get; set; }
        public string CategorySeoTitle { get; set; }
        public string CategorySeoDescription { get; set; }
        public string CategorySeoKeyword { get; set; }
        public List<Category> Categories { get; set; }

    }
}
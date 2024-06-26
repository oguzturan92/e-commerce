using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Category/
    public class Category3Model
    {
        public int Category3Id { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Category3Name { get; set; }
        public string Category3Description { get; set; }

        // [RegularExpression(@"^(?=.*[a-z$-])[a-z$-]{0,}", ErrorMessage = "Bu alanda küçük harf, ingilizce karakter ve boşluk yerine ' - ' kullanabilirsiniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Category3Url { get; set; }
        public string Category3Image { get; set; }
        public bool Category3Approval { get; set; }
        public string Category3Visibility { get; set; }
        public int? Category3Sort { get; set; }
        public string Category3ListType { get; set; }
        public string Category3SeoTitle { get; set; }
        public string Category3SeoDescription { get; set; }
        public string Category3SeoKeyword { get; set; }
        public List<Category3> Category3s { get; set; }
        public int CategoryId { get; set; }
        public int Category2Id { get; set; }

    }
}
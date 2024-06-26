using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Category/
    public class Category2Model
    {
        public int Category2Id { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Category2Name { get; set; }
        public string Category2Description { get; set; }

        // [RegularExpression(@"^(?=.*[a-z$-])[a-z$-]{0,}", ErrorMessage = "Bu alanda küçük harf, ingilizce karakter ve boşluk yerine ' - ' kullanabilirsiniz.")]
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Category2Url { get; set; }
        public string Category2Image { get; set; }
        public bool Category2Approval { get; set; }
        public string Category2Visibility { get; set; }
        public int? Category2Sort { get; set; }
        public string Category2ListType { get; set; }
        public string Category2SeoTitle { get; set; }
        public string Category2SeoDescription { get; set; }
        public string Category2SeoKeyword { get; set; }
        public List<Category2> Category2s { get; set; }
        public int CategoryId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    // Renk, Numara, Beden bilgilerini tutuyor
    public class SizeType
    {
        public int SizeTypeId { get; set; }
        public string SizeTypeName { get; set; }
        public int? SizeTypeSort { get; set; }
        
        public List<Size> Sizes { get; set; }
    }
}
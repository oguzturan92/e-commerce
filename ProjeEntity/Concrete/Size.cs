using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeTitle { get; set; }
        public string SizeWriteOrImg { get; set; }
        public string SizeWrite { get; set; }
        public string SizeImage { get; set; }
        public int? SizeSort { get; set; }

        public int SizeTypeId { get; set; }
        public SizeType SizeType { get; set; }

        public List<ProductSize> ProductSizes { get; set; }
    }
}
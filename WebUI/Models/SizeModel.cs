using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class SizeModel
    {
        public int SizeId { get; set; }
        public string SizeTitle { get; set; }
        public string SizeWriteOrImg { get; set; }
        public string SizeWrite { get; set; }
        public string SizeImage { get; set; }
        public int? SizeSort { get; set; }
        public List<Size> Sizes { get; set; }
        public int SizeTypeId { get; set; }
        public int ProductId { get; set; }
        public List<SizeType> SizeTypes { get; set; }
    }
}
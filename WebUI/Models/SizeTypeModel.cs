using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class SizeTypeModel
    {
        public int SizeTypeId { get; set; }
        public string SizeTypeName { get; set; }
        public int? SizeTypeSort { get; set; }
        public List<SizeType> SizeTypes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class SupportLine
    {
        public int SupportLineId { get; set; }
        public string SupportLineContent { get; set; }
        public string SupportLineDateTime { get; set; }
        public string SupportLineAnswering { get; set; }
        public int SupportId { get; set; }
        public Support Support { get; set; }
    }
}
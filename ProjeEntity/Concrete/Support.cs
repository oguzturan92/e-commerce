using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Support
    {
        public int SupportId { get; set; }
        public string SupportSubject { get; set; }
        public string SupportState { get; set; }
        public string SupportDateTime { get; set; }
        public int ProjeUserId { get; set; }
        public ProjeUser ProjeUser { get; set; }
        public List<SupportLine> SupportLines { get; set; }
    }
}
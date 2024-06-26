using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class EftHavale
    {
        public int EftHavaleId { get; set; }
        public string EftHavaleOrderNumber { get; set; }
        public double EftHavaleOrderPrice { get; set; }
        public string EftHavaleContent { get; set; }
        public string EftHavaleBankName { get; set; }
        public string EftHavaleDateTime { get; set; }
        public int ProjeUserId { get; set; }
    }
}
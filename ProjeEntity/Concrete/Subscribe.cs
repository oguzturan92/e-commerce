using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }
        public string SubscribeMail { get; set; }
        public string SubscribeToken { get; set; }
        public bool SubscribeMailApproval { get; set; }
        public bool SubscribeContactApproval { get; set; }
        public DateTime SubscribeDate { get; set; }
    }
}
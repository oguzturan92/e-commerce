using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageName { get; set; }
        public string MessageSurname { get; set; }
        public string MessagePhone { get; set; }
        public string MessageMail { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
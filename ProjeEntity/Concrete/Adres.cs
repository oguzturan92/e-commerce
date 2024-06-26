using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Adres
    {
        public int AdresId { get; set; }
        public string AdresTitle { get; set; }
        public string AdresNameSurname { get; set; }
        public string AdresTcNo { get; set; }
        public string AdresContent { get; set; }
        public string AdresCounty { get; set; }
        public string AdresCity { get; set; }
        public string AdresPostCode { get; set; }
        public string AdresPhoneNumber { get; set; }
        public string AdresFaturaType { get; set; }
        
        public int ProjeUserId { get; set; }
        public ProjeUser ProjeUser { get; set; }

        // public List<Order> Orders { get; set; }
        // public List<OrderAdres> OrderAdress { get; set; }
    }
}
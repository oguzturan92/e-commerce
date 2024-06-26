using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class OrderAdres
    {
        // [Key]
        // public int OrderAdresId { get; set; }
        // public int OrderId { get; set; }
        // public Order Order { get; set; }
        // public int AdresId { get; set; }
        // public Adres Adres { get; set; }

        public int OrderAdresId { get; set; }
        public string OrderAdresTitle { get; set; }
        public string OrderAdresNameSurname { get; set; }
        public string OrderAdresTcNo { get; set; }
        public string OrderAdresContent { get; set; }
        public string OrderAdresCounty { get; set; }
        public string OrderAdresCity { get; set; }
        public string OrderAdresPostCode { get; set; }
        public string OrderAdresPhoneNumber { get; set; }
        public string OrderAdresFaturaType { get; set; }

        public List<OrderAndAdresJunc> OrderAndAdresJuncs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class OrderIade
    {
        public int OrderIadeId { get; set; }
        public string OrderIadeNedeni { get; set; }
        public string OrderIadeNot { get; set; }
        public bool OrderIadeOkundu { get; set; }
        public DateTime OrderIadeDate { get; set; }
        public string OrderIadeApproval { get; set; }
        public string BankName { get; set; }
        public string BankIban { get; set; }

        public int IadeUrunId { get; set; }
        public int IadeUrunKodu { get; set; }
        public string IadeUrunAdi { get; set; }
        public string IadeUrunImage { get; set; }
        public string IadeUrunUrl { get; set; }
        public string IadeUrunOzellik { get; set; }
        public int IadeUrunAdet { get; set; }
        public double IadeUrunBirimFiyati { get; set; }
        public double IadeUrunIndirimFiyati { get; set; }

        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
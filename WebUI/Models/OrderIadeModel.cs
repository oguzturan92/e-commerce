using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // OrderIade/
    public class OrderIadeModel
    {
        public int OrderIadeId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string OrderIadeNedeni { get; set; }
        public string OrderIadeNot { get; set; }
        public bool OrderIadeOkundu { get; set; }
        public DateTime OrderIadeDate { get; set; }
        public string OrderIadeApproval { get; set; }

        public int IadeUrunId { get; set; }
        public int IadeUrunKodu { get; set; }
        public string IadeUrunAdi { get; set; }
        public string IadeUrunOzellik { get; set; }
        public int IadeUrunAdet { get; set; }
        public double IadeUrunBirimFiyati { get; set; }
        public double IadeUrunIndirimFiyati { get; set; }

        [Required(ErrorMessage = "En az 1 adet ürün işaretleyiniz.")]
        public List<int> SelectedOrderLineIds { get; set; }
        public List<int> IadeAdedi { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string BankIban { get; set; }

        public int OrderLineId { get; set; }        
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public OrderIade OrderIade { get; set; }
        public List<OrderIade> OrderIades { get; set; }
        public List<OrderIade> UserOrderIades { get; set; }
    }
}
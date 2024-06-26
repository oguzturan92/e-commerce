using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductUrl { get; set; }
        public string ProductSize { get; set; }
        public int ProductCode { get; set; }
        public int IadeEdilebilirAdet { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }


        public int OrderLineQuantity { get; set; }
        public double OrderLineKdv { get; set; }
        public double OrderLineProductPrice { get; set; }
        public double OrderLineCampaignPrice { get; set; }
    }
}
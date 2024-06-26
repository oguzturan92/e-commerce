using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class SepetLine
    {
        public int SepetLineId { get; set; }

        public int SepetId { get; set; }
        public Sepet Sepet { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductSizeId { get; set; }

        public int ProductQuantity { get; set; }
        public double ProductKdv { get; set; }
        public double ProductPrice { get; set; }
        public double ProductCampaignPrice { get; set; }
    }
}
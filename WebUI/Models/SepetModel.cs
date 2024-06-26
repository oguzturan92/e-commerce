using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    public class SepetModel
    {
        public int SepetId { get; set; }

        public Sepet Sepet { get; set; }
        public List<Sepet> Sepets { get; set; }
        public List<Sepet> UserSepets { get; set; }

        public int ProjeUserId { get; set; }
        public Cart CartGet { get; set; }
        public double SiparisKdv { get; set; }
        public double SiparisToplam { get; set; }
        public double GenelToplam { get; set; }

        public int ProductId { get; set; }
        public int SepetLineId { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductSizeId { get; set; }
        public string GiftCardTitle { get; set; }
        public string GiftCardContent { get; set; }
        public int GiftCardId { get; set; }
        public double CargoPrice { get; set; }
        public string CargoName { get; set; }
    }

    public class CartAdresModel
    {
        public Sepet Sepet { get; set; }
        public List<Adres> Adreses { get; set; }
        public int SeciliAdresId { get; set; }
        public int AdresIdFatura { get; set; }
        public int AdresId { get; set; }
        public bool AdresFatura { get; set; }
    }
}
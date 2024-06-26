using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double OrderKdv { get; set; }
        public double OrderGenelPrice { get; set; }
        public double OrderTotalPrice { get; set; }
        public string OrderGiftCard { get; set; }
        public string OrderGiftCardContent { get; set; }
        public string OrderNote { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string OrderState { get; set; }
        public string OrderPaymentId { get; set; }
        public string OrderConversationId { get; set; }
        public string OrderPaymentType { get; set; }
        public double CargoPrice { get; set; }
        public string CargoName { get; set; }
        
        public List<OrderAndAdresJunc> OrderAndAdresJuncs { get; set; }

        public int ProjeUserId { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public List<OrderIade> OrderIades { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<GiftCard> kısmındaki GiftCard adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık GiftCard değerini alıyor.
    public interface IGiftCardDal : IGenericDal<GiftCard>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/GIFCARDDAL dosyasında metotları dolduruyoruz.
        public GiftCard GetGiftCardName(string giftCardTitle);
        public GiftCard GiftCardAndUser(string giftCardTitle);
        public GiftCard GiftCardAndUser(int giftId);
        public List<GiftCard> GiftCardsUserList(int userId);
        void Update(GiftCard entity, int[] projeUserIds);
    }
}
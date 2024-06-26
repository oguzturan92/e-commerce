using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // GIFCARD tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/GIFCARDMANAGER içinde dolduracağız.
    public interface IGiftCardService
    {
        GiftCard GetById(int id);
        List<GiftCard> GetAll();
        void Create(GiftCard entity);
        void Update(GiftCard entity);
        void Delete(GiftCard entity);
        public GiftCard GetGiftCardName(string giftCardTitle);
        public GiftCard GiftCardAndUser(string giftCardTitle);
        public GiftCard GiftCardAndUser(int giftId);
        public List<GiftCard> GiftCardsUserList(int userId);
        void Update(GiftCard entity, int[] projeUserIds);
    }
}
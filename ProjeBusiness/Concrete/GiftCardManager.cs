using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IGIFCARDSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class GiftCardManager : IGiftCardService
    {
        private IGiftCardDal _giftCardDal;
        public GiftCardManager(IGiftCardDal giftCardDal)
        {
            _giftCardDal = giftCardDal;
        }

        // METOTLAR
        public void Create(GiftCard entity)
        {
            _giftCardDal.Create(entity);
        }

        public void Delete(GiftCard entity)
        {
            _giftCardDal.Delete(entity);
        }

        public List<GiftCard> GetAll()
        {
            return _giftCardDal.GetAll().ToList();
        }

        public GiftCard GetById(int id)
        {
            return _giftCardDal.GetById(id);
        }

        public void Update(GiftCard entity)
        {
            _giftCardDal.Update(entity);
        }
        
        public GiftCard GetGiftCardName(string giftCardTitle)
        {
            return _giftCardDal.GetGiftCardName(giftCardTitle);
        }

        public GiftCard GiftCardAndUser(string giftCardTitle)
        {
            return _giftCardDal.GiftCardAndUser(giftCardTitle);
        }

        public GiftCard GiftCardAndUser(int giftId)
        {
            return _giftCardDal.GiftCardAndUser(giftId);
        }

        public List<GiftCard> GiftCardsUserList(int userId)
        {
            return _giftCardDal.GiftCardsUserList(userId);
        }

        public void Update(GiftCard entity, int[] projeUserIds)
        {
            _giftCardDal.Update(entity, projeUserIds);
        }
    }
}
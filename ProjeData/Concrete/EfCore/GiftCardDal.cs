using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IGIFCARDDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class GiftCardDal : GenericDal<GiftCard>, IGiftCardDal
    {
        public GiftCard GetGiftCardName(string giftCardTitle)
        {
            using (var context = new ProjeContext())
            {
                return context.GiftCards
                                .Where(i => i.GiftCardTitle == giftCardTitle)
                                .FirstOrDefault();
            }
        }

        public GiftCard GiftCardAndUser(string giftCardTitle)
        {
            using (var context = new ProjeContext())
            {
                return context.GiftCards
                                .Where(i => i.GiftCardApproval && i.GiftCardTitle == giftCardTitle)
                                .OrderBy(i => i.GiftCardDateTime)
                                .Include(i => i.GiftCardUsers).OrderBy(i => i.GiftCardDateTime)
                                .FirstOrDefault();
            }
        }

        public GiftCard GiftCardAndUser(int giftId)
        {
            using (var context = new ProjeContext())
            {
                return context.GiftCards
                                .Where(i => i.GiftCardId == giftId)
                                .OrderBy(i => i.GiftCardDateTime)
                                .Include(i => i.GiftCardUsers
                                    .OrderByDescending(i => i.ProjeUser.UserRegisterDate)
                                )
                                .ThenInclude(i => i.ProjeUser)
                                .FirstOrDefault();
            }
        }

        public List<GiftCard> GiftCardsUserList(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.GiftCards
                                .Where(i => i.GiftCardApproval && i.GiftCardUsers.Any(i => i.ProjeUserId == userId))
                                .ToList();
            }
        }

        public void Update(GiftCard entity, int[] projeUserIds)
        {
            using (var context = new ProjeContext())
            {
                var giftCard = context.GiftCards
                                    .Where(i => i.GiftCardId == entity.GiftCardId)
                                    .Include(i => i.GiftCardUsers)
                                    .FirstOrDefault();

                if (giftCard != null)
                {
                    giftCard.GiftCardTitle = entity.GiftCardTitle;
                    giftCard.GiftCardOran = entity.GiftCardOran;
                    giftCard.GiftCardMiktar = entity.GiftCardMiktar;
                    giftCard.GiftCardApproval = entity.GiftCardApproval;
                    giftCard.GiftCardLimit = entity.GiftCardLimit;
                    giftCard.GiftCardDateTime = entity.GiftCardDateTime;

                    giftCard.GiftCardUsers = projeUserIds.Select(id => new GiftCardUser()
                    {
                        GiftCardId = entity.GiftCardId,
                        ProjeUserId = id
                    }).ToList();
                    
                    context.SaveChanges();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjeEntity.Concrete
{
    public class ProjeUser : IdentityUser<int>
    {
        public string UserAdi { get; set; }
        public string UserSoyadi { get; set; }
        public string UserCinsiyet { get; set; }
        public DateTime UserBirthDate { get; set; }
        public DateTime UserRegisterDate { get; set; }
        public int SeciliAdresId { get; set; }
        public int SeciliAdresIdFatura { get; set; }
        public List<Adres> Adreses { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<Support> Supports { get; set; }
        public List<GiftCardUser> GiftCardUsers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Favorite/
    public class FavoriteModel
    {
        public int FavoriteId { get; set; }
        public string FavoriteTitle { get; set; }
        public int ProjeUserId { get; set; }
        public ProjeUser ProjeUser { get; set; }
        public List<FavoriteProduct> FavoriteProducts { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}
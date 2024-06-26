using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class FavoriteProduct
    {
        public int FavoriteId { get; set; }
        public Favorite Favorite { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
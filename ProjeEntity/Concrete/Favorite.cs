using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public string FavoriteTitle { get; set; }
        public int ProjeUserId { get; set; }
        public ProjeUser ProjeUser { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public List<FavoriteProduct> FavoriteProducts { get; set; }

    }
}
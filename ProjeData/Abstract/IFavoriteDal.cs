using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<Favorite> kısmındaki Favorite adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık Favorite değerini alıyor.
    public interface IFavoriteDal : IGenericDal<Favorite>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/FAVORİTEDAL dosyasında metotları dolduruyoruz.
        void FavoriteAdd(int id, List<FavoriteProduct> favoriteProducts);
        Favorite GetFavoriteAndFavoriteProduct(int id);
        List<Favorite> UserIdyeGoreFavorites(int userId);
        Favorite UserIdyeGoreDefaultFavorite(int userId);
        List<Favorite> UserIdyeGoreFavorilerVeProductlar(int userId);
        void FavoridenProductSil(int favoriId, int productId);
    }
}
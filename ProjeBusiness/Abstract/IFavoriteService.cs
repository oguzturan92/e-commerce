using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // FAVORİTE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/FAVORİTEMANAGER içinde dolduracağız.
    public interface IFavoriteService
    {
        Favorite GetById(int id);
        List<Favorite> GetAll();
        void Create(Favorite entity);
        void Update(Favorite entity);
        void Delete(Favorite entity);
        void FavoriteAdd(int id, List<FavoriteProduct> favoriteProducts);
        public Favorite GetFavoriteAndFavoriteProduct(int id);
        List<Favorite> UserIdyeGoreFavorites(int userId);
        Favorite UserIdyeGoreDefaultFavorite(int userId);
        List<Favorite> UserIdyeGoreFavorilerVeProductlar(int userId);
        void FavoridenProductSil(int favoriId, int productId);
        
    }
}
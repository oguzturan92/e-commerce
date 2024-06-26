using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IFAVORİTESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class FavoriteManager : IFavoriteService
    {
        private IFavoriteDal _favoriteDal;
        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal;
        }

        // METOTLAR
        public void Create(Favorite entity)
        {
            _favoriteDal.Create(entity);
        }

        public void Delete(Favorite entity)
        {
            _favoriteDal.Delete(entity);
        }

        public List<Favorite> GetAll()
        {
            return _favoriteDal.GetAll().ToList();
        }

        public Favorite GetById(int id)
        {
            return _favoriteDal.GetById(id);
        }

        public void Update(Favorite entity)
        {
            _favoriteDal.Update(entity);
        }

        public void FavoriteAdd(int id, List<FavoriteProduct> favoriteProducts)
        {
            _favoriteDal.FavoriteAdd(id, favoriteProducts);
        }

        public Favorite GetFavoriteAndFavoriteProduct(int id)
        {
            return _favoriteDal.GetFavoriteAndFavoriteProduct(id);
        }

        public List<Favorite> UserIdyeGoreFavorites(int userId)
        {
            return _favoriteDal.UserIdyeGoreFavorites(userId);
        }

        public Favorite UserIdyeGoreDefaultFavorite(int userId)
        {
            return _favoriteDal.UserIdyeGoreDefaultFavorite(userId);
        }

        public List<Favorite> UserIdyeGoreFavorilerVeProductlar(int userId)
        {
            return _favoriteDal.UserIdyeGoreFavorilerVeProductlar(userId);
        }

        public void FavoridenProductSil(int favoriId, int productId)
        {
            _favoriteDal.FavoridenProductSil(favoriId, productId);
        }
    }
}
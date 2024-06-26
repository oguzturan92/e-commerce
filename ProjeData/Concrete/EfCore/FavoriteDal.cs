using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IFAVORİTEDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class FavoriteDal : GenericDal<Favorite>, IFavoriteDal
    {
        public void FavoriteAdd(int id, List<FavoriteProduct> favoriteProducts)
        {
            using (var context = new ProjeContext())
            {
                var favorite = context.Favorites
                                    .Where(i => i.FavoriteId == id)
                                    .FirstOrDefault();
                                    
                if (favorite != null)
                {
                    favorite.FavoriteProducts = favoriteProducts;
                    
                    context.Favorites.Update(favorite);

                    context.SaveChanges();
                }
            }
        }

        public Favorite GetFavoriteAndFavoriteProduct(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.Favorites
                                    .Where(i => i.FavoriteId == id)
                                    .Include(i => i.FavoriteProducts)
                                    .FirstOrDefault();
            }
        }

        public List<Favorite> UserIdyeGoreFavorites(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Favorites
                                    .Where(i => i.ProjeUserId == userId)
                                    .Include(i => i.FavoriteProducts)
                                    .ToList();
            }
        }

        public Favorite UserIdyeGoreDefaultFavorite(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Favorites
                                    .Where(i => i.ProjeUserId == userId && i.FavoriteTitle == "Favorilerim")
                                    .Include(i => i.FavoriteProducts)
                                    .FirstOrDefault();
            }
        }
    
        public List<Favorite> UserIdyeGoreFavorilerVeProductlar(int userId)
        {
            using (var context = new ProjeContext())
            {
                return context.Favorites
                                    .Where(i => i.ProjeUserId == userId)
                                    .Include(i => i.FavoriteProducts)
                                    .ThenInclude(i => i.Product)
                                    .ToList();
            }
        }

        public void FavoridenProductSil(int favoriId, int productId)
        {
            using (var context = new ProjeContext())
            {
                var favori = context.Favorites
                                .Where(i => i.FavoriteId == favoriId)
                                .Include(i => i.FavoriteProducts.Where(i => i.FavoriteId == favoriId && i.ProductId == productId))
                                .FirstOrDefault();
                                
                if (favori != null)
                {
                    context.Remove<FavoriteProduct>(favori.FavoriteProducts[0]);

                    context.SaveChanges();
                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjeData.Abstract
{
    // Kullanılacak olan ortak metotların toplu tutulduğu yer. Diğer Dal sayfalarında, daha özel metotlar yer alır. T yerine, diğer Dal dosyalarının isimleri geliyor olacak.
    public interface IGenericDal<T> 
    {
        // BOŞ METOTLAR - Buraya tanımlanan metotları Concrete içine arabirimi uygulayarak alıyoruz.
        T GetById(int id); // Kullanıcıdan gelen id bilgisine uyan ögeyi döndürür.
        T GetOne(Expression<Func<T, bool>> filter); // Kullanıcıdan gelen sorguya göre tek bir ögeyi getirir.
        List<T> GetAll(Expression<Func<T, bool>> filter=null); // Kullanıcıdan gelen sorguya göre birden fazla ögeyi getirir.
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
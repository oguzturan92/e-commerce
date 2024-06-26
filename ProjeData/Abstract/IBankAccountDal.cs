using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeData.Abstract
{
    // Burdaki IGenericDal<BankAccount> kısmındaki BankAccount adı, IGenericDal içindeki T yerine gidiyor ve ordaki T değeri artık BankAccount değerini alıyor.
    public interface IBankAccountDal : IGenericDal<BankAccount>
    {
    // Burada bu dosyaya özel metotları oluşturuyoruz ve CONCRETE/BANKACCOUNTDAL dosyasında metotları dolduruyoruz.
    }
}
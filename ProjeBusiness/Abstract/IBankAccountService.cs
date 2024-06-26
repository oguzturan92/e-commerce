using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // BANKACCOUNT tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/BANKACCOUNTMANAGER içinde dolduracağız.
    public interface IBankAccountService
    {
        BankAccount GetById(int id);
        List<BankAccount> GetAll();
        void Create(BankAccount entity);
        void Update(BankAccount entity);
        void Delete(BankAccount entity);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IBANKACCOUNTSERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class BankAccountManager : IBankAccountService
    {
        private IBankAccountDal _bankAccountDal;
        public BankAccountManager(IBankAccountDal bankAccountDal)
        {
            _bankAccountDal = bankAccountDal;
        }

        // METOTLAR
        public void Create(BankAccount entity)
        {
            _bankAccountDal.Create(entity);
        }

        public void Delete(BankAccount entity)
        {
            _bankAccountDal.Delete(entity);
        }

        public List<BankAccount> GetAll()
        {
            return _bankAccountDal.GetAll().ToList();
        }

        public BankAccount GetById(int id)
        {
            return _bankAccountDal.GetById(id);
        }

        public void Update(BankAccount entity)
        {
            _bankAccountDal.Update(entity);
        }
    }
}
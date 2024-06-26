using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountIban { get; set; }
        public int? BankAccountSort { get; set; }
    }
}
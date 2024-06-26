using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // BankAccount/
    public class BankAccountModel
    {
        public int BankAccountId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string BankAccountName { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string BankAccountIban { get; set; }
        public int? BankAccountSort { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }
}
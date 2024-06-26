using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{   
    // EftHavale/
    public class EftHavaleModel
    {
        public int EftHavaleId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string EftHavaleOrderNumber { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public double EftHavaleOrderPrice { get; set; }
        public string EftHavaleContent { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string EftHavaleBankName { get; set; }
        public string EftHavaleDateTime { get; set; }
        public int ProjeUserId { get; set; }
        public List<EftHavale> EftHavales { get; set; }
        public List<string> Orders { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }
}
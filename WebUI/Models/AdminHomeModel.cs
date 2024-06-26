using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Admin/Home
    public class AdminHomeModel
    {
        public int Product { get; set; }
        public int Message { get; set; }
        public int Subscribe { get; set; }
        public int User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Description
    {
        public int DescriptionId { get; set; }
        public string DescriptionName { get; set; }
        public string DescriptionContent { get; set; }
        public int? DescriptionSort { get; set; }
        public bool DescriptionApproval { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
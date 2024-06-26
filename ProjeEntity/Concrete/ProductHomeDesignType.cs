using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class ProductHomeDesignType
    {
        public int HomeDesignTypeId { get; set; }
        public HomeDesignType HomeDesignType { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
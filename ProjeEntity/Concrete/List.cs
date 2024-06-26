using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class List
    {
        public int ListId { get; set; }
        public string ListTitle { get; set; }
        public string ListLocation { get; set; }
        public string ListType { get; set; }
        public bool ListApproval { get; set; }
        public int? ListColumn { get; set; }
        public int? ListSort { get; set; }
        public int ProductId { get; set; }

        public List<ProductList> ProductLists { get; set; }
    }
}
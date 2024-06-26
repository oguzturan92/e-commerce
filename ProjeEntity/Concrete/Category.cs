using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryUrl { get; set; }
        public string CategoryImage { get; set; }
        public bool CategoryApproval { get; set; }
        public string CategoryVisibility { get; set; }
        public int? CategorySort { get; set; }
        public string CategoryListType { get; set; }
        public string CategorySeoTitle { get; set; }
        public string CategorySeoDescription { get; set; }
        public string CategorySeoKeyword { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
        public List<Category2> Category2s { get; set; }
    }
}
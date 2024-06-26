using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Category2
    {
        public int Category2Id { get; set; }
        public string Category2Name { get; set; }
        public string Category2Description { get; set; }
        public string Category2Url { get; set; }
        public string Category2Image { get; set; }
        public bool Category2Approval { get; set; }
        public string Category2Visibility { get; set; }
        public int? Category2Sort { get; set; }
        public string Category2ListType { get; set; }
        public string Category2SeoTitle { get; set; }
        public string Category2SeoDescription { get; set; }
        public string Category2SeoKeyword { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Category3> Category3s { get; set; }
        public List<ProductCategory2> ProductCategory2s { get; set; }
        // public List<CampaignCategory2Basic> CampaignCategory2Basics { get; set; }
        // public List<CampaignCategory2Target> CampaignCategory2Targets { get; set; }
    }
}
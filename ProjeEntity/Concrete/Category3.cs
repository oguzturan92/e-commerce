using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Category3
    {
        public int Category3Id { get; set; }
        public string Category3Name { get; set; }
        public string Category3Description { get; set; }
        public string Category3Url { get; set; }
        public string Category3Image { get; set; }
        public bool Category3Approval { get; set; }
        public string Category3Visibility { get; set; }
        public int? Category3Sort { get; set; }
        public string Category3ListType { get; set; }
        public string Category3SeoTitle { get; set; }
        public string Category3SeoDescription { get; set; }
        public string Category3SeoKeyword { get; set; }

        public int Category2Id { get; set; }
        public Category2 Category2 { get; set; }

        public List<ProductCategory3> ProductCategory3s { get; set; }
        // public List<CampaignCategory3Basic> CampaignCategory3Basics { get; set; }
        // public List<CampaignCategory3Target> CampaignCategory3Targets { get; set; }
    }
}
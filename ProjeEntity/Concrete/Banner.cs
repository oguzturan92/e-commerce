using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Banner
    {
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string BannerDescription { get; set; }
        public string BannerLink { get; set; }
        public string BannerImage { get; set; }
        public bool BannerApproval { get; set; }
        public int? BannerSort { get; set; }
        
        public int HomeDesignTypeId { get; set; }
        public HomeDesignType HomeDesignType { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class HomeDesignType
    {
        public int HomeDesignTypeId { get; set; }
        public string HomeDesignTypeName { get; set; }
        public string HomeDesignTypeOption { get; set; }
        public string HomeDesignTypeBannerList { get; set; }
        public string HomeDesignTypeProductList { get; set; }
        public bool HomeDesignTypeApproval { get; set; }
        public int? HomeDesignTypeSort { get; set; }

        public List<ProductHomeDesignType> ProductHomeDesignTypes { get; set; }
        public List<Banner> Banners { get; set; }
    }
}
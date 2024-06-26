using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // HomeDesignType/
    public class HomeDesignTypeModel
    {
        public int HomeDesignTypeId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string HomeDesignTypeName { get; set; }
        public string HomeDesignTypeOption { get; set; }
        public string HomeDesignTypeBannerList { get; set; }
        public string HomeDesignTypeProductList { get; set; }
        public bool HomeDesignTypeApproval { get; set; }
        public int? HomeDesignTypeSort { get; set; }
        public List<ProductHomeDesignType> ProductHomeDesignTypes { get; set; }
        public List<Banner> Banners { get; set; }
        public List<HomeDesignType> HomeDesignTypes { get; set; }
    }
}
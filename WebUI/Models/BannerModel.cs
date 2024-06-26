using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Validators;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Banner/
    public class BannerModel
    {
        public int BannerId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string BannerName { get; set; }
        public string BannerDescription { get; set; }
        public string BannerLink { get; set; }
        public string BannerImage { get; set; }
        public bool BannerApproval { get; set; }
        public int? BannerSort { get; set; }
        public List<Banner> Banners { get; set; }
        public int HomeDesignTypeId { get; set; }
        public HomeDesignType ListHomeDesignType { get; set; }
        public List<HomeDesignType> ListHomeDesignTypes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Home/Index içinde kullanılıyor
    public class HomeModel
    {
        public List<HomeDesignType> HomeDesignTypes { get; set; }
        public List<Banner> Banners { get; set; }
        public List<Slider> Sliders { get; set; }
        public Setting Setting { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Admin/
    public class SliderModel
    {
        public int SliderId { get; set; }
        public string SliderName { get; set; }
        public string SliderDescription { get; set; }
        public string SliderLink { get; set; }
        public string SliderImage { get; set; }
        public string SliderTime { get; set; }
        public bool SliderApproval { get; set; }
        public int? SliderSort { get; set; }
        public DateTime SliderDate { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
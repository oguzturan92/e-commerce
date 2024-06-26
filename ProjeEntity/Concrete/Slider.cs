using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string SliderName { get; set; }
        public string SliderDescription { get; set; }
        public string SliderLink { get; set; }
        public string SliderTime { get; set; }
        public string SliderImage { get; set; }
        public bool SliderApproval { get; set; }
        public int? SliderSort { get; set; }
    }
}
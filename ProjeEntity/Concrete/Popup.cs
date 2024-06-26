using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeEntity.Concrete
{
    public class Popup
    {
        public int PopupId { get; set; }
        public string PopupTitle { get; set; }
        public string PopupDescription { get; set; }
        public string PopupImage { get; set; }
        public string PopupLink { get; set; }
        public int? PopupSort { get; set; }
        public bool PopupApproval { get; set; }
    }
}
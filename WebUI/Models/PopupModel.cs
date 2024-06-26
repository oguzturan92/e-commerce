using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // Popup/
    public class PopupModel
    {
        public int PopupId { get; set; }
        public string PopupTitle { get; set; }
        public string PopupTitleEn { get; set; }
        public string PopupDescription { get; set; }
        public string PopupDescriptionEn { get; set; }
        public string PopupImage { get; set; }
        public string PopupLink { get; set; }
        public int? PopupSort { get; set; }
        public bool PopupApproval { get; set; }
        public Popup Popup { get; set; }
        public List<Popup> Popups { get; set; }
    }
}
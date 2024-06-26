using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    // SETTING İLE İLGİLİ MODELLER BU DOSYADA YER ALIR

    // Setting/SettingIndex içinde kullanılıyor
    public class SettingModel
    {
        public int SettingId { get; set; }
        public string SettingFavicon { get; set; }
        public string SettingLogo { get; set; }
        public string SettingKvkk { get; set; }
        public string SettingSeoTitle { get; set; }
        public string SettingSeoDescription { get; set; }
        public string SettingSeoKeyword { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace WebUI.Models
{
    // ADMİN/BLOG İLE İLGİLİ MODELLER BU DOSYADA YER ALIR

    public class AdminProductModel
    {
        
    }

    // Admin/IndexProduct içinde kullanılıyor
    public class AdminProductIndexModel
    {
        public PageInfo PageInfo { get; set; } // ProductModel içinde tanımlı
        public List<Product> Products { get; set; }
        public int ProductSort { get; set; }
    }
}
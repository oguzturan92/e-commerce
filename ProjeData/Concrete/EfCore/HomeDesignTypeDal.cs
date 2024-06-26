using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeData.Abstract;
using ProjeEntity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ProjeData.Concrete
{
    // ABSTRACT/IHOMEDESIGNTYPEDAL içinde o dosyaya özel tanımlanan metot varsa, burada içini dolduruyoruz.
    public class HomeDesignTypeDal : GenericDal<HomeDesignType>, IHomeDesignTypeDal
    {
        public List<HomeDesignType> HomeDesignTypes()
        {
            using (var context = new ProjeContext())
            {
                return context.HomeDesignTypes
                                .Where(i => i.HomeDesignTypeApproval).OrderBy(i => i.HomeDesignTypeSort)

                                // Junction tabloya geçip Where içindeki kriterlere uyan Product'ları aldık ve sonra Product altındaki ProductImages'leri aldık
                                .Include(i => i.ProductHomeDesignTypes
                                    .Where(i => i.Product.ProductApproval)
                                    .OrderBy(i => i.Product.ProductSort)
                                ) // Ortak tabloya geçip
                                .ThenInclude(i => i.Product) // Product'leri aldık
                                .ThenInclude(i => i.ProductImages
                                    .Take(2)
                                ) // ProductImages'leri aldık

                                // Banner'ları aldık
                                .Include(i => i.Banners
                                    .Where(i => i.BannerApproval)
                                    .OrderBy(i => i.BannerSort)
                                )

                                .ToList();
            }
        }

        public List<HomeDesignType> AllHomeDesignTypes()
        {
            using (var context = new ProjeContext())
            {
                return context.HomeDesignTypes
                            .Where(i => i.HomeDesignTypeOption == "List")
                            .OrderBy(i => i.HomeDesignTypeSort)
                            .ToList();
            }
        }
    }
}
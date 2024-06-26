using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Abstract
{
    // HOMEDESIGNTYPE tablosunda yapacağımız işlemlerin Boş METOT'ları olcak. Bu Boş METOT'ları CONCRETE/HOMEDESIGNTYPEMANAGER içinde dolduracağız.
    public interface IHomeDesignTypeService
    {
        HomeDesignType GetById(int id);
        List<HomeDesignType> GetAll();
        void Create(HomeDesignType entity);
        void Update(HomeDesignType entity);
        void Delete(HomeDesignType entity);
        List<HomeDesignType> HomeDesignTypes();
        List<HomeDesignType> AllHomeDesignTypes();
    }
}
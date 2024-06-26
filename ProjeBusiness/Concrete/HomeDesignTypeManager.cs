using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/IHOMEDESIGNTYPESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class HomeDesignTypeManager : IHomeDesignTypeService
    {
        private IHomeDesignTypeDal _homeDesignTypeDal;
        public HomeDesignTypeManager(IHomeDesignTypeDal homeDesignTypeDal)
        {
            _homeDesignTypeDal = homeDesignTypeDal;
        }

        // METOTLAR
        public void Create(HomeDesignType entity)
        {
            _homeDesignTypeDal.Create(entity);
        }

        public void Delete(HomeDesignType entity)
        {
            _homeDesignTypeDal.Delete(entity);
        }

        public List<HomeDesignType> GetAll()
        {
            return _homeDesignTypeDal.GetAll().ToList();
        }

        public HomeDesignType GetById(int id)
        {
            return _homeDesignTypeDal.GetById(id);
        }

        public void Update(HomeDesignType entity)
        {
            _homeDesignTypeDal.Update(entity);
        }

        public List<HomeDesignType> HomeDesignTypes()
        {
            return _homeDesignTypeDal.HomeDesignTypes();
        }

        public List<HomeDesignType> AllHomeDesignTypes()
        {
            return _homeDesignTypeDal.AllHomeDesignTypes();
        }
    }
}
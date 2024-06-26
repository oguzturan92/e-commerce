using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ISIZETYPESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SizeTypeManager : ISizeTypeService
    {
        private ISizeTypeDal _sizeTypeDal;
        public SizeTypeManager(ISizeTypeDal sizeTypeDal)
        {
            _sizeTypeDal = sizeTypeDal;
        }

        // METOTLAR
        public void Create(SizeType entity)
        {
            _sizeTypeDal.Create(entity);
        }

        public void Delete(SizeType entity)
        {
            _sizeTypeDal.Delete(entity);
        }

        public List<SizeType> GetAll()
        {
            return _sizeTypeDal.GetAll().ToList();
        }

        public SizeType GetById(int id)
        {
            return _sizeTypeDal.GetById(id);
        }

        public void Update(SizeType entity)
        {
            _sizeTypeDal.Update(entity);
        }

        public List<SizeType> SizeTypeAndSize()
        {
            return _sizeTypeDal.SizeTypeAndSize();
        }

        public SizeType ProductDetailSize(int id)
        {
            return _sizeTypeDal.ProductDetailSize(id);
        }

        public List<SizeType> SizeTypeAndSizeFilters(string url)
        {
            return _sizeTypeDal.SizeTypeAndSizeFilters(url);
        }

        public List<SizeType> SizeTypeAndSizeFilters2(string url)
        {
            return _sizeTypeDal.SizeTypeAndSizeFilters2(url);
        }

        public List<SizeType> SizeTypeAndSizeFilters3(string url)
        {
            return _sizeTypeDal.SizeTypeAndSizeFilters3(url);
        }
    }
}
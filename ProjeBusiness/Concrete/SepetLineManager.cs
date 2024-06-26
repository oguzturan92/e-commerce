using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeBusiness.Abstract;
using ProjeData.Abstract;
using ProjeEntity.Concrete;

namespace ProjeBusiness.Concrete
{
    // ABSTRACT/ISEPETLINESERVICE içindeki metotları burada dolduruyoruz. WebUI katmanı burdaki metotları ekrana yansıtıyor.
    public class SepetLineManager : ISepetLineService
    {
        private ISepetLineDal _sepetLineDal;
        public SepetLineManager(ISepetLineDal sepetLineDal)
        {
            _sepetLineDal = sepetLineDal;
        }

        // METOTLAR
        public void Create(SepetLine entity)
        {
            _sepetLineDal.Create(entity);
        }

        public void Delete(SepetLine entity)
        {
            _sepetLineDal.Delete(entity);
        }

        public List<SepetLine> GetAll()
        {
            return _sepetLineDal.GetAll().ToList();
        }

        public SepetLine GetById(int id)
        {
            return _sepetLineDal.GetById(id);
        }

        public void Update(SepetLine entity)
        {
            _sepetLineDal.Update(entity);
        }

        public SepetLine SepetLineAndProduct(int id)
        {
            return _sepetLineDal.SepetLineAndProduct(id);
        }
        
        public SepetLine SepetLineAndProductAndSize(int proId, int proSizeId)
        {
            return _sepetLineDal.SepetLineAndProductAndSize(proId, proSizeId);
        }
    }
}
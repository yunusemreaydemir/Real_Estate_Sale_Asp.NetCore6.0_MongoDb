using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdvertManager : IAdvertService
    {
        private readonly IAdvertDal _advertDal;

        public AdvertManager(IAdvertDal advertDal)
        {
            _advertDal = advertDal;
        }

        public void TDelete(Advert t)
        {
            _advertDal.Delete(t);
        }

        public Advert TGetByID(string id)
        {
            return _advertDal.GetByID(id);
        }

        public List<Advert> TGetList()
        {
            return _advertDal.GetList();
        }

        public void TInsert(Advert t)
        {
            _advertDal.Insert(t);
        }

        public void TUpdate(Advert t)
        {
            _advertDal.Update(t);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SocialMedia entity)
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> TGetAll()        {
            throw new NotImplementedException();
        }

        public SocialMedia TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia entity)
        {
            throw new NotImplementedException();
        }
    }
}

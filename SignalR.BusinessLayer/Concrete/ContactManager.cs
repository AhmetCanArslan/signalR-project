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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactsDal;

        public ContactManager(IContactDal contactsDal)
        {
            _contactsDal = contactsDal;
        }

        public void TAdd(Contact entity)
        {
            _contactsDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactsDal.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return _contactsDal.GetAll();
        }

        public Contact TGetById(int id)
        {
            return _contactsDal.GetById(id);
        }

        public void TUpdate(Contact entity)
        {
            _contactsDal.Update(entity);
        }
    }
}

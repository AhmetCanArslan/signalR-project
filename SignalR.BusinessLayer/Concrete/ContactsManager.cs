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
    public class ContactsManager : IContactsService
    {
        private readonly IContactsDal _contactsDal;

        public ContactsManager(IContactsDal contactsDal)
        {
            _contactsDal = contactsDal;
        }

        public void TAdd(Contacts entity)
        {
            _contactsDal.Add(entity);
        }

        public void TDelete(Contacts entity)
        {
            _contactsDal.Delete(entity);
        }

        public List<Contacts> TGetAll()
        {
            return _contactsDal.GetAll();
        }

        public Contacts TGetById(int id)
        {
            return _contactsDal.GetById(id);
        }

        public void TUpdate(Contacts entity)
        {
            _contactsDal.Update(entity);
        }
    }
}

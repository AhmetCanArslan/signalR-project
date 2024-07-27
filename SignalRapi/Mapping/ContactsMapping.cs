using AutoMapper;
using SignalR.DtoLayer.ContactsDto;
using SignalR.EntityLayer.Entities;

namespace SignalRapi.Mapping
{
    public class ContactsMapping:Profile
    {
        public ContactsMapping()
        {
            CreateMap<Contacts,ResultContactsDto>().ReverseMap();
            CreateMap<Contacts,GetContactsDto>().ReverseMap();
            CreateMap<Contacts,CreateContactsDto>().ReverseMap();
            CreateMap<Contacts,UpdateContactsDto>().ReverseMap();
        }
    }
}

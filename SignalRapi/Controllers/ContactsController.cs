using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactsDto;
using SignalR.EntityLayer.Entities;

namespace SignalRapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;
        private readonly IMapper _mapper;

        public ContactsController(IContactsService contactsService, IMapper mapper)
        {
            _contactsService = contactsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactsList()
        {
            var value = _mapper.Map<List<ResultContactsDto>>(_contactsService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContacts(CreateContactsDto createContactsDto)
        {
            _contactsService.TAdd(new Contacts()
            {
                FooterDescription = createContactsDto.FooterDescription,
                Location = createContactsDto.Location,
                Mail = createContactsDto.Mail,
                Phone = createContactsDto.Phone,
            });
            return Ok("İletişim Bilgisi eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContacts(int id)
        {
            var value = _contactsService.TGetById(id);
            _contactsService.TDelete(value);
            return Ok("İletişim bilgisi silindi");
        }
        [HttpGet("{id}}")]
        public IActionResult GetContacts(int id)
        {
            var value = _contactsService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContacts(UpdateContactsDto updateContactsDto)
        {
            _contactsService.TUpdate(new Contacts()
            {
                Location = updateContactsDto.Location,
                Mail = updateContactsDto.Mail,
                Phone = updateContactsDto.Phone,
                FooterDescription = updateContactsDto.FooterDescription,
                ContactID = updateContactsDto.ContactID
            });
            return Ok("İletişim bilgileri güncellendi");

        }
    }
}

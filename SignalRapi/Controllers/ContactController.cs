using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactsService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactsService, IMapper mapper)
        {
            _contactsService = contactsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactsService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactsDto)
        {
            _contactsService.TAdd(new Contact()
            {
               FooterDescription = createContactsDto.FooterDescription,
               Location = createContactsDto.Location,
               Mail = createContactsDto.Mail,
               Phone = createContactsDto.Phone,
            });
            return Ok("İletişim Bilgisi eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactsService.TGetById(id);
            _contactsService.TDelete(value);
            return Ok("İletişim bilgisi silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactsService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactsDto)
        {
            _contactsService.TUpdate(new Contact()
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

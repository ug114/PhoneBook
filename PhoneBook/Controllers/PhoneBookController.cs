using PhoneBook.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PhoneBook.DataAccess;
using PhoneBook.BusinessLogic.Mapping;
using PhoneBook.DataAccess.Models;

namespace PhoneBook.Controllers
{
    public class PhoneBookController : ApiController
    {
        [HttpGet]
        public List<ContactDto> GetContacts()
        {
            using (var db = new PhoneBookDbContext())
            {
                return db.Contacts
                    .Select(MappingExtensions.ToDto)
                    .ToList();
            }
        }

        [HttpPost]
        public bool CreateContact(ContactDto contact)
        {
            using (var db = new PhoneBookDbContext())
            {
                db.Contacts.Add(new Contact
                {
                    Name = contact.Name,
                    Phone = contact.Phone
                });
                db.SaveChanges();

                return true;
            }
        }

        [HttpPost]
        public bool DeleteContact([FromBody]int id)
        {
            using (var db = new PhoneBookDbContext())
            {
                var contact = db.Contacts.FirstOrDefault(c => c.Id == id);
                db.Contacts.Remove(contact);
                db.SaveChanges();

                return true;
            }
        }
    }
}
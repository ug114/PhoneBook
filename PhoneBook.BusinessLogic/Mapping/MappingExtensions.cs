using PhoneBook.Contracts;
using PhoneBook.DataAccess.Models;

namespace PhoneBook.BusinessLogic.Mapping
{
    public static class MappingExtensions
    {
        public static ContactDto ToDto(this Contact contact)
        {
            return new ContactDto
            {
                Id = contact.Id,
                Phone = contact.Phone,
                Name = contact.Name
            };
        }
    }
}
